using System;
using UnityEngine;

public class Parabola : MonoBehaviour
{
    [SerializeField] private float height = 0f, 
        gravity = 9.81f,
        angle = 45f,
        velocity = 10f,
        v0x, v0y;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        v0x = velocity * Mathf.Cos(angle);
        v0y = velocity * Mathf.Sin(angle);
        height = transform.position.y;
    }

    private void FixedUpdate()
    {
        rb.useGravity = true;
        float xAxis = v0x * Time.time;
        float yAxis = height + v0y * Time.time - 
                      0.5f * gravity * (float) Math.Pow(Time.time, 2);
        
        transform.position = new Vector3(xAxis, yAxis);
        rb.velocity = new Vector3(v0x, v0y - gravity * Time.time);
        
        Debug.Log("Velocity: " + rb.velocity);
    }

    public void Throw()
    {
        rb.useGravity = true;
        float xAxis = transform.position.x + v0x * Time.deltaTime;
        float yAxis = height + v0y * Time.deltaTime - 
                      0.5f * gravity * (float) Math.Pow(Time.deltaTime, 2);
        
        transform.position = new Vector3(xAxis, yAxis);
        rb.velocity = new Vector3(v0x, v0y - gravity * Time.deltaTime);
        
        Debug.Log("Velocity: " + rb.velocity);
    }
}
