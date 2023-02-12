using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;

    [SerializeField] private GameObject playerPrefab;
    [HideInInspector] public List<CardData> deck;
    #endregion


    #region Updates
    private void Awake()
    {
        // Singleton instanciation 
        if (instance != null)
        {
            Debug.Log($"Plus d'une instance de {this} !");
            return;
        }

        instance = this;
    }

    private void Start()
    {
        Instantiate(playerPrefab);
    }
    #endregion


    #region Methods
    #region NavigateThrewScenes
    public void MainMenu()
    {
        SceneManagement.LoadScene(SceneManagement.ESceneType.MainMenu);
    }

    public void StartIntro()
    {
        SceneManagement.LoadScene(SceneManagement.ESceneType.Intro);
    }

    public void StartGame()
    {
        SceneManagement.LoadScene(SceneManagement.ESceneType.Game);
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void PlayerVictory()
    {
        SceneManagement.LoadScene(SceneManagement.ESceneType.EndMenu);
    }
    #endregion
    #endregion
}
