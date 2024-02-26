using DG.Tweening;
using UnityEngine;

public class MushroomAnimation : MonoBehaviour
{
    [SerializeField, Min(0.0f)] private float _targetScale;
    [SerializeField, Range(0.01f, 0.25f)] private float _duration;
    [SerializeField] private Ease _ease;

    private SpriteRenderer _spriteRenderer;
    private Vector2 _defaultScale = Vector2.one;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultScale = transform.localScale;
    }

    public void Play()
    {
        DOTween.Sequence().
            Append(transform.DOScale(_targetScale, _duration)).
            Append(transform.DOScale(_defaultScale, _duration)).
            SetEase(_ease);
    }

    public void UpdateSprite(Sprite sprite) => _spriteRenderer.sprite = sprite;
}