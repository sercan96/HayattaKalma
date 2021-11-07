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
      
         GetComponent<NavMeshAgent>().destination = oyuncu.transform.position;  // Oyuncu objemin posizyonuna g�re hareket edecek.
         mesafe = Vector3.Distance(transform.position, oyuncu.transform.position); // Oyuncu ile zombinin aralar�ndaki fark� Vect�r3 cinsinden mesafe adl� bir de�i�kene ata.
         if (mesafe < 10f)
         {
            if(!aSource.isPlaying)  //Ses �al�nm�yorsa �al.
            {
                aSource.Play(); // Eklenen sesi �al.
                if(!zombieOluyor)
                GetComponentInChildren<Animation>().Play("Zombie_Attack_01");  // Sald�r� animasyonu �al��ss�n.
            }
            else if (aSource.isPlaying)   // Ses �al�n�yorsa kapat.
            {
                aSource.Stop(); // Eklenen sesi �al.
                
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
                oKontrol.puanArttir(zombidenGelenPuan);  // private oldu�u i�in fonksiyon i�ine de�i�ken atad�k.
                //GetComponentInChildren<Animation>().Play("Zombie_Idle_01");  // Zombie �lece�inde bu animasyon �al��ss�n.
                Destroy(gameObject,1.2f);  // Animasyonun oynama s�resi
                kalpolusturma();
                zombieOluyor = true;
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");  // Sald�r� animasyonu �al��ss�n.
            }
        }
        

    }

    public void kalpolusturma()
    {
        GameObject gokalp = Instantiate(kalpObjesi, transform.position, transform.rotation);
    }
    
}
