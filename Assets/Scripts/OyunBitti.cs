using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunBitti : MonoBehaviour
{
    public Text puan;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; //Ekranda mouse gözükmesini saðlar.
        puan.text ="Puanýnýz : " + PlayerPrefs.GetInt("puan"); // saklý olan puan textine eriþmemizi saðlýcak.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void YenidenOyna()
    {
        SceneManager.LoadScene("Oyun");
    }
}
