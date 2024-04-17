using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class panelmanager : MonoBehaviour
{
    public GameObject LevelSecimPanel;

    void Start()
    {
        LevelSecimPanel.SetActive(false);
    }

    public void LevelSecimAc()
    {
        LevelSecimPanel.SetActive(true); 
    }

    public void LevelSecimKapat()
    {
        LevelSecimPanel.SetActive(false); 
    }

    public void OyundanCik()
    {
        Application.Quit();
    }
    // Hover Efectler

    public void OnMouseOver()
    {
        
    }

    public void OnMouseExit()
    {
        
    }

}
