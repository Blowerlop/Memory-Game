using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class BoardManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform board;
    [SerializeField] private Card cardPrefab;

    private List<CardData> mainDeck;
    #endregion


    #region Method
    public void BoardInitialisation(List<CardData> mainDeck)
    {
        this.mainDeck = mainDeck;

        for (int i = 0; i < mainDeck.Count; i++)
        {
            Card card = Instantiate(cardPrefab, board);
            card.cardData = this.mainDeck[i];
            card.GetComponent<Image>().sprite = card.cardData.back;
        }
        Destroy(board.GetComponent<GridLayoutGroup>(), 1); // To prevent cards of automatic reorganisation when they are destroyed
    }
    #endregion
}
