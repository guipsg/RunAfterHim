using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger1 : MonoBehaviour {

    // Use this for initialization
    public DoorScript1 door;
    public Animator an;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Ball")
        {
            door.DoorDrop();
            an.SetBool("isOn", true);

        }
    }

  

   


}
