using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BicakSaldiri : MonoBehaviour
{
    
    public Button bicsaldir_buton;
    public Animator bicakel_animator; 

    // saldiri gerekenler

    public GameObject bicaksokmasesi_bicakel;
    public GameObject hasarizi_bicak;

    public Button slot_susturucu_buton, slot_sniper_buton, slot_pompali_buton, slot_keles_buton, bicak_saldiri_buton;

    KarakterHareket player_Hareket; 

    // saldiri mekanigi 

    public float hasar = 10f;
    public float mesafe = 100f;

    public Camera fpsCam;

    public void Start()
    {
        player_Hareket = GameObject.Find("Player").GetComponent<KarakterHareket>();
    }

    public void bic_saldirisi()
    {
        StartCoroutine("bic_attack");
        saldiri();
    }

    IEnumerator bic_attack()
    {
        bicak_saldiri_buton.enabled = false;
        bicakel_animator.SetBool("Ýdle_bicak", true);
        bicakel_animator.SetBool("Atak_bicak", true);
        player_Hareket.Silah_Tetiklendi = true;
        bicaksokmasesi_bicakel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        player_Hareket.Silah_Tetiklendi = false;
        bicaksokmasesi_bicakel.SetActive(false);
        bicakel_animator.SetBool("Ýdle_bicak", false);
        bicakel_animator.SetBool("Atak_bicak", false);
        bicak_saldiri_buton.enabled = true;


    }

    public void saldiri()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 4f))
        {
            Debug.Log(hit.transform.name);

            GameObject mermi_izi = Instantiate(hasarizi_bicak, hit.point, Quaternion.LookRotation(hit.normal));

            #region mermi izi siler 
            Destroy(mermi_izi, 1f);
            #endregion

        }

    }
}
