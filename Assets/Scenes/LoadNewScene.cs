using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Make sure to add this, or you can't use SceneManager
using UnityEngine.SceneManagement;


public class LoadNewScene : MonoBehaviour
{
    public int SceneNum = 1;
    public GameObject UIE;

    void OnTriggerEnter(Collider other)
    {
        UIManager Manager = UIE.GetComponent<UIManager>();
        //other.name should equal the root of your Player object
        if (other.tag == "Player" || other.tag == "SmallBug")
        {
            SceneManager.LoadScene(1);
            //The scene number to load (in File->Build Settings)
            if (Manager.BuildingsCrushed > 50)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}