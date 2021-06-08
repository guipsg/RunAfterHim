using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[SerializeField] private Transform player;

    [SerializeField] private float speed;
	[SerializeField] private float limitX;

    [SerializeField] private Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 playerPos = player.position + offset;
        playerPos.y = 0;

		Vector3 moveCam;
		Vector3 stopCam = new Vector3 (limitX, playerPos.y, playerPos.z);
		if (transform.position.x >= limitX) {
			moveCam = Vector3.Lerp(transform.position, stopCam, speed * Time.deltaTime);
		} else {
			moveCam = Vector3.Lerp(transform.position, playerPos, speed * Time.deltaTime);
		}

		transform.position = moveCam;
    }

}
