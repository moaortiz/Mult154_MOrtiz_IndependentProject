using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pagesText;
    private int pages = 0;

    public TextMeshProUGUI currentTimeText;
    private string currentTime;
    // Start is called before the first frame update
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
}
