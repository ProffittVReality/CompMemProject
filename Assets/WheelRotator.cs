using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;
    private float radius = 0.5f;
    private float circumference;
    private float rotPerUnit;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.parent.parent.GetComponent<Rigidbody>();
        circumference = Mathf.PI * 2 * radius; //units per rotation
        rotPerUnit = 1 / circumference;
    }

    // Update is called once per frame
    void Update()
    {
        //speed = Vector3.Project(rb.velocity, transform.forward).magnitude;
        speed = rb.velocity.z;
        //units per second

        //transform.Rotate(transform.right, speed * rotPerUnit * 360f * Time.deltaTime);
       transform.RotateAround(transform.right, speed * rotPerUnit * 360f * Time.deltaTime);
        //degrees per second
        //(speed units / second) * (rotations / unit) * (360 degrees / rotation) = degrees per second
    }
}
