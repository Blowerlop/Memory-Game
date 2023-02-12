using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/New Card")]
public class CardData : ScriptableObject 
{
    // Card Identity

    public int id;
    public Sprite front;
    public Sprite back;
}
