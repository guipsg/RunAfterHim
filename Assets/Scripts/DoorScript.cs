using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {
    float velocity = 0f;
    public float vel;
    public float time;
    public float timeleft;
    bool isOpen;

    private void Update()
    {
        transform.Translate(Vector2.up * velocity * Time.deltaTime);

        if (isOpen)
        {

            timeleft -= Time.deltaTime;
            if (timeleft <= 0f)
            {
                DoorCloses();
                velocity = 0;
            }
        }
    }
    public void DoorOpens()
    {
        timeleft = time;
        velocity = vel;
        isOpen = true;
    }

    public void DoorCloses()
    {
        velocity = 0;
    }



}