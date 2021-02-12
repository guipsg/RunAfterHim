using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    // Use this for initialization
    public DoorScript door;
    public Animator an;
	public GameObject particle;

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
