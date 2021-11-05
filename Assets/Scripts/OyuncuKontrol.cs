using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrol : MonoBehaviour
{
    public Transform mermipos;
    public GameObject mermi;
    public GameObject patlama;
    void Start()
    {
      
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject go = Instantiate(mermi, mermipos.position, mermipos.rotation);
            go.GetComponent<Rigidbody>().velocity = mermipos.transform.forward *10f;
            Destroy(go.gameObject,3f);
            //Vector3 kuvvet = Vector3.forward;  // Scriptin bulunduðu objenin vektorunu aldýðý için istediðimiz yönde ilerlemez.
            //go.GetComponent<Rigidbody>().AddForce(kuvvet * 500f);
            GameObject gopatlama = Instantiate(patlama, mermipos.position, mermipos.rotation);
            Destroy(gopatlama, 2f);

        }

    }
}
