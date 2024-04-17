using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class loadingscreenscene : MonoBehaviour
{
    
    void Start()
    {
        Invoke("Loading_Sceene_Kapatma", 3f);
    }

    public void Loading_Sceene_Kapatma()
    {
        SceneManager.LoadScene("UÝ");
    }

    
    
}
