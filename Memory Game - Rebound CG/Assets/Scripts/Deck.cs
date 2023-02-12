using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Deck : MonoBehaviour
{
    #region Variables
    private BoardManager boardManager;

    public List<CardData> cardDataList { get { return _cardDataList; } private set { } }
    [SerializeField] private List<CardData> _cardDataList; // Variable that contain every types of card

    private List<CardData> mainDeck = new List<CardData>(); // Variable that contain all the cards
    #endregion


    #region Update
    void Start()
    {
        boardManager = GetComponent<BoardManager>();

        DeckInitialisation();

    }
    #endregion


    #region Methods
    private void DeckInitialisation() // Fill the mainDeck with all the types of card (x2)
    {
        
        for (int i = 0; i < 2; i++)
        {
            cardDataList.ForEach(x => mainDeck.Add(x));
        }

        DeckShuffled();

    }

    private void DeckShuffled() // Deck Shuffled method based on the Fisher-Yates shuffle method
    {
        System.Random rng = new System.Random();

        int n = mainDeck.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var value = mainDeck[k];
            mainDeck[k] = mainDeck[n];
            mainDeck[n] = value;
        }

        boardManager.BoardInitialisation(mainDeck);
        GameManager.instance.deck = mainDeck;
    }
    #endregion
}
