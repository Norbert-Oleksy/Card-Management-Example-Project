using DG.Tweening;

public class MoveCardAnimation : ICardAnimation
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
    }

    public void Play()
    {
        tweener = _animator.transform.DOMove(_animator.target.position, _animator.duration, true)
        .SetEase(Ease.InQuint)
        .OnComplete(() => _animator.OnEndAnimation());
    }
}