﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    public Transform SpawnTransform;
    public Transform GroundPos;
    public float Smooth;
    public float pushDistance;
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    public void Clicked()
    {
        StartCoroutine(Push());
        IEnumerator Push()
        {
            transform.position += new Vector3(pushDistance, 0, 0);
            yield return new WaitForSeconds(1.0f);
            transform.position -= new Vector3(pushDistance, 0, 0);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
