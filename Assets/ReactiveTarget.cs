using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public float rHealth = 5f;
    public float DamageRate = 0.5f;
     public GameObject Pcam;
    public void ReactToHit()
    { 
        StartCoroutine(Hit());
    }

    private IEnumerator Hit()
    {
        if (rHealth < 0)
        {
            this.transform.rotation = new Quaternion(0, -158, 0, 0);
            this.transform.localScale = new Vector3(-1, 0, 0);
            rHealth-=DamageRate;
        }
        else
        {
            yield return new WaitForSeconds(1.5f);

            Destroy(this.gameObject);
        }
    }
}
