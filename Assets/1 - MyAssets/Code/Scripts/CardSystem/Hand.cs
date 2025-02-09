using System.Collections;
using UnityEngine;

public class Hand : CardsContainer
{
    #region Singleton
    [HideInInspector] public static Hand Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this) return;
        Instance = this;
    }
    #endregion

    #region Veriables
    [SerializeField] private int _capacity;
    private Coroutine _drawAction = null;

    public bool IsDrawingCards => _drawAction != null;
    #endregion

    #region Logic
    public bool IsHandFull()
    {
        return _capacity == GetCardCount();
    }

    private IEnumerator DrawCard(int howMany = 1)
    {
        Card lastDrawnCard = null;

        for (int i=0; i<howMany; i++){
            Card card = Deck.Instance.TakeCard();
            if (card == null) yield break;

            GameObject instance = Instantiate(card.gameObject, Deck.Instance.transform.position, Quaternion.identity);
            instance.transform.SetParent(transform.parent);
            lastDrawnCard = instance.GetComponent<Card>();
            lastDrawnCard.Initialize();
            lastDrawnCard.MoveTo(transform, () => AddToHand(lastDrawnCard));
            yield return new WaitForSeconds(1);
        }

        yield return new WaitUntil(() => HasCard(lastDrawnCard));
        _drawAction = null;
        yield return null;
    }

    public void DrawCardsFromDeck(int howMany = 1)
    {
        if(_drawAction !=null || howMany == 0) return;
        _drawAction = StartCoroutine(DrawCard(howMany));
    }

    public void FillHand()
    {
        DrawCardsFromDeck(Mathf.Min(_capacity - GetCardCount(), Deck.Instance.GetCardCount()));
    }

    private void AddToHand(Card card)
    {
        card.transform.SetParent(transform, false);
        Cards.Add(card);
    }

    public void SetAllCardsInHandInteractive(bool value = true)
    {
        foreach(Card card in Cards)
        {
            card.SetIsInteractive(value);
        }
    }
    #endregion
}