using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SniperScope : MonoBehaviour
{

    public GameObject scope_Panel;
    public Camera fps_Camera;

    public slotkontrol slotkontrol_kod; 

    public bool acabilir;

    public GameObject sniperscope_kapatBt,etkilesim_bt;

    void Start()
    {
        scope_Panel.SetActive(false);
       
    }

    public void Update()
    {
        acabilir = slotkontrol_kod.sniper_aktif;

        Debug.Log(acabilir);
    }

    public void ScopePanel_Ac()
    {
        if(acabilir == true)
        {
            scope_Panel.SetActive(true);
            fps_Camera.fieldOfView = 8f;
            etkilesim_bt.SetActive(false);
            sniperscope_kapatBt.SetActive(true);
        }
    }

    public void ScopePanel_Kapat()
    {
        scope_Panel.SetActive(false);
        fps_Camera.fieldOfView = 50f;
        etkilesim_bt.SetActive(true);
        sniperscope_kapatBt.SetActive(false);
    }

}
