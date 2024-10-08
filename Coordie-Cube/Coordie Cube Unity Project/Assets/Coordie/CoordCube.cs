using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordCube : MonoBehaviour
{

    // Representational objects
    [SerializeField] private Transform xAxis;
    [SerializeField] private Transform yAxis;
    [SerializeField] private Transform zAxis;
    [SerializeField] private Transform point;

    // starting sizes
    private Vector3 xScale;
    private Vector3 yScale;
    private Vector3 zScale;
    private Vector3 pointScale;

    // Start is called before the first frame update
    void Start()
    {
        // Get starting scales
        xScale = xAxis.lossyScale;
        yScale = yAxis.lossyScale;
        zScale = zAxis.lossyScale;
        pointScale = point.lossyScale;

    }

    void Update()
    {
        // Prevent each axis from warping

        float xScaler = transform.lossyScale.x;
        float yScaler = transform.lossyScale.y;
        float zScaler = transform.lossyScale.z;
        xAxis.localScale = new Vector3(xScale.x / zScaler, xScale.y / yScaler, xAxis.localScale.z);
        yAxis.localScale = new Vector3(yScale.x / xScaler, yScale.y / zScaler, yAxis.localScale.z);
        zAxis.localScale = new Vector3(zScale.x / xScaler, zScale.y / yScaler, zAxis.localScale.z);
        point.localScale = new Vector3(pointScale.x / xScaler, pointScale.y / yScaler, pointScale.z / zScaler);

    }
}
