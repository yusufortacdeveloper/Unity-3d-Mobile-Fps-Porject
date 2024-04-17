using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.Audio; 

public class DefenderAi : MonoBehaviour
{
    public Transform[] varis_noktalari; // varýþ noktalarýn transformlarý 

    public Transform Dost; 

    int anlikVarisNoktaÝndeksi; // anlik varýþ noktasýnýn indexi 

    NavMeshAgent nav; // dusmanýn navmeshagent'ý

    float anlik_BeklemeSuresi; // varis noktalarina ulaþýldýgýnda beklemek için gerekilen 2 parametre
    float max_BeklemeSuresi;

    float mesafe;

    public bool Gezebilir;

    Level1SpawnManager spawn_manager;

    public GameObject Kosma_Sound;
    AudioSource kosmasoun_component;

    public int can = 100; 

    Animator ai_anim; 
    void Start()
    {
        spawn_manager = GameObject.Find("SpawnManager").GetComponent<Level1SpawnManager>();

        kosmasoun_component = Kosma_Sound.GetComponent<AudioSource>();

        Kosma_Sound.SetActive(false);

        Gezebilir = true;

        Dost = GameObject.FindGameObjectWithTag("oyuncu").transform;

        nav = GetComponent<NavMeshAgent>();

        ai_anim = GetComponent<Animator>();

        anlikVarisNoktaÝndeksi = 0;
        anlik_BeklemeSuresi = 0;
        max_BeklemeSuresi = 0;
        
        ai_anim.SetBool("durdu", true);
        Invoke("YeniVarisNoktasi", 10f);
    }

    
    void Update()
    {
        mesafe = Vector3.Distance(gameObject.transform.position, Dost.transform.position);

        #region Gezme ile alakalý 
        if (Gezebilir == true)

        {
            if (nav.remainingDistance < 0.5f)
            {
                Kosma_Sound.SetActive(false);

                if (max_BeklemeSuresi == 0)
                {
                    max_BeklemeSuresi = Random.Range(0f, 5f);
                }

                if (anlik_BeklemeSuresi >= max_BeklemeSuresi)
                {
                    max_BeklemeSuresi = 0;
                    anlik_BeklemeSuresi = 0;
                    YeniVarisNoktasi();
                }
                else
                {
                    ai_anim.SetBool("durdu", true);
                    anlik_BeklemeSuresi += Time.deltaTime;
                }


            }

            if (nav.remainingDistance > 0.5f)
            {
                Kosma_Sound.SetActive(true);
                ai_anim.SetBool("durdu", false);
            }

        }

        #endregion

        #region dost objesýný taninladigi zaman olacaklar
        if (mesafe < 17f && spawn_manager.terorist_Secildi == true)
        {
            Gezebilir = false;

            nav.SetDestination(Dost.transform.position);

            if(mesafe < 10f)
            {
                
                nav.isStopped = true;
                ai_anim.SetBool("durdu", true);
                Kosma_Sound.SetActive(false);
                transform.LookAt(new Vector3(Dost.transform.position.x,this.transform.position.y,Dost.transform.position.z)); 
            }
        }
        else 
        {
            Gezebilir = true;
            nav.isStopped = false;
            Kosma_Sound.SetActive(true);
        }
        #endregion

        #region Kosma sesini yaklasmaya gore ayarlama
        if (mesafe > 25f)
        {
            kosmasoun_component.volume = 0.20f;
        }
        else if (mesafe < 25f && mesafe > 17f)
        {
            kosmasoun_component.volume = 0.40f;
        }
        else if (mesafe < 17f)
        {
            kosmasoun_component.volume = 1f;
        }
        #endregion

        if(can <= 0)
        {
            ai_anim.SetBool("dead", true);
            nav.enabled = false;
            kosmasoun_component.enabled = false; 
        }
        Debug.Log(mesafe);
    }
     
    void YeniVarisNoktasi() // bu kod blogu yený varýs noktasýna ilerlememizi saglar! 
    {
        if(varis_noktalari.Length != 0 && Gezebilir == true)
        {
            anlikVarisNoktaÝndeksi = Random.Range(0,59);
            ai_anim.SetBool("durdu", false);
            nav.SetDestination(varis_noktalari[anlikVarisNoktaÝndeksi].position);
        }
    }

    public void CanAzalt(int hasar)
    {
        can -= hasar; 
    }
}