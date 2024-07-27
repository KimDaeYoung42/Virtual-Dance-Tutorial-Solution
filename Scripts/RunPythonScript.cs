using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.IO;
using System.Collections;

public class RunPythonScript : MonoBehaviour
{
    public Button runButton;
    public RawImage rawImage;

    int status = 0;

    void Start()
    {
        // 시작할 때 RawImage 비활성화
        rawImage.enabled = false;
        
        runButton.onClick.AddListener(RunScript);
    }

    public void RunScript()
    {

        if (status == 0)
        {
            // 1 ~ 10 숫자를 랜덤하게 생성
            int number = Random.Range(1, 11);
            string path = string.Format(@"{0}.png", number);
            string fullPath = Path.Combine(Application.streamingAssetsPath, path);

            // 파일 읽기
            if (File.Exists(fullPath))
            {
                StartCoroutine(LoadImage(fullPath));
                //Debug.Log("File Contents: " + fileContents);
            }

        }

        status += 1;

        // 
        // 파이썬 스크립트 경로
        //string pythonScriptPath = @"C:\Users\42asu\Desktop\Capstone\python\Draw_BVHGraph.py"; // Python 실행 파일 경로

        //// 파이썬 인터프리터 실행
        //ProcessStartInfo start = new ProcessStartInfo();
        //start.FileName = "python";
        //start.Arguments = pythonScriptPath;
        //start.CreateNoWindow = true; // 콘솔 창 표시 여부 설정
        //start.UseShellExecute = false; // Shell 사용 여부 설정
        //start.UseShellExecute = false;
        //start.RedirectStandardOutput = true;

        //// 외부 프로세스 실행
        //using (Process process = Process.Start(start))
        //{
        //    // 파이썬 스크립트 실행 결과 읽기
        //    using (System.IO.StreamReader reader = process.StandardOutput)
        //    {
        //        string result = reader.ReadToEnd();

        //        //Debug.Log(result); // 결과 출력
        //    }
        //}
    }

    private IEnumerator LoadImage(string filePath)
    {
        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(fileData);

        // 이미지 출력
        rawImage.texture = texture;
        rawImage.SetNativeSize(); // 이미지의 원래 크기로 설정

        // 이미지가 로드된 후 RawImage를 활성화
        rawImage.enabled = true;

        yield return null;
    }
}
