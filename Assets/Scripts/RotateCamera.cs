using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    /*public float rotSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseXInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.right, mouseXInput * Time.deltaTime * rotSpeed);

        //float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Enters If Statement");
            transform.Rotate(new Vector3(0, 4, 0) * rotSpeed);

        }

        //transform.rotation = new Vector3(horizontalInput, 0,0);
    }*/
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(v, h, 0);
    }
}
