using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pagesText;
    private int pages = 0;

    public TextMeshProUGUI currentTimeText;
    private string currentTime;

    //private PlayerMovement reachedLastPlatform;

    public TextMeshProUGUI goToNextLevel;
    public TextMeshProUGUI redoSameLevel;

    public Button nextLevel;
    public Button redoLevel;
    public Button mainMenu;

    public void Start()
    {
        //reachedLastPlatform.PlayerReachedEndPlatform();
        goToNextLevel.enabled = false;
        nextLevel.enabled = false;
        mainMenu.enabled = false;
        redoSameLevel.enabled = false;
        redoLevel.enabled = false;
        mainMenu.enabled = false;
    }

    public void UpdateScore(int delta)
    {
        pages += delta;
            if (pages < 0)
            {
                pages = 0;
            }
            pagesText.text = "Pages Picked Up: " + pages;
        
    }

     public void TimeTaken()
    {
        currentTime = Time.time.ToString("f2");
        currentTimeText.text = "Time Taken " + currentTime;
    }

    public void LoadMenu()
    {
        if(pages == 4)
        {
            Debug.Log("enters if statement");
            goToNextLevel.gameObject.SetActive(true);
            nextLevel.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(true);

        }
        else
        {
            Debug.Log("enters else statement");
            redoSameLevel.gameObject.SetActive(true);
            redoLevel.gameObject.SetActive(true);
            mainMenu.gameObject.SetActive(true);

        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
