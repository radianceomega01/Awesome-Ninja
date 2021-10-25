using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    float yAxis;
    float xAxis;
    float rotationSentivity;
    Vector3 targetAngle;
    private void Awake()
    {
        rotationSentivity = 8f;
    }

    private void Update()
    {
        yAxis += Input.GetAxis("Mouse X") * rotationSentivity;
        xAxis -= Input.GetAxis("Mouse Y") * rotationSentivity;
        targetAngle = new Vector3(xAxis, yAxis);
        transform.eulerAngles = targetAngle;
       
    }

} // class







































