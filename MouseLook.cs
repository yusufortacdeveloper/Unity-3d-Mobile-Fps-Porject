using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public float MouseHassasiyet = 100f; // kameram�za hassasiyet tan�mlad�k

    public FloatingJoystick joystick_look; // kameram�z�n bak�� hareketi i�in gerekli joystick

    public Transform karakter_Vucudu; // kameram�zla beraber karakterin v�dunun d�nmesini sa�lad�k

    float xRotation = 0f; // 
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked; // mouse g�r�n�rl���n� kilitledik yani durdurduk 
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = joystick_look.Horizontal * MouseHassasiyet * Time.deltaTime; // farenin x kordinat�ndaki verileri tuttuk
        float mouseY = joystick_look.Vertical * MouseHassasiyet * Time.deltaTime; // farenin y kordinat�ndaki verileri tuttuk 

        xRotation -= mouseY; // xRotation de�erimizi mouseY den ��kar�lmas�na e�itledik
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // yukar� ve a�a�� bakarken xRotation de�erimizi -90 ile 90 de�erleri aras�nda kelep�eledim yani s�n�rland�rd�m 

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // transformumuzun local rotasyonunu ayarlad�m

        karakter_Vucudu.Rotate(Vector3.up * mouseX); // karakterin v�cudunun d�nmesini sa�lad�m 

    }
}
