using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Deck : CardsContainer, IDisplayInfo
{
    #region Singleton
    [HideInInspector] public static Deck Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this) return;
        Instance = this;
    }
    #endregion

    #region Fields
    [SerializeField] TextMeshProUGUI cardsCountDisplay;
    #endregion

    #region Logic
    public void Shuffle()
    {
        System.Random rng = new System.Random();
        Cards = Cards.OrderBy(_ => rng.Next()).ToList();
    }

    public Card TakeCard()
    {
        int lastIndex = Cards.Count - 1;
        Card card = Cards[lastIndex];
        Cards.RemoveAt(lastIndex);
        UpdateInfo();
        return card;
    }

    public void LoadCardsToDeck(List<Card> cardsList)
    {
        Cards.Clear();
        foreach (Card card in cardsList)
        {
            AddCard(card);
        }
        Shuffle();
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        cardsCountDisplay.text = Cards.Count.ToString();
    }
    #endregion
}