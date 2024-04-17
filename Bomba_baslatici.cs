using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;


public class Bomba_baslatici : MonoBehaviour
{
    public Transform baslangic_Noktasi;
    public GameObject bomba;

    public GameObject bombapatlama_Sesi,bombafirlatma_Sesi; 

    public GameObject bicak_el, pompali_el, sniper_el, susturucu_el;

    public TextMeshProUGUI bomba_sayi_text;
    public float bomba_sayisi = 4f;

 
    public Button bombabt; 

    float range = 15f;

    public CameraShake camera_shake;
    void Start()
    {
        bomba_sayi_text.text = "" + bomba_sayisi;
        bombapatlama_Sesi.SetActive(false);
        bombafirlatma_Sesi.SetActive(false);
    }

    public void Update()
    {
        bomba_sayi_text.text = "" + bomba_sayisi;
    }
    public void Bomba_Baslatici()
    {
        if(bomba_sayisi > 0)
        {
            GameObject bomba_tur = Instantiate(bomba, baslangic_Noktasi.position, baslangic_Noktasi.rotation);
            bomba_tur.GetComponent<Rigidbody>().AddForce(baslangic_Noktasi.forward * range, ForceMode.Impulse);
            StartCoroutine("bombpatlamasesi");
            bomba_sayisi--;

            if (bicak_el.activeSelf != false || pompali_el.activeSelf != false || sniper_el.activeSelf != false || susturucu_el.activeSelf != false)
            {
                StartCoroutine("bomba_cooldown");
                StartCoroutine("silah_indirme");
                StartCoroutine("camera_shakeolay");
            }

        }

    }

    IEnumerator silah_indirme()
    {
      
        if(bicak_el.activeSelf != false)
        bicak_el.transform.DOMoveY(bicak_el.transform.position.y - 0.05f, 0.6f);

        if(sniper_el.activeSelf != false)
        sniper_el.transform.DOMoveY(sniper_el.transform.position.y - 0.10f, 0.6f);

        if(pompali_el.activeSelf != false)
        pompali_el.transform.DOMoveY(pompali_el.transform.position.y - 0.10f, 0.6f);

        if(susturucu_el.activeSelf != false)
        susturucu_el.transform.DOMoveY(susturucu_el.transform.position.y - 0.10f, 0.6f);

        yield return new WaitForSeconds(0.6f);
        

        if (bicak_el.activeSelf != false)
            bicak_el.transform.DOMoveY(bicak_el.transform.position.y + 0.05f, 0.6f);
        
        if (sniper_el.activeSelf != false)
            sniper_el.transform.DOMoveY(sniper_el.transform.position.y + 0.10f, 0.6f);

        if (pompali_el.activeSelf != false)
            pompali_el.transform.DOMoveY(pompali_el.transform.position.y + 0.10f, 0.6f);

        if (susturucu_el.activeSelf != false)
            susturucu_el.transform.DOMoveY(susturucu_el.transform.position.y + 0.10f, 0.6f);
    }

    IEnumerator bomba_cooldown()
    {
        bombabt.enabled = false;
        yield return new WaitForSeconds(3f);
        bombabt.enabled = true;

    }

    IEnumerator bombpatlamasesi()
    {
        bombafirlatma_Sesi.SetActive(true);
        bombapatlama_Sesi.SetActive(true);
        yield return new WaitForSeconds(3f);
        
        bombafirlatma_Sesi.SetActive(false);
        bombapatlama_Sesi.SetActive(false);
    }

    IEnumerator camera_shakeolay()
    {

        yield return new WaitForSeconds(2f);
        StartCoroutine(camera_shake.Shake(.15f, .2f));
    }
    
}
