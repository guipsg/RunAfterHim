using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetavelScript : MonoBehaviour {

    [SerializeField] private PontosScript pt;
    [SerializeField] private GameObject particle;

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
