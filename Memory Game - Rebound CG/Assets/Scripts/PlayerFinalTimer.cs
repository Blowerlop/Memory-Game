using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerFinalTimer : MonoBehaviour
{
    #region Variable
    public Text text { get; private set; }
    #endregion


    #region Update
    private void Start()
    {
        text = GetComponent<Text>();
        float finalTimer = Timer.instance.timer;

        text.text = Timer.instance.TimeDisplay(finalTimer); //  Display the player's victory time

        SaveSystem.SaveScore(finalTimer); //  Save the player's victory time to have a scorebord
    }
    #endregion
}
