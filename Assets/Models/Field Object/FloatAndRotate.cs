using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAndRotate : MonoBehaviour
{
    [SerializeField] private float RotateSpeed = 50.0f;
    [SerializeField] private float FloatAmplitude = 2.0f;
    [SerializeField] private float FloatFrequency = 0.5f;

    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;        
    }

    void Update()
    {
        transform.Rotate(Vector3.up, RotateSpeed * Time.deltaTime);
        Vector3 temporaryPosition = StartPosition;
        temporaryPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * FloatFrequency) * FloatAmplitude;
        transform.position = temporaryPosition;
    }
}
