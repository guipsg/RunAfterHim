using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowTime : MonoBehaviour
{
    [SerializeField] private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(delegate { TimeSlow(); });
    }

    public void TimeSlow()
    {
        button.interactable = false;
        StartCoroutine(TimeSlowCoroutine());
    }

    IEnumerator TimeSlowCoroutine()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(20f);
        button.interactable = true;
    }
}
