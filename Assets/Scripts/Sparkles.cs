using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparkles : MonoBehaviour
{
    public Transform Target;
    public float DistanceFromCamera = 500;
    public float VelocityOfSpeed = 1000;
    public float SwingAcceleration = 100;
    public float MaxSwingSpeed = 200;

    float SwingSpeed = 0;
    int SwingSign = 1;

    bool clicked = false;
    Camera camera;
    void Start()
    {
        camera = Camera.main;
        SwingSpeed = -0.5f * SwingSign * MaxSwingSpeed;
    }

    void Update()
    {
        if (!clicked)
        {
            CloseToCamera();
        } else {
            Vector3 targetDirection = (Target.position - transform.position).normalized;
            Vector3 velocity = targetDirection * VelocityOfSpeed * Time.deltaTime;

            Vector3 swingDirection = Vector3.Cross(targetDirection, Vector3.down).normalized;
            SwingSpeed += SwingSign * SwingAcceleration * Time.deltaTime;
            if(Mathf.Abs(SwingSpeed) > MaxSwingSpeed) SwingSign *= -1;
            velocity += swingDirection * SwingSpeed * Time.deltaTime;

            transform.position = transform.position + velocity;
        }
    }
    
    void CloseToCamera()
    {
        transform.position = camera.transform.position + (Target.position - camera.transform.position).normalized * DistanceFromCamera;
    }

    void OnMouseDown()
    {
        clicked = true;
    }
}
