using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoFake : MonoBehaviour {

    [SerializeField] private GameObject chaofalso;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }

}


