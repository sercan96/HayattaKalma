using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyuncuKontrol : MonoBehaviour
{
    public AudioClip atisSesi,olmeSesi,canAlmaSesi,yaralanmaSesi;
    public Transform mermipos;
    public GameObject mermi;
    public GameObject duman;
    public Image CanImaji;
    private float candegeri = 100f;
    public ZombieHareket kalp;
    public oyunControl okontrol;
    private AudioSource aSource;
    
   
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }  
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {   
             GameObject go = Instantiate(mermi, mermipos.position, mermipos.rotation);
             go.GetComponent<Rigidbody>().velocity = mermipos.transform.forward * 20f;
             Destroy(go.gameObject, 2f);
             //Vector3 kuvvet = Vector3.forward;  // Scriptin bulunduðu objenin vektorunu aldýðý için istediðimiz yönde ilerlemez.
             //go.GetComponent<Rigidbody>().AddForce(kuvvet * 500f);

             GameObject dumanPos = Instantiate(duman, mermipos.position, mermipos.rotation);
             Destroy(dumanPos.gameObject, 2f);

            aSource.PlayOneShot(atisSesi, 10f);
        }
 

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("zombi"))
        {
            aSource.PlayOneShot(yaralanmaSesi, 1f);
            candegeri -= 5f;
            CanImaji.fillAmount = candegeri / 100f; //Caný azalt.
            CanImaji.color = Color.Lerp(Color.red, Color.green, candegeri / 100f); // Can azaldýkça rengi yeþilden kýrmýzýya dönsün.
            if(candegeri <= 0)
            {
                aSource.PlayOneShot(olmeSesi, 4f); 
                okontrol.OyunBitti();
                SceneManager.LoadScene("OyunBitti");
            }
           
        }
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("kalp"))
        {
            aSource.PlayOneShot(canAlmaSesi, 5f);
            candegeri += 10f;
            CanImaji.fillAmount = candegeri / 100f; //Caný azalt.
            CanImaji.color = Color.Lerp(Color.red, Color.green, candegeri / 100f);
            Destroy(other.gameObject);
        }
    }
    






}
