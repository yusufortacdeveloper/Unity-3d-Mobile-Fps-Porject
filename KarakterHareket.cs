using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarakterHareket : MonoBehaviour
{

    public CharacterController controller;

    public float hiz = 12f;
    public float yercekimi = -9.81f;
    public float ziplama_yuksekligi = 3f;

    Vector3 velocity;

    public Transform zemin_algilayici; // zemini algýlasýn diye playerin en altýna koydugumuz bir game object
    public float zemineMesafe = 0.4f; // zemýný algýlayan obje ýle karakter arasýndaki mesafe ölçüsü 
    public LayerMask zemin_Mask; // layer mask tanýmladýk. Bu sayede layeri zemin olan objelere eriþebiliyoruz
    bool zemine_Degdi; // zemine deðip deðmediðini kontrol ediyoruz. Bu sayede zýplama fonksiyonunu çalýþtýrýyoruz

    public FixedJoystick joystick_hareket; // karakter hareketi için gerekli olan joystick
    public Image joystickhareket_handle; // karakter kostugunu belirtsin diye joystiðin handle' ý 

    // stamina 

    [Range(0,30)]
    public float stamina;

    public float maX_Stamina;

    public Slider stamina_bar;
    public float dValue;

    public bool Silah_Tetiklendi; // bu boolean yururken ates etmeye bastýðýmýzda anýmasyonlarý kontrol eder 

    // sesler 

    public GameObject yurumesesi_player;
    public GameObject ziplamasesi_player;
    public GameObject kosmasesi_player;

    // tabanca el ile alakalý componentler burda

    public Animator tabancael_anim,pompaliel_anim,sniperel_anim,bicakel_anim;
    
    
   

    void Start()
    {
        maX_Stamina = stamina;
        maX_Stamina = 30f; 
        stamina_bar.maxValue = maX_Stamina;
        stamina_bar.minValue = 0f;

        Silah_Tetiklendi = false; 
       
    }

    // Update is called once per frame
    void Update()
    {
        maX_Stamina = 30f;

        joystickhareket_handle.color = Color.white;

        zemine_Degdi = Physics.CheckSphere(zemin_algilayici.position, zemineMesafe, zemin_Mask); 

        if(zemine_Degdi && velocity.y < 0)
        {
            velocity.y = -2f; 
        }


        float x = joystick_hareket.Horizontal;
        float z = joystick_hareket.Vertical;

        Vector3 hareket = transform.right * x + transform.forward * z;

        controller.Move(hareket * hiz * Time.deltaTime);

        velocity.y += yercekimi * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    
        if(Input.GetButtonDown("Jump") && zemine_Degdi)
        {
            velocity.y = Mathf.Sqrt(ziplama_yuksekligi * -2f * yercekimi);
        }

        #region kosma
        

        if(joystick_hareket.Horizontal >= 0.8f || joystick_hareket.Horizontal <= -0.8f || joystick_hareket.Vertical <= -0.8f || joystick_hareket.Vertical >= 0.8f)
        {
            joystickhareket_handle.color = Color.red;
            kosmasesi_player.SetActive(true);
            yurumesesi_player.SetActive(false);
            Stamina_Azaltma();
        }
        else if (stamina != maX_Stamina)
        {
            kosmasesi_player.SetActive(false);
            hiz = 5f; 
            Stamina_Arttýrma();
        }

        if(joystick_hareket.Horizontal != 0 && Silah_Tetiklendi != true || joystick_hareket.Vertical != 0 && Silah_Tetiklendi != true)
        {
            yurumesesi_player.SetActive(true);


            
                #region silah yurume animleri
                tabancael_anim.SetBool("idle", true);
                tabancael_anim.SetBool("yurume_susturucu", true);
                pompaliel_anim.SetBool("Ýdle_pompali", true);
                pompaliel_anim.SetBool("Hareket_pompali", true);
                sniperel_anim.SetBool("Ýdle_sniper", true);
                sniperel_anim.SetBool("Hareket_sniper", true);
                bicakel_anim.SetBool("Ýdle_bicak", true);
                bicakel_anim.SetBool("Hareket_bicak", true);
                #endregion
           

        }
        else if (Silah_Tetiklendi == true)
        {
            //tabancael_anim.SetBool("yurume_susturucu", false);
            //pompaliel_anim.SetBool("Hareket_pompali", false);
            //sniperel_anim.SetBool("Hareket_sniper", false);
            //bicakel_anim.SetBool("Hareket_bicak", false);
            
            yurumesesi_player.SetActive(false);

            #region silah yurume animleri
            tabancael_anim.SetBool("idle", true);
            tabancael_anim.SetBool("yurume_susturucu", false);
            pompaliel_anim.SetBool("Ýdle_pompali", true);
            pompaliel_anim.SetBool("Hareket_pompali", false);
            sniperel_anim.SetBool("Ýdle_sniper", true);
            sniperel_anim.SetBool("Hareket_sniper", false);
            bicakel_anim.SetBool("Ýdle_bicak", true);
            bicakel_anim.SetBool("Hareket_bicak", false);
            #endregion
        }
        else
        {
            tabancael_anim.SetBool("yurume_susturucu", false);
            pompaliel_anim.SetBool("Hareket_pompali", false);
            sniperel_anim.SetBool("Hareket_sniper", false);
            bicakel_anim.SetBool("Hareket_bicak", false);

            yurumesesi_player.SetActive(false);
        }


        stamina_bar.value = stamina;

       
        #endregion

    }

   
    public void Jump()
    {
        if (zemine_Degdi)
        {
            velocity.y = Mathf.Sqrt(ziplama_yuksekligi * -2f * yercekimi);
            StartCoroutine("ziplamasound");
        }
    }

   public void Stamina_Azaltma()
    {
        if(stamina != 0)
        {
            hiz = 8f;
            stamina -= dValue * Time.deltaTime*0.5f;
        }
        else
        {
            stamina = 0f;
            kosmasesi_player.SetActive(false);
        }
    }

    public void Stamina_Arttýrma()
    {
        stamina += dValue * Time.deltaTime*0.5f;
    }

    public void FixedUpdate()
    {
        if (stamina >= 30f)
        {
            stamina = 30f;
        }
        else if (stamina <= 0)
        {
            stamina = 0f;
            joystickhareket_handle.color = Color.magenta;
            hiz = 5f;
        }
    }

    IEnumerator ziplamasound()
    {
        ziplamasesi_player.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        ziplamasesi_player.SetActive(false);
    }

}
