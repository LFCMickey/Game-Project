using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushBuilding : MonoBehaviour
{
    public GameObject Uie;
    private void OnCollisionEnter(Collision collision)
    {
        UIManager Manger = Uie.GetComponent<UIManager>();
        if(collision.gameObject.name.Contains("Building"))
        {
            collision.gameObject.layer = 10;
            print("here");
            collision.gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 10;
            Manger.BuildingsCrushed+=1;
        }
    }
}
