using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class panelmanagement : MonoBehaviour
{
    public GameObject panelmenu, panelayarlar, panelgorev; 
    void Start()
    {
        panelmenu.SetActive(false);
        panelayarlar.SetActive(false);
        panelgorev.SetActive(false); 
    }

    public void panelmenu_ac()
    {
        Time.timeScale = 0; 
        panelmenu.SetActive(true);
        panelayarlar.SetActive(false);
        panelgorev.SetActive(false);
    }

    public void panelmenu_kapat()
    {
        Time.timeScale = 1; 
        panelmenu.SetActive(false);
        panelayarlar.SetActive(false);
        panelgorev.SetActive(false);
    }

    public void panelayarlar_Ac()
    {
        panelmenu.SetActive(false);
        panelayarlar.SetActive(true);
        panelgorev.SetActive(false);
    }

    public void panelayarlar_Kapat()
    {
        panelmenu.SetActive(true);
        panelayarlar.SetActive(false);
        panelgorev.SetActive(false);
    }

    public void panelgorev_Ac()
    {
        panelmenu.SetActive(false);
        panelayarlar.SetActive(false);
        panelgorev.SetActive(true);
    }

    public void panelgorev_Kapat()
    {
        panelmenu.SetActive(false);
        panelayarlar.SetActive(false);
        panelgorev.SetActive(false);
    }

    public void anamenu_don()
    {
        SceneManager.LoadScene("UÝ");
        Time.timeScale = 1; 
    }


    
}
