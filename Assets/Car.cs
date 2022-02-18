using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 struct FrameInputs
{
    public Vector3 direction;
}

public class Car : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;

    public float maxSpeed = 15, acceleration = 5;
    public float gravity = -10;

    public Vector3 velocity;

    public Vector2 rotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        var add = Quaternion.Euler(0, rotation.y, 0) * inputs.direction;
        rb.velocity = Vector3.MoveTowards(rb.velocity, Vector3.ClampMagnitude(rb.velocity + add * Time.fixedDeltaTime * acceleration, maxSpeed), acceleration * Time.fixedDeltaTime);
        rb.AddForce(gravity * Vector3.down * Time.fixedDeltaTime);
    }

    #region Input Handling
    private FrameInputs inputs = new FrameInputs();
    // Update is called once per frame
    void Update()
    {
        var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        dir.Normalize();
        inputs.direction = dir;
    }
    #endregion

    #region Camera
    void LateUpdate()
    {

    } 
    #endregion
}