using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class SusturucuSaldiri : MonoBehaviour
{
    public GameObject susturucu_el; // susturucu el olan objenin kendisi
    public Animator susturucuel_anim; // susturucu elin animatoru

    // mermi sistemi 

    public float mermi_Sayisi = 12f; // baslang�ctaki mermi say�m�z� belirledik 
    public Button atesetme_button; // bu butonu tan�mlama amac�m: eger silah reload durumuna girerse mermi says�n�n azlmas�na engel olmakt�r
    public Button Reload_button;

    public Button slot_susturucu_buton, slot_sniper_buton, slot_pompali_buton, slot_keles_buton, bicak_saldiri_buton;

    public TextMeshProUGUI mermisayi_text; // bu bize ekranda ka� mermi kald���m�z� g�stericek 

    // ates sistemi gerekilenler

    public GameObject atessesi_tabanca;
    public GameObject reloadesei_tabanca; 
    public GameObject muzzleflash_tabanca;
    public GameObject mermifirlama_tabanca;
    public GameObject mermiizi_tabanca; // mermi efecti cal�st�r�r

    // ates sistemi mekanigi
    
    public float mesafe = 100f;
    public Camera fpsCam;

    // camera shake ( sallanma efekti )

    public CameraShake cameraShake; // bomba patlad�g�nda sallanma efekti icin yaz�ld�. Bombada sallanmas�n� istiyorsan kullan�caks�n 

    // recoil sistemi (silah ate�lendi�inde kameraya vurus hissiyat� katmak i�in yaz�lan koddur)

    public float minX, maxX;
    public float minY, maxY;
    public Transform camera_fps;
    public Vector3 rot;

    // karakter�n yurume koduna erisme 

    KarakterHareket player_Hareket;

    // dusmana hit ile alakali icerikler
    Animator dusman_anim;
    Level1SpawnManager spawn_manager;
    public GameObject hit_sound; // hasar verme sesi 
    public Image crosshair_image;
    DefenderAi defender_ai;

    public void Susturucuel_Ates()
    {
        AtesMekanigi();
        recoil();
        StartCoroutine("muzzle_flash_control");
        StartCoroutine("atesetme"); // bu fonksiyon bize ates etme butonuna t�klad�g�m�zda ates etmey� saglar 
    }

    public void Susturucu_Reload()
    {
        if(mermi_Sayisi < 12)
        {
            StartCoroutine("reload"); // bu fonksiyon bize silah�n reload durumuna girmesini saglar 
        }
    }

    public void Start()
    {
        PlayerPrefs.GetFloat("tabanca_mermi");

        player_Hareket = GameObject.Find("Player").GetComponent<KarakterHareket>();
        spawn_manager = GameObject.Find("SpawnManager").GetComponent<Level1SpawnManager>();
    }

    public void Update()
    {
        PlayerPrefs.SetFloat("tabanca_mermi", mermi_Sayisi); // tabanca mermisini kay�t ettik

        mermisayi_text.text = PlayerPrefs.GetFloat("tabanca_mermi") + "" + "/" + "" + "999"; // ana sayfada kalan mermi say�m�z� g�sterdik 

        #region oto_reload 
        if (mermi_Sayisi <= 0) // bu blok bize mermi 0 dan d���k oldugunda oto reload etmesini sa�lar
        {
            StartCoroutine("reload");
        }
        #endregion


        #region recoil efekt hesaplamalari // recoil efektleri

        rot = camera_fps.transform.localRotation.eulerAngles; // recoil efekt i�in kameran�n rotasyonunu kaydettik

        if(rot.x != 0 ||rot.y != 0)
        {
            camera_fps.transform.localRotation = Quaternion.Slerp(camera_fps.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 3); // bu kod recoil olduktan sonra kameran�n yavas tavas asag� �nmes�n� saglar
        }

        #endregion


    }


    IEnumerator atesetme() // ates etme olaylar�n� bir numerator �le d�nd�rd�m
    {
        
        susturucuel_anim.SetBool("idle", true);
        susturucuel_anim.SetBool("ates_susturucu", true);
        atesetme_button.enabled = false; // ust uste t�klay�p an�masyon cak�smas�n� engellemek istedim
        player_Hareket.Silah_Tetiklendi = true;
        mermifirlama_tabanca.SetActive(true);
        atessesi_tabanca.SetActive(true);
        mermi_Sayisi--;
        yield return new WaitForSeconds(0.4f);
        player_Hareket.Silah_Tetiklendi = false;
        mermifirlama_tabanca.SetActive(false);
        atessesi_tabanca.SetActive(false);
        atesetme_button.enabled = true; // butonu tekrardan aktifle�tirerek s�kabilmesini sa�lad�m 
        susturucuel_anim.SetBool("ates_susturucu", false);
    }

    IEnumerator reload() // reload olaylar�n� bir numerator ile d�nd�rd�m
    {
        susturucuel_anim.SetBool("idle", true);
        susturucuel_anim.SetBool("ates_susturucu", false);
        susturucuel_anim.SetBool("reload_susturucu", true);
        atesetme_button.enabled = false;
        Reload_button.enabled = false; 
        mermi_Sayisi = 0f;
        reloadesei_tabanca.SetActive(true);
        slot_keles_buton.enabled = false;
        slot_pompali_buton.enabled = false;
        slot_sniper_buton.enabled = false;
        slot_susturucu_buton.enabled = false;
        bicak_saldiri_buton.enabled = false;
        yield return new WaitForSeconds(1.6f);
        reloadesei_tabanca.SetActive(false);
        Reload_button.enabled = true;
        mermi_Sayisi = 12f;
        atesetme_button.enabled = true;
        susturucuel_anim.SetBool("reload_susturucu", false);
        slot_keles_buton.enabled = true;
        slot_pompali_buton.enabled = true;
        slot_sniper_buton.enabled = true;
        slot_susturucu_buton.enabled = true;
        bicak_saldiri_buton.enabled = true;

    }

    IEnumerator muzzle_flash_control()
    {
        muzzleflash_tabanca.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        muzzleflash_tabanca.SetActive(false);

    }

    void AtesMekanigi()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 50f))
        {
            Debug.Log(hit.transform.name);

            dusman_anim = hit.transform.gameObject.GetComponent<Animator>();
            defender_ai = hit.transform.gameObject.GetComponent<DefenderAi>();

            GameObject mermi_izi =   Instantiate(mermiizi_tabanca, hit.point, Quaternion.LookRotation(hit.normal));

            #region mermi izi siler 
            Destroy(mermi_izi, 2f);
            #endregion

            if (hit.transform.gameObject.tag == "ct" && spawn_manager.terorist_Secildi == true)
            {
                StartCoroutine("dusman_hit_aldi_ct");
                defender_ai.CanAzalt(20);
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
