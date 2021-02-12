using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private Management mg;

    void Start()
    {
        mg = GameObject.FindGameObjectWithTag("Manager").GetComponent<Management>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        mg.checkPoint = transform.position;

        }

    }
}
