using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 


public class Timer : MonoBehaviour
{
    [SerializeField] private int _simdikiZaman;
    [SerializeField] private int _DurationTime;
    [SerializeField] private TextMeshProUGUI _TimerText;

    public bool zaman_kontrol; 
    void Start()
    {
        zaman_kontrol = false; 
        _simdikiZaman = _DurationTime;
        _TimerText.text = _simdikiZaman.ToString();
        

    }

    public void LateUpdate()
    {
        StartCoroutine(ZamanAzalt());
    }

    private IEnumerator ZamanAzalt()
    {
        while(_simdikiZaman >= 0 && zaman_kontrol == true )
        {
            _TimerText.text = _simdikiZaman.ToString();
            yield return new WaitForSeconds(1f);
            _simdikiZaman -= 1;

           
        }

        yield return null; 
    }
    
}
