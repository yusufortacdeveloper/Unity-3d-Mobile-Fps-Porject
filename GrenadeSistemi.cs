using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSistemi : MonoBehaviour
{

    public GameObject patlama_efekti;
    public float gecikme_suresi = 2f;

    public float patlama_gucu = 10f;
    public float genislik = 20f;

   

    void Start()
    {
        Invoke("Patlama", gecikme_suresi);
    }

    public void Patlama()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, genislik);

        foreach(Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();

            if(rig != null)
            {
                rig.AddExplosionForce(patlama_gucu, transform.position, genislik, 1f, ForceMode.Impulse);
            }
        }

       
        Instantiate(patlama_efekti, transform.position, transform.rotation);
        Destroy(gameObject);

    }

   
   
}
