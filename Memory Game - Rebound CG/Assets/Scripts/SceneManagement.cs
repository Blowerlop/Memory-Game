using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public static class SceneManagement
{
    #region Variables
    public enum ESceneType
    {
        MainMenu,
        Intro,
        Game,
        EndMenu
    }

    public static ESceneType SceneType;
    #endregion


    #region Method
    public static void LoadScene(ESceneType SceneName)
    {
        SceneManager.LoadScene(SceneName.ToString());
    }
    #endregion
}


