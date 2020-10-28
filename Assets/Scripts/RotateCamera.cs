using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float horizontalSpeed = 2.0F;

    private PlayerMovement gameActive;
    private bool active;

    void FixedUpdate()
    {
        gameActive.isGameActive = active;
    }
    void Update()
    {
        if (active == false)
        {
            float h = horizontalSpeed * Input.GetAxis("Mouse X");

            transform.Rotate(0, h, 0);
        }
    }
}
