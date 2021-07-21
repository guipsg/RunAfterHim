using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour {

    [SerializeField] private int _health = 2;
    [SerializeField] private RespawnScene rs;
    [SerializeField] private PontosScript ps;
    public int health
    {
        get { return _health; }
        set { _health = value; }
    }
    void Update() {
        if (health <= 0)
	    {
            Destroy(gameObject);
            ps.ShowGameOver();
        }

    }
}
