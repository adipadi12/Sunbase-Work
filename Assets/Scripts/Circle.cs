using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject circlePrefab;
    public LineRenderer lineRenderer;
    public Camera mainCamera;

    private List<GameObject> circles = new List<GameObject>();
    private List<Vector3> linePoints = new List<Vector3>();
    private bool drawing = false;

    // Start is called before the first frame update
    void Start()
    {
        GenerateCircles(Random.Range(5, 11));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            drawing = true;
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, GetMousePosition());
            linePoints.Clear();
            linePoints.Add(GetMousePosition());
        }
        else if (Input.GetMouseButton(0) && drawing)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, GetMousePosition());
            linePoints.Add(GetMousePosition());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            drawing = false;
            CheckIntersection();
        }
    }

    void GenerateCircles(int numCircles)
    {
        for (int i = 0; i < numCircles; i++)
        {
            Vector3 position = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f);
            GameObject newCircle = Instantiate(circlePrefab, position, Quaternion.identity);
            circles.Add(newCircle);
        }
    }

    void CheckIntersection()
    {
        List<GameObject> circlesToDelete = new List<GameObject>();

        foreach (GameObject circle in circles)
        {
            for (int i = 0; i < linePoints.Count - 1; i++)
            {
                if (IsPointInsideCircle(linePoints[i], circle.transform.position, circle.transform.localScale.x / 2f) ||
                    IsPointInsideCircle(linePoints[i + 1], circle.transform.position, circle.transform.localScale.x / 2f))
                {
                    circlesToDelete.Add(circle);
                    break;
                }
            }
        }

        foreach (GameObject circle in circlesToDelete)
        {
            circles.Remove(circle);
            Destroy(circle);
        }
    }

    Vector3 GetMousePosition()
    {
        return mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }

    bool IsPointInsideCircle(Vector3 point, Vector3 circleCenter, float circleRadius)
    {
        return Vector3.Distance(point, circleCenter) <= circleRadius;
    }

    public void Restart()
    {
        foreach (GameObject circle in circles)
        {
            Destroy(circle);
        }
        circles.Clear();
        GenerateCircles(Random.Range(5, 11));
    }
}
