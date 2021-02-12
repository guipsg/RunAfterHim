using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour {

    public int health = 2;
    public RespawnScene rs;
    void Update() {
        if (health <= 0)
	    {
            Destroy(gameObject);
            rs.RespawnPlayer();
	    }

    }
}
