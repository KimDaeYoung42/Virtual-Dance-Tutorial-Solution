using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphDrawer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int numPoints = 50;
    public float width = 0.1f;
    public float height = 5f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numPoints;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }

    public void Button_Click()
    {
        DrawGraph();
    }

    void DrawGraph()
    {
        Vector3[] points = new Vector3[numPoints];
        for (int i = 0; i < numPoints; i++)
        {
            float x = i / (float)(numPoints - 1);
            float y = Mathf.Sin(x * Mathf.PI * 2) * height;
            points[i] = new Vector3(x, y, 0);
        }
        lineRenderer.SetPositions(points);
    }
}
