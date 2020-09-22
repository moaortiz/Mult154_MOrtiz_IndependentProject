using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseXInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.right, mouseXInput * Time.deltaTime * rotSpeed);

        float horizontalInput = Input.GetAxis("Horizontal");
        //transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * rotSpeed);
    }
}
