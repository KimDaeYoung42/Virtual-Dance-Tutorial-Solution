using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class BVHCompare : MonoBehaviour
{
    public string bvhFilePath1;
    public string bvhFilePath2;

    private BVHParser.BVHMotion motion1;
    private BVHParser.BVHMotion motion2;

    public Text differenceText;

    void Start()
    {
        BVHParser parser = new BVHParser();
        motion1 = parser.Parse(bvhFilePath1);
        motion2 = parser.Parse(bvhFilePath2);
    }

    public void Click_Compare()
    {
        BVHDifferenceCalculator calculator = new BVHDifferenceCalculator();
        List<float> differences = calculator.CalculateDifferences(motion1, motion2);
        DisplayDifferences(differences);
    }

    void DisplayDifferences(List<float> differences)
    {
        string differenceString = "Frame Differences:\n";
        for (int i = 0; i < differences.Count; i++)
        {
            differenceString += $"Frame {i}: {differences[i]:F2}\n";
        }
        differenceText.text = differenceString;
    }
}

public class BVHDifferenceCalculator
{
    public List<float> CalculateDifferences(BVHParser.BVHMotion motion1, BVHParser.BVHMotion motion2)
    {
        List<float> differences = new List<float>();
        int frameCount = Mathf.Min(motion1.Frames.Count, motion2.Frames.Count);

        for (int i = 0; i < frameCount; i++)
        {
            float frameDifference = CalculateFrameDifference(motion1.Frames[i], motion2.Frames[i]);
            differences.Add(frameDifference);
        }

        return differences;
    }

    private float CalculateFrameDifference(Vector3[] frame1, Vector3[] frame2)
    {
        float totalDifference = 0f;
        int jointCount = Mathf.Min(frame1.Length, frame2.Length);

        for (int j = 0; j < jointCount; j++)
        {
            totalDifference += Vector3.Distance(frame1[j], frame2[j]);
        }

        return totalDifference;
    }
}

public class BVHParser
{
    public class BVHJoint
    {
        public string Name;
        public Vector3 Offset;
        public List<string> Channels;
        public List<BVHJoint> Children;

        public BVHJoint(string name)
        {
            Name = name;
            Channels = new List<string>();
            Children = new List<BVHJoint>();
        }
    }

    public class BVHMotion
    {
        public BVHJoint RootJoint;
        public List<Vector3[]> Frames;

        public BVHMotion()
        {
            Frames = new List<Vector3[]>();
        }
    }

    public BVHMotion Parse(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        BVHMotion motion = new BVHMotion();
        int index = 0;

        // HIERARCHY 파싱
        motion.RootJoint = ParseHierarchy(lines, ref index);

        // MOTION 파싱
        ParseMotion(lines, ref index, motion);

        return motion;
    }

    private BVHJoint ParseHierarchy(string[] lines, ref int index)
    {
        Stack<BVHJoint> jointStack = new Stack<BVHJoint>();
        BVHJoint rootJoint = null;

        while (index < lines.Length)
        {
            string line = lines[index].Trim();
            string[] tokens = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            if (line.StartsWith("ROOT") || line.StartsWith("JOINT"))
            {
                if (tokens.Length < 2)
                {
                    Console.WriteLine($"Invalid joint line format at line {index}: {line}");
                    throw new FormatException($"Invalid format in line: {line}");
                }
                string jointName = tokens[1];
                BVHJoint joint = new BVHJoint(jointName);
                if (jointStack.Count > 0)
                {
                    jointStack.Peek().Children.Add(joint);
                }
                jointStack.Push(joint);

                if (rootJoint == null)
                {
                    rootJoint = joint;
                }
            }
            else if (line.StartsWith("OFFSET"))
            {
                if (tokens.Length < 4)
                {
                    Console.WriteLine($"Invalid OFFSET line format at line {index}: {line}");
                    throw new FormatException($"Invalid OFFSET format in line: {line}");
                }
                float x = float.Parse(tokens[1], CultureInfo.InvariantCulture);
                float y = float.Parse(tokens[2], CultureInfo.InvariantCulture);
                float z = float.Parse(tokens[3], CultureInfo.InvariantCulture);
                jointStack.Peek().Offset = new Vector3(x, y, z);
            }
            else if (line.StartsWith("CHANNELS"))
            {
                if (tokens.Length < 2)
                {
                    Console.WriteLine($"Invalid CHANNELS line format at line {index}: {line}");
                    throw new FormatException($"Invalid CHANNELS format in line: {line}");
                }
                int channelCount = int.Parse(tokens[1]);
                if (tokens.Length < 2 + channelCount)
                {
                    Console.WriteLine($"CHANNELS line does not have enough channels at line {index}: {line}");
                    throw new FormatException($"CHANNELS line does not have enough channels: {line}");
                }
                for (int i = 0; i < channelCount; i++)
                {
                    jointStack.Peek().Channels.Add(tokens[2 + i]);
                }
            }
            else if (line.StartsWith("End Site"))
            {
                // Skip the End Site
                while (!lines[index].Trim().StartsWith("}"))
                {
                    index++;
                }
            }
            else if (line.StartsWith("}"))
            {
                jointStack.Pop();
            }

            index++;

            if (line.StartsWith("MOTION"))
            {
                break;
            }
        }

        return rootJoint;
    }


    private void ParseMotion(string[] lines, ref int index, BVHMotion motion)
    {
        while (!lines[index].Trim().StartsWith("Frames:"))
        {
            index++;
        }
        int frameCount = int.Parse(lines[index].Trim().Split(' ')[1]);

        while (!lines[index].Trim().StartsWith("Frame Time:"))
        {
            index++;
        }
        float frameTime = float.Parse(lines[index].Trim().Split(' ')[2], CultureInfo.InvariantCulture);
        index++;

        for (int i = 0; i < frameCount; i++)
        {
            string[] tokens = lines[index].Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            Vector3[] frameData = new Vector3[motion.RootJoint.Channels.Count];
            int tokenIndex = 0;

            foreach (var channel in motion.RootJoint.Channels)
            {
                frameData[tokenIndex] = new Vector3(
                    float.Parse(tokens[tokenIndex * 3], CultureInfo.InvariantCulture),
                    float.Parse(tokens[tokenIndex * 3 + 1], CultureInfo.InvariantCulture),
                    float.Parse(tokens[tokenIndex * 3 + 2], CultureInfo.InvariantCulture));
                tokenIndex++;
            }
            motion.Frames.Add(frameData);
            index++;
        }
    }
}