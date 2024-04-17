using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class MenuMarketSistem : MonoBehaviour
{
    public Text CoinNumberText, SpecialCardNumberText, CoinNumberMarketText, SpecialCardNumberMarketText;

    public int CoinNumber, SpecialCardNumber; 
    void Start()
    {
        // coinlerle alakalý 
        CoinNumber = PlayerPrefs.GetInt("Coin");
        PlayerPrefs.GetInt("Coin");
        CoinNumberText.text = PlayerPrefs.GetInt("Coin").ToString();

        //special card ile alakalý
        SpecialCardNumber = PlayerPrefs.GetInt("Sc");
        PlayerPrefs.GetInt("Sc");
        SpecialCardNumberText.text = PlayerPrefs.GetInt("Sc").ToString();

        //Marketteki coin ve kard ile alakalý
        CoinNumberMarketText.text = CoinNumber.ToString();

        SpecialCardNumberMarketText.text = PlayerPrefs.GetInt("Sc").ToString();

    }

    // Update is called once per frame
    void Update()
    {
        CoinNumberText.text = CoinNumber.ToString();

        SpecialCardNumberText.text = PlayerPrefs.GetInt("Sc").ToString();

        CoinNumberMarketText.text = CoinNumber.ToString();

        SpecialCardNumberMarketText.text = PlayerPrefs.GetInt("Sc").ToString();

    }


    public void CoinArttir(int artanCoinSayisi)
    {
        CoinNumber += artanCoinSayisi;
        PlayerPrefs.SetInt("Coin", CoinNumber);
    }

    public void SpecialCardArttir(int artanScSayisi)
    {
        SpecialCardNumber += artanScSayisi;
        PlayerPrefs.SetInt("Sc", SpecialCardNumber);
    }

    public void CoinAzalt(int azaltanCoinSayisi)
    {
        CoinNumber += azaltanCoinSayisi;
        PlayerPrefs.SetInt("Coin", CoinNumber);
    }

    public void SpecialCardAzalt(int azaltanScSayisi)
    {
        SpecialCardNumber += azaltanScSayisi;
        PlayerPrefs.SetInt("Sc", SpecialCardNumber);
    }
}