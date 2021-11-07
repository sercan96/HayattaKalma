using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDonumu : MonoBehaviour
{
    public oyunControl ok;
    void Start()
    {
        
    }

    void Update()
    {
         transform.RotateAround(new Vector3(250f, 0f, 250f), Vector3.left, 50f * Time.deltaTime);  // ilk vektor dondurulecek rotasyon ikinici yönü üçüncü kýsým ise hýzý

    }
  
}
