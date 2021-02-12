using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoFake : MonoBehaviour {

    public GameObject chaofalso;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }

}


