using UnityEngine;

public class CollectorPriceView : TextView
{
    [SerializeField] private Collector _collector;

    private void OnEnable() => _collector.PriceChanged += UpdateText;

    private void OnDisable() => _collector.PriceChanged -= UpdateText;
}