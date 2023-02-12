using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform scoreUI;
    List<float> scores;
    #endregion


    #region Update
    private void Start()
    {
        SortTimers();

        for (int i = 0; i < scores.Count; i++) // Display on the player times in order
        {
            scoreUI.GetChild(i).GetComponent<Text>().text = $"{i+1}: " + Timer.instance.TimeDisplay(scores[i]);
        }
    }
    #endregion


    #region Method
    private void SortTimers() // Sort all the player times
    {
        scores = SaveSystem.scores;
        scores.Sort();

        if (scores.Count > 5) // Remove time that are not in the top 5
        {
            scores.RemoveAt(scores.Count - 1);
        }
    }
    #endregion
}
