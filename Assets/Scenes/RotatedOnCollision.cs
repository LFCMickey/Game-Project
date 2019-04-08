using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatedOnCollision : MonoBehaviour
{
    public bool Rotated = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("2");
       // transform.rotation = new Quaternion(90, 90, 90, 0);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("2");
        if (collision.gameObject.tag == ("Electric"))
        {
            Debug.Log("hit");
            Rotated = true;
            transform.rotation = new Quaternion(0, 180, 180, 0);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
