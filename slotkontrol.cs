using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class slotkontrol : MonoBehaviour
{
    public GameObject pompali_el, susturucu_el, sniper_el, keles_el;
    public GameObject SusturucuControlManagement, PompaliControlManagement, KelesControlManagement, SniperControlManagement; 

    public GameObject susturucuates_buton,pompaliates_buton,kelesates_buton,sniperates_buton;

    public GameObject susturucureload_buton, pompalireload_buton, kelesreload_buton, sniperreload_buton;

    public bool sniper_aktif = false;

    public Button nisan_alma_bt;

    public GameObject scope_panel;

    public Camera fps_Camera;



    // not : ates etme butonunun onclick kýsýmýna toplamda 4 adet magamentleri sýrayla yerleþtiricen
    
    public void Start()
    {
        susturucu_el.SetActive(false);
        sniper_el.SetActive(false);
        pompali_el.SetActive(false);
        keles_el.SetActive(true);

        SusturucuControlManagement.SetActive(false);
        PompaliControlManagement.SetActive(false);
        KelesControlManagement.SetActive(true);
        SniperControlManagement.SetActive(false);

        susturucuates_buton.SetActive(false);
        pompaliates_buton.SetActive(false);
        sniperates_buton.SetActive(false);
        kelesates_buton.SetActive(true);

        susturucureload_buton.SetActive(false);
        pompalireload_buton.SetActive(false);
        sniperreload_buton.SetActive(false);
        kelesreload_buton.SetActive(true);

        sniper_aktif = false;
        nisan_alma_bt.enabled = false;
    }

    
    public void Tabanca()
    {
        susturucu_el.SetActive(true);
        sniper_el.SetActive(false);
        pompali_el.SetActive(false);
        keles_el.SetActive(false);
        // control managementler scriptleri slot managementini kontrol etmemiz için kuruldu. Temel mantýgý oyuncunun içinde 4 tane ayrý obje olusturup silahlarýn scriptlerine silahlarýn objesine göre koymaktýr
        SusturucuControlManagement.SetActive(true);
        PompaliControlManagement.SetActive(false);
        KelesControlManagement.SetActive(false);
        SniperControlManagement.SetActive(false);
        // silahlara göre ates butonlarýn acýlmasý ýcýn 4 temel silaha ayrý ayrý butonlar tanýmladým
        susturucuates_buton.SetActive(true);
        pompaliates_buton.SetActive(false);
        sniperates_buton.SetActive(false);
        kelesates_buton.SetActive(false);
        // her silahýn ayrý bir reload sistemi olacagýndan her birine ayrý buton tanýmlamayý uygun gördüm
        susturucureload_buton.SetActive(true);
        pompalireload_buton.SetActive(false);
        sniperreload_buton.SetActive(false);
        kelesreload_buton.SetActive(false);

        sniper_aktif = false;
        nisan_alma_bt.enabled = false;
        scope_panel.SetActive(false);
        fps_Camera.fieldOfView = 50f;
    }

    public void Pompali()
    {
        susturucu_el.SetActive(false);
        sniper_el.SetActive(false);
        pompali_el.SetActive(true);
        keles_el.SetActive(false);

        SusturucuControlManagement.SetActive(false);
        PompaliControlManagement.SetActive(true);
        KelesControlManagement.SetActive(false);
        SniperControlManagement.SetActive(false);

        susturucuates_buton.SetActive(false);
        pompaliates_buton.SetActive(true);
        sniperates_buton.SetActive(false);
        kelesates_buton.SetActive(false);

        susturucureload_buton.SetActive(false);
        pompalireload_buton.SetActive(true);
        sniperreload_buton.SetActive(false);
        kelesreload_buton.SetActive(false);

        sniper_aktif = false;
        nisan_alma_bt.enabled = false;
        scope_panel.SetActive(false);
        fps_Camera.fieldOfView = 50f;
    }

    public void Sniper()
    {
        susturucu_el.SetActive(false);
        sniper_el.SetActive(true);
        pompali_el.SetActive(false);
        keles_el.SetActive(false);

        SusturucuControlManagement.SetActive(false);
        PompaliControlManagement.SetActive(false);
        KelesControlManagement.SetActive(false);
        SniperControlManagement.SetActive(true);

        susturucuates_buton.SetActive(false);
        pompaliates_buton.SetActive(false);
        sniperates_buton.SetActive(true);
        kelesates_buton.SetActive(false);

        susturucureload_buton.SetActive(false);
        pompalireload_buton.SetActive(false);
        sniperreload_buton.SetActive(true);
        kelesreload_buton.SetActive(false);

        sniper_aktif = true;
        nisan_alma_bt.enabled = true;
        fps_Camera.fieldOfView = 50f;
    }

    public void Keles()
    {
        susturucu_el.SetActive(false);
        sniper_el.SetActive(false);
        pompali_el.SetActive(false);
        keles_el.SetActive(true);

        SusturucuControlManagement.SetActive(false);
        PompaliControlManagement.SetActive(false);
        KelesControlManagement.SetActive(true);
        SniperControlManagement.SetActive(false);

        susturucuates_buton.SetActive(false);
        pompaliates_buton.SetActive(false);
        sniperates_buton.SetActive(false);
        kelesates_buton.SetActive(true);

        susturucureload_buton.SetActive(false);
        pompalireload_buton.SetActive(false);
        sniperreload_buton.SetActive(false);
        kelesreload_buton.SetActive(true);

        sniper_aktif = false;
        nisan_alma_bt.enabled = false;
        scope_panel.SetActive(false);
        fps_Camera.fieldOfView = 50f;
    }

}
