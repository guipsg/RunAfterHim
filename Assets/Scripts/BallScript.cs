using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

  void OnCollisionEnter2D(Collision2D collision)
  {
        Destroy(gameObject,0.2f);
  }
}
