using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSlime : MonoBehaviour
{
    public Transform gravityTarget;
    public float power = 15000f;
    public float torque = 500f;
    public float gravity = 9.81f;

    public float autoOrientSpeed = 10.0f;
    public bool onPlanet = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        autoOrientSpeed = 20.0f;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (onPlanet)
        {
            ProcessInput();
            ProcessGravity();
        }
    }

    void ProcessInput()
    {

    }

    void ProcessGravity()
    {
        Vector3 diff = transform.position - gravityTarget.position;
        rb.AddForce(-diff.normalized * gravity * (rb.mass));
        AutoOritent(-diff);
    }

    void AutoOritent(Vector3 down)
    {
        Quaternion oritentationDirection = Quaternion.FromToRotation(-transform.up, down) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, oritentationDirection, autoOrientSpeed * Time.deltaTime);
    }
}
