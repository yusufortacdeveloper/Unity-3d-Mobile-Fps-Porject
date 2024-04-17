using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SniperSaldiri : MonoBehaviour
{
    public GameObject sniper_el; // susturucu el olan objenin kendisi
    public Animator sniper_anim; // susturucu elin animatoru

    // mermi sistemi 

    public float mermi_Sayisi = 12f; // baslang�ctaki mermi say�m�z� belirledik 
    public Button atesetme_button; // bu butonu tan�mlama amac�m: eger silah reload durumuna girerse mermi says�n�n azlmas�na engel olmakt�r
    public Button Reload_button;

    public Button slot_susturucu_buton, slot_sniper_buton, slot_pompali_buton, slot_keles_buton,bicak_saldiri_buton;

    public TextMeshProUGUI mermisayi_text; // bu bize ekranda ka� mermi kald���m�z� g�stericek 

    // ates sistemi gerekilenler

    public GameObject atessesi_sniper;
    public GameObject reloadesei_sniper;
    public GameObject muzzleflash_sniper;
    public GameObject mermifirlama_sniper;
    public GameObject mermiizi_sniper; // mermi efecti cal�st�r�r

    // ates sistemi mekanigi

    public float mesafe = 100f;
    public Camera fpsCam;

    // recoil efekt sistemi

    public float minX, maxX;
    public float minY, maxY;
    public Transform camera_fps;
    public Vector3 rot;

    // karakter hareketi ile alakal� kodlar 

    KarakterHareket player_Hareket;

    // dusmana hit ile alakali icerikler

    Animator dusman_anim;
    Level1SpawnManager spawn_manager;
    public GameObject hit_sound; // hasar verme sesi 
    public Image crosshair_image;
    DefenderAi defender_ai;

    public void Sniperel_Ates()
    {
        AtesMekanigi();
        recoil();
        StartCoroutine("muzzle_flash_control");
        StartCoroutine("atesetme"); // bu fonksiyon bize ates etme butonuna t�klad�g�m�zda ates etmey� saglar 
    }

    public void Sniper_Reload()
    {
        if (mermi_Sayisi < 12)
        {
            StartCoroutine("reload"); // bu fonksiyon bize silah�n reload durumuna girmesini saglar 
        }
    }

    public void Start()
    {
        PlayerPrefs.GetFloat("sniper_mermi");
        player_Hareket = GameObject.Find("Player").GetComponent<KarakterHareket>();
        spawn_manager = GameObject.Find("SpawnManager").GetComponent<Level1SpawnManager>();
    }

    public void Update()
    {
        sniper_el.transform.localPosition = new Vector3(50f, -1.411f, 0.6870003f);

        PlayerPrefs.SetFloat("sniper_mermi", mermi_Sayisi); // tabanca mermisini kay�t ettik

        mermisayi_text.text = PlayerPrefs.GetFloat("sniper_mermi") + "" + "/" + "" + "999"; // ana sayfada kalan mermi say�m�z� g�sterdik 

        #region oto_reload 
        if (mermi_Sayisi <= 0) // bu blok bize mermi 0 dan d���k oldugunda oto reload etmesini sa�lar
        {
            StartCoroutine("reload");
        }
        #endregion

        #region recoil efekt hesaplamalari // recoil efektleri

        rot = camera_fps.transform.localRotation.eulerAngles; // recoil efekt i�in kameran�n rotasyonunu kaydettik

        if (rot.x != 0 || rot.y != 0)
        {
            camera_fps.transform.localRotation = Quaternion.Slerp(camera_fps.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 3); // bu kod recoil olduktan sonra kameran�n yavas tavas asag� �nmes�n� saglar
        }

        #endregion
    }

    IEnumerator atesetme() // ates etme olaylar�n� bir numerator �le d�nd�rd�m
    {
        sniper_anim.SetBool("�dle_sniper", true);
        sniper_anim.SetBool("AtesEtme_sniper", true);
        atesetme_button.enabled = false; // ust uste t�klay�p an�masyon cak�smas�n� engellemek istedim
        player_Hareket.Silah_Tetiklendi = true;
        mermifirlama_sniper.SetActive(true);
        atessesi_sniper.SetActive(true);
        mermi_Sayisi--;
        yield return new WaitForSeconds(1f);
        player_Hareket.Silah_Tetiklendi = false; 
        mermifirlama_sniper.SetActive(false);
        atessesi_sniper.SetActive(false);
        atesetme_button.enabled = true; // butonu tekrardan aktifle�tirerek s�kabilmesini sa�lad�m 
        sniper_anim.SetBool("AtesEtme_sniper", false);
    }

    IEnumerator reload() // reload olaylar�n� bir numerator ile d�nd�rd�m
    {
        sniper_el.transform.rotation = Quaternion.Euler(10f, 10f, 10f);
        sniper_anim.SetBool("�dle_sniper", true);
        sniper_anim.SetBool("AtesEtme_sniper", false);
        sniper_anim.SetBool("Reload_sniper", true);
        atesetme_button.enabled = false;
        Reload_button.enabled = false;
        mermi_Sayisi = 0f;
        reloadesei_sniper.SetActive(true);
        slot_keles_buton.enabled = false;
        slot_pompali_buton.enabled = false;
        slot_sniper_buton.enabled = false;
        slot_susturucu_buton.enabled = false;
        bicak_saldiri_buton.enabled = false;
        yield return new WaitForSeconds(1.5f);
        reloadesei_sniper.SetActive(false);
        Reload_button.enabled = true;
        mermi_Sayisi = 12f;
        atesetme_button.enabled = true;
        sniper_anim.SetBool("Reload_sniper", false);
        sniper_anim.SetBool("�dle_sniper", true);
        slot_keles_buton.enabled = true;
        slot_pompali_buton.enabled = true;
        slot_sniper_buton.enabled = true;
        slot_susturucu_buton.enabled = true;
        bicak_saldiri_buton.enabled = true; 
    }

    IEnumerator muzzle_flash_control()
    {
        muzzleflash_sniper.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleflash_sniper.SetActive(false);
    }

    void AtesMekanigi()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 25f))
        {
            Debug.Log(hit.transform.name);

            dusman_anim = hit.transform.gameObject.GetComponent<Animator>();
            defender_ai = hit.transform.gameObject.GetComponent<DefenderAi>();

            GameObject mermi_izi = Instantiate(mermiizi_sniper, hit.point, Quaternion.LookRotation(hit.normal));

            #region mermi izi siler 
            Destroy(mermi_izi, 2f);
            #endregion

            if (hit.transform.gameObject.tag == "ct" && spawn_manager.terorist_Secildi == true)
            {
                StartCoroutine("dusman_hit_aldi_ct");
                defender_ai.CanAzalt(80);
            }
        }
    }

    public void recoil()
    {
        float recX = Random.Range(minX, maxX);
        float recY = Random.Range(minY, maxY);
        camera_fps.transform.localRotation = Quaternion.Euler(rot.x - recY, rot.y + recX, rot.z);
    }

    IEnumerator dusman_hit_aldi_ct()
    {
        hit_sound.SetActive(true);
        dusman_anim.SetBool("hit", true);
        crosshair_image.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        crosshair_image.color = Color.green;
        dusman_anim.SetBool("hit", false);
        hit_sound.SetActive(false);
    }
}
