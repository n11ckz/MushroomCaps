using UnityEngine;

public class MushroomPriceView : TextView
{
    [SerializeField] private Mushroom _mushroom;

    private void OnEnable() => _mushroom.PriceChanged += UpdateText;

    private void OnDisable() => _mushroom.PriceChanged -= UpdateText;
}