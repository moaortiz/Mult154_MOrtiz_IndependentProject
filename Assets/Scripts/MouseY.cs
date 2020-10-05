using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseY : MonoBehaviour
{
    public float verticalSpeed = 2.0F;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(-v, 0, 0);
    }
}
