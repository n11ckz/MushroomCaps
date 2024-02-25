using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float _targetScale;
    [SerializeField, Min(0f)] private float _duration;
    [SerializeField] private Ease _ease;

    private Vector2 _defaultScale = Vector2.one;

    private void Awake() => _defaultScale = transform.localScale;

    public void OnPointerEnter(PointerEventData eventData) => transform.DOScale(_targetScale, _duration).SetEase(_ease);

    public void OnPointerExit(PointerEventData eventData) => transform.DOScale(_defaultScale, _duration).SetEase(_ease);
}