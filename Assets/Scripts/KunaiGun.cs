using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiGun : MonoBehaviour {



	public GameObject crosshair;

	void Awake () {
    }

    // Update is called once per frame
    void Update() {

		Vector3 pos = crosshair.transform.position;
		Vector3 dir = pos - transform.position;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}
}
