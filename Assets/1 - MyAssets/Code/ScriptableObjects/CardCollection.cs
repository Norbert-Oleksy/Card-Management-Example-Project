using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardCollection", menuName = "ScriptableObjects/Card/CreateNewCardCollection")]
public class CardCollection : ScriptableObject
{
    public List<Card> ListOfCards = new List<Card>();
}
