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
    //public MainMenu mainMenu;
    //private bool isGameActive;
   

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        //tmPages = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        float horMove = Input.GetAxis("Horizontal");
        float verMove = Input.GetAxis("Vertical");

        direction = new Vector3(horMove, 0, verMove);
        //jumpDirection = new Vector3(horMove, jumpSpeed, verMove);
    }

    void FixedUpdate()
    {
        //(mainMenu.isGameActive == true)
        {
            rbPlayer.AddForce(direction * speed, ForceMode.Impulse);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rbPlayer.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                Debug.Log("Space bar pressed");
            }

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
            Debug.Log("Enters if statement");
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
}
