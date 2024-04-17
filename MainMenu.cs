using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio; 

public class MainMenu : MonoBehaviour
{
    public GameObject Harita_secim_panel;

    public GameObject Cikis_Uyari_Panel,Market_Panel,Ayarlar_Panel,DailyReward_Panel,Congrulations_Panel;

    public AudioSource MainMenu_Sound; 
    
    public void Harita_Secim_Ac()
    {
        Harita_secim_panel.SetActive(true);
    }

    public void Harita_Secim_Kapat()
    {
        Harita_secim_panel.SetActive(false);
    }

    public void CikisPanelAc()
    {
        if(Cikis_Uyari_Panel.activeSelf != true)
        {
            Cikis_Uyari_Panel.SetActive(true);
        }
        
    }


    public void CikisPanelKapat()
    {
        if (Cikis_Uyari_Panel.activeSelf == true)
        {
            Cikis_Uyari_Panel.SetActive(false);
        }

    }

    public void MarketPanelAc()
    {
        if(Market_Panel.activeSelf != true)
        {
            Market_Panel.SetActive(true);
        }
    }

    public void MarketPanelKapat()
    {
        if (Market_Panel.activeSelf == true)
        {
            Market_Panel.SetActive(false);
        }
    }

    public void AyarlarPanelAc()
    {
        if(Ayarlar_Panel.activeSelf != true)
        {
            Ayarlar_Panel.SetActive(true);
        }
    }

    public void AyarlarPanelKapat()
    {
        if (Ayarlar_Panel.activeSelf == true)
        {
            Ayarlar_Panel.SetActive(false);
        }
    }

    public void OdulPanelAc()
    {
        if (DailyReward_Panel.activeSelf != true)
        {
            DailyReward_Panel.SetActive(true);
        }
    }

    public void OdulPanelKapat()
    {
        if (DailyReward_Panel.activeSelf == true)
        {
            DailyReward_Panel.SetActive(false);
        }
    }

   
    public void CongrulationsPanelKapat()
    {
        if (DailyReward_Panel.activeSelf == true)
        {
            Congrulations_Panel.SetActive(false);
            MainMenu_Sound.UnPause();
        }
    }

    public void OyundanCik()
    {
        Application.Quit();
    }


}
