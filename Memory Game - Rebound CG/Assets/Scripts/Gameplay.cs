using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class Gameplay : MonoBehaviour
{
    #region Variables
    [Header("Roration DoTween")]
    [SerializeField] private float roration90Duration = 0.25f;
    [SerializeField] private float rotation270Duration = 0.5f;
    [Space(10)]

    [Header("Shake DoTween")]
    [SerializeField] private float shakeForce = 15.0f;
    [SerializeField] private float shakeDuration = 1.0f;
    [Space(10)]

    [Header("Scake DoTween")]
    [SerializeField] private float scaleForce = 1.5f;
    [SerializeField] private float scaleDuration = 1.0f;
    [Space(10)]


    [SerializeField] private Deck deck;
    public int totalClicks { get; private set; }  = 0;

    private Transform lastPressGameObject;
    private Transform clickedGameObject;

    public bool canPlayerClick { get; private set; } = true;

    [SerializeField] private AudioClip cardFlipSound;
    #endregion


    #region Methods
    public void PlayerCliked(PointerEventData eventData, Transform clickedGameObject)
    {
        // Get the two cards with current and last one 
        lastPressGameObject = eventData.lastPress == null ? lastPressGameObject = null : lastPressGameObject = eventData.lastPress.transform;
        this.clickedGameObject = clickedGameObject;

        totalClicks++;
        FlipCard(clickedGameObject);

        if (totalClicks == 2) // Start Checking cards, player can't do anything
        {
            StartCoroutine(CheckCards());
            totalClicks = 0;
            
        }
    }

    private async void FlipCard(Transform targetGameObject) // FlipCard DoTween Animation 
    {
        RectTransform rect = targetGameObject.GetComponent<RectTransform>();
        AudioManager.instance.PlaySound(cardFlipSound);

        Tween tween = rect.DORotate(new Vector3(0, 90, 0), 0.25f).OnComplete(() => SwitchSprite(targetGameObject));

        await tween.AsyncWaitForCompletion();
        tween = rect.DORotate(new Vector3(0, 360, 0), 0.5f);
        await tween.AsyncWaitForCompletion();
        tween.Kill();
    }


    private IEnumerator CheckCards()
    {
        Debug.Log("Checking Cards...");
        EnablePlayerClick(false);

        Card lastClick = lastPressGameObject.GetComponent<Card>();
        Card currentClick = clickedGameObject.GetComponent<Card>();


        yield return new WaitForSeconds(rotation270Duration + roration90Duration + 0.1f);


        if (lastClick.cardData.id == currentClick.cardData.id)
        {
            Debug.Log("Cards Match");
            StartCoroutine(CardsMatch());
        }
        else
        {
            Debug.Log("Card Unmatch");
            StartCoroutine(CardsUnmatch());
        }
    }

    private IEnumerator CardsMatch()
    {
        DoMatchEffect();
        yield return new WaitForSeconds(scaleDuration);
        Destroy(lastPressGameObject.gameObject);
        Destroy(clickedGameObject.gameObject);
        CheckWin();
        EnablePlayerClick(true);
    }

    private IEnumerator CardsUnmatch()
    {
        DoUnmatchEffect();
        yield return new WaitForSeconds(shakeDuration);
        ResetCards();
        yield return new WaitForSeconds(rotation270Duration + roration90Duration + 0.1f);
        EnablePlayerClick(true);
    }


    private void SwitchSprite(Transform targetGameObject)
    {
        Sprite image = targetGameObject.GetComponent<Image>().sprite;
        CardData cardData = targetGameObject.GetComponent<Card>().cardData;

        if (image == cardData.front)
        {
            targetGameObject.GetComponent<Image>().sprite = cardData.back;
        }
        else
        {
            targetGameObject.GetComponent<Image>().sprite = cardData.front;
        }
    }

    public void ResetCards()
    {
        FlipCard(lastPressGameObject);
        FlipCard(clickedGameObject); 
    }

    

    private void DoMatchEffect()
    {
        lastPressGameObject.GetComponent<RectTransform>().DOScale(scaleForce, scaleDuration);
        clickedGameObject.GetComponent<RectTransform>().DOScale(scaleForce, scaleDuration);
    }


    private void DoUnmatchEffect()
    {
        lastPressGameObject.GetComponent<RectTransform>().DOShakeAnchorPos(shakeDuration, shakeForce);
        clickedGameObject.GetComponent<RectTransform>().DOShakeAnchorPos(shakeDuration, shakeForce);
    }


    private void EnablePlayerClick(bool state)
    {
        canPlayerClick = state;
    }


    private void CheckWin() // Check win based on the deck quantity
    {
        GameManager.instance.deck.RemoveRange(0, 2);

        if (GameManager.instance.deck.Count <= 0)
        {
            Debug.Log("Win !");
            GameManager.instance.PlayerVictory();
        }
    }
    #endregion
}
