using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MedKitSistemi : MonoBehaviour
{
    public Image can_bar;
    public TextMeshProUGUI medkit_sayi_text;
    public int medkit_sayi = 3; 

    public void Start()
    {
        medkit_sayi_text.text = "" + medkit_sayi;
    }
    public void CanYenileme()
    {
        if(can_bar.fillAmount < 1 && medkit_sayi > 0 )
        {
            can_bar.fillAmount = 1f;
            medkit_sayi--;
        }
    }

    public void Update()
    {
        medkit_sayi_text.text = "" + medkit_sayi;
    }
}
