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
        Cursor.visible = true; //Ekranda mouse g�z�kmesini sa�lar.
        puan.text ="Puan�n�z : " + PlayerPrefs.GetInt("puan"); // sakl� olan puan textine eri�memizi sa�l�cak.
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
