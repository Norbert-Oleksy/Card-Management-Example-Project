using TMPro;
using UnityEngine;

public class DiscardPile : CardsContainer, IDisplayInfo
{
    #region Singleton
    [HideInInspector] public static DiscardPile Instance { get; private set; }
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
    public void MoveCardToDiscardPile(Card card)
    {
        card.MoveTo(transform, () => DiscardCard(card));
    }

    public void DiscardCard(Card card)
    {
        Cards.Add(card);
        card.transform.SetParent(transform,false);
        card.gameObject.SetActive(false);
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        cardsCountDisplay.text = Cards.Count.ToString();
    }
    #endregion
}
