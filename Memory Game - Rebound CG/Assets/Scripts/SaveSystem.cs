using System.Collections.Generic;
using UnityEngine.UI;


public static class SaveSystem 
{
    #region Variable
    public static List<float> scores = new List<float>();
    #endregion


    #region Method
    public static void SaveScore(float times)
    {
        scores.Add(times);      
    }
    #endregion
}