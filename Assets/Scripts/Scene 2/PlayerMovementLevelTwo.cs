using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovementLevelTwo : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private Vector3 direction = Vector3.zero;
    public float speed = 10.0f;
    public GameObject spawnPoint = null;
    public float jumpSpeed;
    public string pagePickedUp;
    public GameManager gameManager;
    

    private bool isJumping = false;

    private bool isGameActive = true;

    private Animator anim;
    
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if(isGameActive == true)
        {
            float verMove = Input.GetAxis("Vertical");

            direction = transform.forward * verMove;

            //anim.SetFloat("Speed", verMove);


            rbPlayer.AddForce(direction * speed, ForceMode.Impulse);
            if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {
                //anim.SetBool("SpacePressed", true);
                rbPlayer.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                Debug.Log("Space bar pressed");
                isJumping = true;
            }
            else
            {

                //anim.SetBool("SpacePressed", false);
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                gameManager.GamePaused();
                isGameActive = false;
            }
        }
        
    }

    void FixedUpdate()
    {
        if (isGameActive == true)
        {
            //gameManager.TimeTaken();
        }            
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Page"))
        {

            //gameManager.UpdateScore(1);
            Destroy(other.gameObject);
        }
    }

    private void Respawn()
    {
        rbPlayer.MovePosition(spawnPoint.transform.position);
        rbPlayer.velocity = new Vector3(0, 0, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            //anim.SetBool("SpacePressed", false);
            Respawn();
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            //Debug.Log("Enters if statement for platform");
            //Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Safe") || collision.gameObject.CompareTag("Start Platform"))
        {
            //anim.SetBool("SpacePressed", false);
            isJumping = false;
        }
        if(collision.gameObject.CompareTag("End Platform"))
        {
            isGameActive = false;
            //anim.SetFloat("Speed", 0);
            gameManager.LoadMenu();
            
        }
     }

    public void Active()
    {
        isGameActive = true;
    }
}
