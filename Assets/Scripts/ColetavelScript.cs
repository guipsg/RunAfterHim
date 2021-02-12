using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetavelScript : MonoBehaviour {

    public PontosScript pt;
	public GameObject particle;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Item"))
        {
            Destroy(col.gameObject);
			Instantiate (particle, col.transform.position, col.transform.rotation);
            pt.points += 1000;
        }
    }
}
