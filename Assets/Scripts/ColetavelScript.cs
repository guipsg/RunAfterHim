using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetavelScript : MonoBehaviour {

    [SerializeField] private PontosScript pt;
    [SerializeField] private GameObject particle;
    [SerializeField] private List<GameObject> starsCollectables;

    private void Start()
    {
        pt = FindObjectOfType<PontosScript>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Item"))
        {
            Destroy(col.gameObject);
			Instantiate (particle, col.transform.position, col.transform.rotation);
            pt.points += 1000;
            foreach (GameObject star in starsCollectables)
            {
                if (star == col.gameObject)
                {
                    pt.UnlockStar(starsCollectables.IndexOf(star));
                }
            }
        }
    }
}
