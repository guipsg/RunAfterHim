using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger1 : MonoBehaviour {

    [SerializeField] private DoorScript1 door;
    [SerializeField] private Animator an;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Ball")
        {
            door.DoorDrop();
            an.SetBool("isOn", true);

        }
    }

  

   


}
