using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FakeForeground : MonoBehaviour
{
    private Tilemap sr;
    [SerializeField] [Range(0,1f)]
    private float lerptime;
    [SerializeField] private float transparency = 0.3f;
    private void Start()
    {
        sr = GetComponent<Tilemap>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color newColor = new Color(sr.color.r, sr.color.g, sr.color.b, transparency);
            sr.color = Color.Lerp(sr.color, newColor,lerptime);
        }
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        Color newColor = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
    //        sr.color = Color.Lerp(sr.color, newColor, 2f);
    //    }
    //}
}
