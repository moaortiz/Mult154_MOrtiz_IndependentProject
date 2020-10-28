using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rbPlayer;
    private Vector3 direction = Vector3.zero;
    public float speed = 10.0f;
    public GameObject spawnPoint = null;
    public float jumpSpeed;
    public string pagePickedUp;
    public GameManager gameManager;

    public bool isGameActive = false;

    private Animator anim;
    //float trans = 0;

    //private bool isGameActive = false;
   // private bool placeholder;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        ///MainMenu.GameActive += IsGamePlaying;
        //Debug.Log("Enters Start in Playermovement");
        isGameActive = true;
    }
    private void Update()
    {
        if(isGameActive == true)
        {
            float horMove = Input.GetAxis("Horizontal");
            float verMove = Input.GetAxis("Vertical");

            direction = new Vector3(horMove, 0, verMove);

            anim.SetFloat("Speed", verMove);


            rbPlayer.AddForce(direction * speed, ForceMode.Impulse);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("SpacePressed", true);
                rbPlayer.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                Debug.Log("Space bar pressed");
            }
            else
            {

                anim.SetBool("SpacePressed", false);
            }
        }
        
    }

    /*void IsGamePlaying(bool holder)
    {
        Debug.Log("Enters new IsGamePlayingMethod in Playermovement");
        placeholder = holder;
        isGameActive = true;
    }*/

    void FixedUpdate()
    {
        //Debug.Log("Enters FixedUpdate in Playermovement");
        if (isGameActive == true)
        {
            gameManager.TimeTaken();
        }            
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Page"))
        {

            gameManager.UpdateScore(1);
            Destroy(other.gameObject);
        }

        if(other.CompareTag("End Platform"))
        {
            //Debug.Log("Enters if statement");
            //mainMenu.isGameActive = false;
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
            anim.SetBool("SpacePressed", false);
            Respawn();
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Enters if statement for platform");
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Safe"))
        {
            anim.SetBool("SpacePressed", false);
        }
        if(collision.gameObject.CompareTag("End Platform"))
        {
            isGameActive = false;
            anim.SetFloat("Speed", 0);
           gameManager.LoadMenu();
        }
    }

}
