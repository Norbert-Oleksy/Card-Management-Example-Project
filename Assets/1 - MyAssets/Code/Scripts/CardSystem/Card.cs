using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IProduct, IPointerEnterHandler, IPointerExitHandler
{
    #region Variables
    private CanvasGroup _canvasGroup;
    private Transform _originalParent;
    private Action _onDropAction = null;
    private GameObject _placeHolder;

    private CardAnimator _cardAnimator;
    #endregion
    #region Logic
    public void MoveTo(Transform target , Action OnEnd = null)
    {
        if(_cardAnimator.IsAnimated) return;

        _canvasGroup.interactable = false;
        _cardAnimator.PlayMoveCardTo(target, 0.8f, () =>
        {
            _canvasGroup.interactable = true;
            OnEnd?.Invoke();
        });
    }

    public void OnEndDragCardAction()
    {
        _canvasGroup.blocksRaycasts = true;

        if(_onDropAction != null )
        {
            _onDropAction.Invoke();
            _onDropAction = null;
        }
        else
        {
            ReturnToHand();
        }
        Destroy(_placeHolder);
    }

    public void SetOnDropAction(Action toDo) => _onDropAction = toDo;

    private void ReturnToHand()
    {
        transform.SetParent(_originalParent, false);
        transform.SetSiblingIndex(_placeHolder.transform.GetSiblingIndex());
    }

    public void OnStartDragCardAction()
    {
        _cardAnimator.KillPlayingAnimation();
        _originalParent = transform.parent;
        CreatePlaceHolder();
        transform.SetParent(transform.parent.parent);
        _canvasGroup.blocksRaycasts = false;
    }

    public void Initialize()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _cardAnimator = GetComponent<CardAnimator>();
    }

    public void SetIsInteractive(bool itIs = true)
    {
        _canvasGroup.blocksRaycasts = itIs;
    }

    private void CreatePlaceHolder()
    {
        _placeHolder = new GameObject();

        RectTransform placeholderRect = _placeHolder.AddComponent<RectTransform>();
        placeholderRect.SetParent(transform.parent);
        placeholderRect.sizeDelta = GetComponent<RectTransform>().sizeDelta;

        _placeHolder.transform.SetSiblingIndex(transform.GetSiblingIndex());
    }

    public void OnOtherCardHover(Card otherCard)
    {
        if(otherCard.transform.parent == _placeHolder.transform.parent)
        {
            int indexHelper = _placeHolder.transform.GetSiblingIndex();
            _placeHolder.transform.SetSiblingIndex(otherCard.transform.GetSiblingIndex());
            otherCard.transform.SetSiblingIndex(indexHelper);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) return;
        _cardAnimator.PlaySelectCardAnimation(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null) return;
        _cardAnimator.PlaySelectCardAnimation(false);
    }
    #endregion
}