using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRope : MonoBehaviour
{
    public Transform startObject;
    public Transform endObject;
    public int resolution = 10;
    public float height = 1f;

    private LineRenderer lineRenderer;

    private void Start()
    {
        
        if (startObject == null || endObject == null)
        {
            Debug.LogError("Необходимо назначить начальный и конечный объекты!");
            return;
        }

        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        lineRenderer.positionCount = resolution + 1;
        UpdateLineRenderer();
    }

    private void Update()
    {
        UpdateLineRenderer();
    }

    private void UpdateLineRenderer()
    {
        Vector3[] positions = new Vector3[resolution + 1];

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / resolution;
            positions[i] = CalculateParabolicPoint(t);
        }

        lineRenderer.SetPositions(positions);
    }

    private Vector3 CalculateParabolicPoint(float t)
    {
        Vector3 point = Vector3.Lerp(startObject.position, endObject.position, t);
        point.y += Mathf.Sin(t * Mathf.PI) * height;
        return point;
    }
}
