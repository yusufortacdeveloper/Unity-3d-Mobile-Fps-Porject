using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class DailyReward : MonoBehaviour
{
    public Text Time;
    public float msToWait;
    public Button ClickButton;
    private ulong lastTimeClicked;
    public GameObject RewardPanel;
    public GameObject OdulBildirimİmage;
    public AudioSource mainmenu_sound; 

    MenuMarketSistem marketManager; 

    public void Start()
    {
        marketManager = GameObject.Find("MarketManager").GetComponent<MenuMarketSistem>();
        RewardPanel.SetActive(false);
        OdulBildirimİmage.SetActive(false);

        if (PlayerPrefs.HasKey("LastTimeClicked"))
        {
            lastTimeClicked = ulong.Parse(PlayerPrefs.GetString("LastTimeClicked"));
        }
        else
        {
            lastTimeClicked = (ulong)DateTime.Now.Ticks;
            PlayerPrefs.SetString("LastTimeClicked", lastTimeClicked.ToString());
        }

        if (!Ready())
            ClickButton.interactable = false;
    }

    public void Update()
    {
        if (!ClickButton.IsInteractable())
        {
            if (Ready())
            {
                ClickButton.interactable = true;
                Time.text = "Hazır!";
                return;
            }
            ulong diff = ((ulong)DateTime.Now.Ticks - lastTimeClicked);
            ulong m = diff / TimeSpan.TicksPerMillisecond;
            float secondsLeft = (float)(msToWait - m) / 1000.0f;

            string r = "Kalan Zaman : ";
            //HOURS
            r += ((int)secondsLeft / 3600).ToString() + "s ";
            secondsLeft -= ((int)secondsLeft / 3600) * 3600;
            //MINUTES
            r += ((int)secondsLeft / 60).ToString("00") + "d ";
            //SECONDS
            r += (secondsLeft % 60).ToString("00") + "sn";
            Time.text = r;


        }
    }


    public void Click()
    {
        marketManager.CoinArttir(250);
        marketManager.SpecialCardArttir(5);
        RewardPanel.SetActive(true);
        mainmenu_sound.Pause();
        lastTimeClicked = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("LastTimeClicked", lastTimeClicked.ToString());
        ClickButton.interactable = false;
        OdulBildirimİmage.SetActive(false);

    }
    public bool Ready()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastTimeClicked);
        ulong m = diff / TimeSpan.TicksPerMillisecond;

        float secondsLeft = (float)(msToWait - m) / 1000.0f;

        if (secondsLeft < 0)
        {
            Time.text = "Hazır!";
            OdulBildirimİmage.SetActive(true);
            return true;
        }

        return false;
    }
}
