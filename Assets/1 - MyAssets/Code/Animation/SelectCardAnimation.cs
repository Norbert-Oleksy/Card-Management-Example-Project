using DG.Tweening;
using UnityEngine;

public class SelectCardAnimation : ICardAnimation
{
    private CardAnimator _animator;
    private Tweener tweener;

    public void Initialize(CardAnimator reference)
    {
        _animator = reference;
    }

    public void Kill()
    {
        tweener.Kill();
        _animator.OnEndAnimation();
    }

    public void Play()
    {
        tweener = _animator.transform.DOBlendableLocalMoveBy(Vector3.up * 10f, _animator.duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}