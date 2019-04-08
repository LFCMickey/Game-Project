﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mount : MonoBehaviour
{

    public GameObject player;
    public bool SmallBugMounted = false;
    public bool isGrounded;
    public float Shrink =0.2f;
    public float Grow = 1.0f;
    public float jumpForce = 250;
    public float speed = 350;
    public GameObject SmallBug;
    public GameObject UIE;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (SmallBugMounted)
        {
            Movement Pmotion = player.GetComponent<Movement>();
            UIManager Manage = UIE.GetComponent<UIManager>();
            Pmotion.speed = (350 + Manage.SpeedBought);
            print(Pmotion.speed);
            if (Input.GetKey("space"))
            {
               // Rigidbody brb = GetComponent<Rigidbody>();
               // brb.AddForce(transform.up * jumpForce);
            }
        }
        if (Input.GetKeyDown("e"))
        {
            if (gameObject.tag == "SmallBug")
            {
                if (isGrounded == false)
                {
                    if (transform.parent != null)
                    {
                        transform.parent = null;
                        SmallBugMounted = false;
                        player.transform.localScale = new Vector3(Grow, Grow, Grow);
                        player.transform.position = SmallBug.transform.position;
                    }
                }
            }
        }
        if (Input.GetKey("r"))
        {
            if (gameObject.tag == "SmallBug")
            {
                transform.rotation = player.transform.rotation;
            }
        }

    }
    public void mount(GameObject Target, GameObject Player)
    {
        player = Player;
        SmallBug = Target;
        if (gameObject.tag == "Player")
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.localScale = new Vector3(Shrink-1, Shrink-1, Shrink-1);
            transform.position = Target.transform.position + new Vector3(0, 1, 0);
            print("im here");
        }
        if (gameObject.tag == "SmallBug")
        {

            transform.parent = Player.transform;
            PopulateSprites Stickers = UIE.GetComponent<PopulateSprites>();
            Stickers.HasSeenSmallBug = true;
            print(Stickers.HasSeenSmallBug);
            Rigidbody brb = GetComponent<Rigidbody>();
            Rigidbody Prb = Player.GetComponent<Rigidbody>();
            SmallBugMounted = true;
            brb = Prb;
            brb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("TubeGround"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == ("TubeGround"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == ("TubeGround"))
        {
            isGrounded = false;
        }
    }
}