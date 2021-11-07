using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Navigasyonu eklememiz gerekir.

public class ZombieHareket : MonoBehaviour
{
    private GameObject oyuncu; // Takip edilecek obje
    private int ZombieCan = 3;
    private float mesafe;
    public GameObject kalpObjesi;
    private oyunControl oKontrol;
    private int zombidenGelenPuan = 10;
    private AudioSource aSource;
    private bool zombieOluyor = false;
    

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        oyuncu = GameObject.Find("Oyuncu");
        oKontrol = GameObject.Find("_Script").GetComponent<oyunControl>(); 
        
    }
    
    void Update()
    {
      
         GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;  // Oyuncu objemin posizyonuna göre hareket edecek.
         mesafe = Vector3.Distance(transform.position, oyuncu.transform.position); // Oyuncu ile zombinin aralarýndaki farký Vectör3 cinsinden mesafe adlý bir deðiþkene ata.
         if (mesafe < 10f)
         {
            if(!aSource.isPlaying)  //Ses çalýnmýyorsa çal.
            {
                aSource.Play(); // Eklenen sesi çal.
                if(!zombieOluyor)
                GetComponentInChildren<Animation>().Play("Zombie_Attack_01");  // Saldýrý animasyonu çalýþssýn.
            }
            else if (aSource.isPlaying)   // Ses çalýnýyorsa kapat.
            {
                aSource.Stop(); // Eklenen sesi çal.
                
            }
             

         }
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("mermi"))
        {
            ZombieCan -= 1;
            Destroy(collision.gameObject);
            if(ZombieCan == 0)
            {
                oKontrol.puanArttir(zombidenGelenPuan);  // private olduðu için fonksiyon içine deðiþken atadýk.
                //GetComponentInChildren<Animation>().Play("Zombie_Idle_01");  // Zombie öleceðinde bu animasyon çalýþssýn.
                Destroy(gameObject,1.2f);  // Animasyonun oynama süresi
                kalpolusturma();
                zombieOluyor = true;
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");  // Saldýrý animasyonu çalýþssýn.
            }
        }
        

    }

    public void kalpolusturma()
    {
        GameObject gokalp = Instantiate(kalpObjesi, transform.position, transform.rotation);
    }
    
}
