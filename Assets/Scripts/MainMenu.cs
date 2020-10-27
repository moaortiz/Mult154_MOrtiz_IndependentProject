using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public delegate void IsGameActive(bool active);
    //public static event IsGameActive GameActive;

    //private bool gamePlaying = false;
    public void PlayGame()
    {
        //IsGameBeingPlayed();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //GameActive?.Invoke(true);
    }

    /*public void IsGameBeingPlayed()
    {
        Debug.Log("enters method");
        GameActive?.Invoke(true);
    }*/
}
