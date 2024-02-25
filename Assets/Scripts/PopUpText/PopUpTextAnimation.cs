using DG.Tweening;
using TMPro;
using UnityEngine;

public class PopUpTextAnimation : MonoBehaviour
{
    private const float TargetAlpha = 0.0f;

    [SerializeField, Min(0.0f)] private float _targetScale;
    [SerializeField, Min(0.0f)] private float _targetY;
    [SerializeField, Range(0.01f, 0.5f)] private float _duration;

    private Vector2 _defaultScale = Vector2.one;
    private PopUpText _popUpText;

    private void Awake()
    {
        _popUpText = GetComponent<PopUpText>();
        _defaultScale = transform.localScale;
    }

    public void Play(TextMeshProUGUI text)
    {
        Color defaultAlpha = text.color;
        transform.localScale = GetRandomScale();
        DOTween.Sequence().
            Append(transform.DOLocalMoveY(transform.localPosition.y + _targetY, _duration)).
            Append(text.DOFade(TargetAlpha, _duration)).
            OnComplete(() => { _popUpText.ReturnToPool(); text.color = defaultAlpha; });
    }

    private Vector2 GetRandomScale()
    {
        float newScale = Random.Range(_defaultScale.x, _targetScale);
        return new Vector2(newScale, newScale);
    }
}