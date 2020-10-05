using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI pagesText;
    private int pages = 0;
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

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Page"))
        {
            UpdateScore(0);
            Destroy(other.gameObject);
        }
    }*/
}
