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

    //public ArrayList [] platforms;
    //public GameObject [] platforms;

    private bool isJumping = false;

    private bool isGameActive = true;

    private Animator anim;

    private IEnumerator coroutine;
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if(isGameActive == true)
        {
            float verMove = Input.GetAxis("Vertical");

            direction = transform.forward * verMove;

            anim.SetFloat("Speed", verMove);


            rbPlayer.AddForce(direction * speed, ForceMode.Impulse);
            if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
            {
                anim.SetBool("SpacePressed", true);
                rbPlayer.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                Debug.Log("Space bar pressed");
                isJumping = true;
            }
            else
            {

                anim.SetBool("SpacePressed", false);
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
    }

    private void Respawn()
    {
        rbPlayer.MovePosition(spawnPoint.transform.position);
        rbPlayer.velocity = new Vector3(0, 0, 0);
        //platforms.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            anim.SetBool("SpacePressed", false);
            Respawn();
        }
    }


    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Enters if statement for platform");
            other.gameObject.SetActive(false);
            //coroutine = PlatformsReappear(5.0f);
            //StartCoroutine(coroutine);

            /*float destroyedTime = Time.deltaTime;
            if(destroyedTime == 2.0f)
            {
                other.gameObject.SetActive(true);
            }*/
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Safe") || collision.gameObject.CompareTag("Start Platform"))
        {
            anim.SetBool("SpacePressed", false);
            isJumping = false;
        }
        if(collision.gameObject.CompareTag("End Platform"))
        {
            isGameActive = false;
            anim.SetFloat("Speed", 0);
            gameManager.LoadMenu();
            
        }
        if (collision.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Enters oncollisionenter if statement for platform");

            //StartCoroutine(WaitTime());

            /*float playerOnTime = Time.deltaTime;
            if (playerOnTime >= 4.0f)
            {
                collision.gameObject.SetActive(false);
            }*/
        }
    }


    /*private IEnumerator WaitTime()
    {
        Deactivate();
        yield return new WaitForSeconds(5.0f);
    }

    private void Deactivate()
    {
        gameObject.CompareTag("Platform").SetActive(false);
    }*/

    public void Active()
    {
        isGameActive = true;
    }
}
