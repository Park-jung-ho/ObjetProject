using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class RotTest : MonoBehaviour
{
    public float rotspeed;
    private bool dragging = false;
    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); 
    }

    void OnMouseDrag() 
    {
        dragging = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
    }
    void FixedUpdate() 
    {
        if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotspeed;
            float y = Input.GetAxis("Mouse Y") * rotspeed;
            // float x = Input.GetAxis("Mouse X") * rotspeed * Time.fixedDeltaTime;
            // float y = Input.GetAxis("Mouse Y") * rotspeed * Time.fixedDeltaTime;

            _rigidbody.AddTorque(Vector3.down * x);
            _rigidbody.AddTorque(Vector3.right * y);
        }
        else
        {
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
