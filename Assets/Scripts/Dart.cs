using System;
using UnityEngine;
using UnityEngine.UI;

public class Dart : MonoBehaviour
{
    [SerializeField] private bool isThrowing;
    [SerializeField] private ControllerManager controller;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private float height, 
        gravity = 9.81f,
        throwVelocity,
        v0Z, v0Y;
    
    private Rigidbody dartRigidbody;
    [SerializeField] private bool isNotUsed;

    public bool IsNotUsed
    {
        get => isNotUsed;
        set => isNotUsed = value;
    }
    
    public bool IsThrowing
    {
        get => isThrowing;
        set => isThrowing = value;
    }

    private void Start()
    {
        dartRigidbody = GetComponent<Rigidbody>();
        height = transform.position.y;
    }

    private void Update()
    {
        throwVelocity = speedSlider.value;
        CalculateV0();

        // Rotate dart when falling down
        if (dartRigidbody.velocity.y <= 0 && isThrowing && !dartRigidbody.isKinematic)
        {
            transform.rotation = Quaternion.LookRotation(-dartRigidbody.velocity);
        }
    }
    
    public void CalculateV0()
    {
        float degToRad = transform.eulerAngles.x * Mathf.Deg2Rad;
        
        // Calculate v0X
        v0Z = throwVelocity * Mathf.Cos(degToRad);
        // Calculate v0Y
        v0Y = throwVelocity * Mathf.Sin(degToRad);
    }
    
    public void Shoot()
    {
        isThrowing = true;
        dartRigidbody.useGravity = true;
        float zAxis = transform.position.z + v0Z * Time.deltaTime;
        float yAxis = height + v0Y * Time.deltaTime - 
                      0.5f * gravity * (float) Math.Pow(Time.deltaTime, 2);
        
        transform.position = new Vector3(transform.position.x, yAxis, zAxis);
        dartRigidbody.velocity = new Vector3(0, v0Y - gravity * Time.deltaTime, v0Z);
    }
}
