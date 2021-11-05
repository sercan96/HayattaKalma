using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Navigasyonu eklememiz gerekir.

public class ZombieHareket : MonoBehaviour
{
    private GameObject oyuncu; // Takip edilecek obje
    void Start()
    {
        oyuncu = GameObject.Find("Oyuncu");
    }

    
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;  // Oyuncu objemin posizyonuna göre hareket edecek.
    }
}
