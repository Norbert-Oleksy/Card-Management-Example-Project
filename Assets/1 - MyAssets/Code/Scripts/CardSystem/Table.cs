using UnityEngine;
using UnityEngine.EventSystems;

public class Table : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();
        if(card != null)
        {
            card.SetOnDropAction(() => {
                Hand.Instance.RemoveCard(card);
                DiscardPile.Instance.MoveCardToDiscardPile(card);
                });
        }
    }
}