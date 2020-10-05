using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PagesPickedUp : MonoBehaviour
{
    private TextMeshProUGUI tmPages;
    public string pagePickedUp;
    int count = 0;

    void Start()
    {
        tmPages = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void UpdateCount()
    {
        
        count++;
        tmPages.text = pagePickedUp + ": " + count;
    }
}
