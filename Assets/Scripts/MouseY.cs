using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseY : MonoBehaviour
{
    private PlayerMovement gameActive;
    private bool active;
    public float verticalSpeed = 2.0F;
    // Start is called before the first frame update
    void Start()
    {
        gameActive.isGameActive = active;
    }

    // Update is called once per frame
    void Update()
    {
        if(active == false)
        {
            float v = verticalSpeed * Input.GetAxis("Mouse Y");
            transform.Rotate(-v, 0, 0);
        }
        
    }
}
