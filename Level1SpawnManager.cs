using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1SpawnManager : MonoBehaviour
{
    public GameObject t_spawn_point, ct_spawn_point;

    public GameObject map_cam_genel; 

    public GameObject canvas_secim, canvas_genel;

    public GameObject karakter;

    public GameObject[] defender_Ai;

    public GameObject baslangic_music;

    public bool terorist_Secildi; 

    Vector3 t_Spawn_point_vec,ct_Spawn_point_vec;

    public Timer TÝMER; 
    
    public void Awake()
    {
        defender_Ai[0].SetActive(false);
        defender_Ai[1].SetActive(false);
        defender_Ai[2].SetActive(false);
        defender_Ai[3].SetActive(false);


        baslangic_music.SetActive(true);

        canvas_secim.SetActive(true);
        canvas_genel.SetActive(false);
        map_cam_genel.SetActive(true);
        karakter.SetActive(false);
        t_Spawn_point_vec = t_spawn_point.transform.position;
        ct_Spawn_point_vec = ct_spawn_point.transform.position; 
    }

    public void defender_secim()
    {
        map_cam_genel.SetActive(false);
        canvas_secim.SetActive(false);
        canvas_genel.SetActive(true);
        Time.timeScale = 1;
        karakter.transform.position = ct_Spawn_point_vec;
        karakter.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        karakter.SetActive(true);

        baslangic_music.SetActive(false);

        defender_Ai[0].SetActive(true);
        defender_Ai[1].SetActive(true);
        defender_Ai[2].SetActive(true);
        defender_Ai[3].SetActive(false);

        terorist_Secildi = false;
        TÝMER.zaman_kontrol = true;

    }

    public void attacker_secim()
    {
        map_cam_genel.SetActive(false);
        canvas_secim.SetActive(false);
        canvas_genel.SetActive(true);
        Time.timeScale = 1;
        karakter.transform.position = t_Spawn_point_vec;
        karakter.SetActive(true);

        baslangic_music.SetActive(false);

        defender_Ai[0].SetActive(true);
        defender_Ai[1].SetActive(true);
        defender_Ai[2].SetActive(true);
        defender_Ai[3].SetActive(true);

        terorist_Secildi = true;
        TÝMER.zaman_kontrol = true;

    }

    void Update()
    {
        
    }
}
