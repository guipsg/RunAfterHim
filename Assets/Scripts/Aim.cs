using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    [SerializeField] float speed;

    SpriteRenderer sprtR;

    [SerializeField] float force;
    float direcX;
    float direcY;

    bool pressed;

    Vector2 startPoint;
    Vector2 moveDelta;

    public Transform myPos;
    public Transform player;

    public GameObject kunai;
    public GameObject kunaiGun;

    void Start()
    {
        sprtR = GetComponent<SpriteRenderer>();
        sprtR.enabled = false;
    }

    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressed = true;
            sprtR.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            sprtR.enabled = false;
            pressed = false;
            GameObject ball;
            ball = Instantiate(kunai, kunaiGun.transform.position, kunaiGun.transform.rotation);
            ball.GetComponent<Rigidbody2D>().AddForce(moveDelta.normalized * force);
        }

        startPoint = kunaiGun.transform.position;
        moveDelta = (Vector2)transform.position - startPoint;

        if (pressed)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;

            print(pos - player.position);

            Vector2 distanceToMouse = pos - player.position;

            if (distanceToMouse.x >= 0 && distanceToMouse.y >= 0)
            {
                transform.position = pos;
            }

        } else
        {
            transform.position = myPos.position;
        }
    }
}
