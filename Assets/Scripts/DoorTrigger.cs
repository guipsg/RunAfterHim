using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    // Use this for initialization
    [SerializeField] private DoorScript door;
    [SerializeField] private Animator an;
	[SerializeField] private GameObject particle;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Ball")
        {
            door.DoorOpens();
            an.SetBool("isOn", true);
			Instantiate (particle, transform.position, particle.transform.rotation);
        }
    }

  

   


}
