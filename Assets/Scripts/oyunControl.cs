using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oyunControl : MonoBehaviour
{
    public GameObject zombi;
    float zaman = 2f;
    float zamansayaci = 100;
    public Text zamansayacText;
    private int puan;  // private olursa bu deðiþkene baþka yerden eriþemeyiz.
    public Text puanText;
    
   

    void Start()
    {
        
    }

    
    void Update()
    {
        zamanSayacim();
        zaman -= Time.deltaTime;
        if (zaman <= 0)
        {
             Vector3 rastgele = new Vector3(Random.Range(185f, 322f), 28.1f, Random.Range(130f, 300f));
             Instantiate(zombi, rastgele, Quaternion.identity);
             zaman = 2f;
        }

    }
    public void zamanSayacim()
    {
        zamansayacText.text = "Kalan Sure : " + (int)zamansayaci;
        zamansayaci -= Time.deltaTime;
    }
    public void puanArttir(int p)
    {
        //puan += 10;  // public için
        puan += p;
        puanText.text = "Puan : " + puan;
    }
    public void OyunBitti()
    {
        PlayerPrefs.SetInt("puan", puan); // puaný sakla

    }
    
}
