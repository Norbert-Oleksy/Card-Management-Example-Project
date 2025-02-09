using System.Collections.Generic;
using UnityEngine;

public class CardsContainer : MonoBehaviour
{
    protected List<Card> Cards = new List<Card>();
    public int GetCardCount() => Cards.Count;

    public Card GetCard(int index)
    {
        if (index >= 0 && index < Cards.Count)
        {
            return Cards[index];
        }
        return null;
    }

    public bool HasCard(Card card)
    {
        return Cards.Contains(card);
    }

    public bool RemoveCard(Card card)
    {
        return Cards.Remove(card);
    }

    public void AddCard(Card card)
    {
        if (card != null)
        {
            Cards.Add(card);
        }
    }
}