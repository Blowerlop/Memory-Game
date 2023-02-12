using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Variables
    public static Timer instance;

    public float timer { get; private set; } = 0.0f;
    private Text timerText;
    #endregion


    #region Updates
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timerText = GetComponent<Text>();
    }

    private void Update()
    {

        timer += Time.deltaTime; // Count the time
        timerText.text = TimeDisplay(timer);
    }
    #endregion


    #region Methods
    public string TimeDisplay(float timer)  // Display the counted time 
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);

        return Format(minutes, seconds);
    }

    public string Format(float minutes, float seconds) // Convert raw timer into "mm:ss" string format
    {
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    #endregion
}
