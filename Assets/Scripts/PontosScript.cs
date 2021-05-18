using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontosScript : MonoBehaviour {

    [SerializeField] private int _points;

    public int points
    {
        get { return _points; }
        set { _points = value; }
    }
    [SerializeField] private Text pointsText;
    private void Update()
    {
        pointsText.text = (""+points);
    }

}
