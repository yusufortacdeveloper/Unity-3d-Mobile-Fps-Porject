using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class MarketManager : MonoBehaviour
{

    public float para = 400f;
    public string[] silahlar;
    public float[] fiyatlar;

    public TextMeshProUGUI para_text,para_text2; 


    public GameObject sniper_el, pompali_el, tabanca_el;
    public GameObject sniper_slot_bt, pompali_slot_bt, tabanca_slot_bt;
    public Bomba_baslatici bomb_sistem;

    void Start()
    {
        sniper_el.SetActive(false);
        pompali_el.SetActive(false);
        tabanca_el.SetActive(false);
        // --
        sniper_slot_bt.SetActive(false);
        pompali_slot_bt.SetActive(false);
        tabanca_slot_bt.SetActive(false);

        para_text.text = "PARA : " + para + "" + "£";
        para_text2.text = "PARA : " + para + "" + "£";
    }


    void Update()
    {
        
    }

    public void satin_Al(string isim)
    {
        for (int i = 0; i < silahlar.Length; i++)
        {
            if(silahlar[i] == isim)
            {
              

                if(silahlar[i] == "Pompali" && para >= fiyatlar[i] && pompali_slot_bt.activeSelf == false )
                {
                    para -= fiyatlar[i];
                    pompali_slot_bt.SetActive(true);
                    para_text.text = "PARA : " + para + "" + "£";
                    para_text2.text = "PARA : " + para + "" + "£";
                }

                if (silahlar[i] == "Sniper" && para >= fiyatlar[i] && sniper_slot_bt.activeSelf == false)
                {
                    para -= fiyatlar[i];
                    sniper_slot_bt.SetActive(true);
                    para_text.text = "PARA : " + para + "" + "£";
                    para_text2.text = "PARA : " + para + "" + "£";
                }

                if (silahlar[i] == "Tabanca" && para >= fiyatlar[i] && tabanca_slot_bt.activeSelf == false)
                {
                    para -= fiyatlar[i];
                    tabanca_slot_bt.SetActive(true);
                    para_text.text = "PARA : " + para + "" + "£";
                    para_text2.text = "PARA : " + para + "" + "£";
                }

                if (silahlar[i] == "Bomba" && para >= fiyatlar[i] && bomb_sistem.bomba_sayisi < 4)
                {
                    para -= fiyatlar[i];
                    bomb_sistem.bomba_sayisi++;
                    para_text.text = "PARA : " + para + "" + "£";
                    para_text2.text = "PARA : " + para + "" + "£";
                }
            }
        }
    }
}
