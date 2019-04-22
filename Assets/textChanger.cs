using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textChanger : MonoBehaviour
{
    public bool IsTalking;
    public Text Talking;
    public string Words = "Could you try to jump on the wall a couple a times.";
    public GameObject Player; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject == Player.gameObject)
        {
            IsTalking = !IsTalking;
            Talking.text = Words;
        }
    }
 }
