using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI; 

public class SettingsScript : MonoBehaviour
{

    public Slider SL�DER;

    public int Kalite_�ndex; 

    public void Start()
    {
        LoadAudio();
        Load_Kalite();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        SaveAudio();
    }

    public void SaveAudio()
    {
        PlayerPrefs.SetFloat("SesKayit", AudioListener.volume);
    }

    public void LoadAudio()
    {
        if(PlayerPrefs.HasKey("SesKayit"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("SesKayit");
            SL�DER.value = PlayerPrefs.GetFloat("SesKayit");
        }
        else
        {
            PlayerPrefs.SetFloat("SesKayit", 0.2f);
            AudioListener.volume = PlayerPrefs.GetFloat("SesKayit");
            SL�DER.value = PlayerPrefs.GetFloat("SesKayit");
        }
      
    }
     
   
    public void Load_Kalite()
    {
        if (PlayerPrefs.HasKey("Grafik"))
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Grafik"));
        }
        else
        {
            PlayerPrefs.SetFloat("Grafik", 0);
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Grafik"));
        }
    }

    public void Dusuk_Grafik()
    {
        Kalite_�ndex = 1;
        PlayerPrefs.SetInt("Grafik", Kalite_�ndex);
        Debug.Log(PlayerPrefs.GetInt("Grafik"));
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Grafik"));
    }

    public void Orta_Grafik()
    {
        Kalite_�ndex = 2;
        PlayerPrefs.SetInt("Grafik", Kalite_�ndex);
        Debug.Log(PlayerPrefs.GetInt("Grafik"));
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Grafik"));
    }

    public void Yuksek_Grafik()
    {
        Kalite_�ndex = 3; 
        PlayerPrefs.SetInt("Grafik", Kalite_�ndex);
        Debug.Log(PlayerPrefs.GetInt("Grafik"));
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Grafik"));
    }
  
    public void Ultra_Grafik()
    {
        Kalite_�ndex = 4;
        PlayerPrefs.SetInt("Grafik", Kalite_�ndex);
        Debug.Log(PlayerPrefs.GetInt("Grafik"));
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Grafik"));
    }
}
