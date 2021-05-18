using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript1 : MonoBehaviour {

    [SerializeField] private Rigidbody2D rb;
    private void Start()
    {
        rb.gravityScale = 0;
    }


    public void DoorDrop(){
        rb.gravityScale = 1;
    }


}