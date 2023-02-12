using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Pointer : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    #region Variables
    [SerializeField] private Gameplay gameplay;
    [SerializeField] private GameObject outline;
    #endregion


    #region Update
    private void Start()
    {
        gameplay = GameObject.FindWithTag("Player").GetComponent<Gameplay>();
    }
    #endregion


    #region Methods
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameplay.canPlayerClick == false) { return; } // Can't click on cards while animating


        if (eventData.lastPress != null && gameplay.totalClicks >= 1) // Can't click on same cards twice
        {
            if (eventData.lastPress.GetComponent<Pointer>() == this) { return; }
        }

        gameplay.PlayerCliked(eventData, transform);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.SetActive(false);
    }
    #endregion
}
