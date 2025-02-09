using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    #region Events
    [SerializeField] private UnityEvent _onBeginDragEvent, _onEndDragEvent;

    #endregion

    #region Logic
    public void OnBeginDrag(PointerEventData eventData)
    {
        _onBeginDragEvent?.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        Card otherCard = results
            .Select(r => r.gameObject.GetComponent<Card>())
            .FirstOrDefault(c => c != null && c != this);

        if (otherCard != null) GetComponent<Card>().OnOtherCardHover(otherCard);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _onEndDragEvent?.Invoke();
    }
    #endregion
}