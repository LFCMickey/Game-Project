using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("TubeGround"))
        {
            //TakeDamage(2);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
