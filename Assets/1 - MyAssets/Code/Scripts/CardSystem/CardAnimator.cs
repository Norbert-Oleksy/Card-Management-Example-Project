using System;
using UnityEngine;

public class CardAnimator : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject _cardOutLine;
    #endregion

    #region Variables
    private ICardAnimation _cardAnimation = null;
    [HideInInspector] public Transform target;
    [HideInInspector] public float duration;
    [HideInInspector] public Action OnEndAction;

    public bool IsAnimated => _cardAnimation != null;
    #endregion

    #region Logic

    public void PlaySelectCardAnimation(bool state)
    {
        if (_cardAnimation != null)
        {
            if(_cardAnimation is SelectCardAnimation && !state)
            {
                _cardAnimation.Kill();
            }
            return;
        }
        if(state)
        {
            _cardOutLine.SetActive(true);
            Vector3 originalPosition = transform.position;
            OnEndAction = () =>
            {
                transform.position = originalPosition;
                _cardOutLine.SetActive(false);
            };
            duration = 0.5f;

            _cardAnimation = new SelectCardAnimation();
            _cardAnimation.Initialize(this);
            _cardAnimation.Play();
        }
    }

    public void PlayMoveCardTo(Transform newTarget,float newDuration, Action newAction)
    {
        if(_cardAnimation != null) return;
        target = newTarget;
        duration = newDuration;
        OnEndAction = newAction;
        _cardAnimation = new MoveCardAnimation();
        _cardAnimation.Initialize(this);
        _cardAnimation.Play();
    }

    public void OnEndAnimation()
    {
        OnEndAction?.Invoke();
        _cardAnimation = null;
    }

    public void KillPlayingAnimation()
    {
        _cardAnimation?.Kill();
        _cardAnimation = null;
    }
    #endregion
}
