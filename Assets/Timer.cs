using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool timerActive = false;
    public TMP_Text timerTxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive) {
            if (timeLeft > 0) {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
                // Delay();
            } else {
                Debug.Log("Time Is Up!");
                timeLeft = 0;
                timerActive = false;
            }
        }
    }

    public void updateTimer(float f) {
        f += 1;
        float mins = Mathf.FloorToInt(f / 60);
        float secs = Mathf.FloorToInt(f % 60);

        timerTxt.text = string.Format("{0:00}:{1:00}", mins, secs);
        
    }
    IEnumerator Delay() {
        yield return new WaitForSeconds(1 );
    }
}
