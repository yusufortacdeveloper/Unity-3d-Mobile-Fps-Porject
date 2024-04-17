using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public float MouseHassasiyet = 100f; // kameramýza hassasiyet tanýmladýk

    public FloatingJoystick joystick_look; // kameramýzýn bakýþ hareketi için gerekli joystick

    public Transform karakter_Vucudu; // kameramýzla beraber karakterin vüdunun dönmesini saðladýk

    float xRotation = 0f; // 
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; // mouse görünürlüðünü kilitledik yani durdurduk 
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = joystick_look.Horizontal * MouseHassasiyet * Time.deltaTime; // farenin x kordinatýndaki verileri tuttuk
        float mouseY = joystick_look.Vertical * MouseHassasiyet * Time.deltaTime; // farenin y kordinatýndaki verileri tuttuk 

        xRotation -= mouseY; // xRotation deðerimizi mouseY den çýkarýlmasýna eþitledik
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // yukarý ve aþaðý bakarken xRotation deðerimizi -90 ile 90 deðerleri arasýnda kelepçeledim yani sýnýrlandýrdým 

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // transformumuzun local rotasyonunu ayarladým

        karakter_Vucudu.Rotate(Vector3.up * mouseX); // karakterin vücudunun dönmesini saðladým 

    }
}
