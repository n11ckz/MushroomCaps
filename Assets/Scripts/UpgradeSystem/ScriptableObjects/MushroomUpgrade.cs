using System.Numerics;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Mushroom Upgrade", fileName = "New Mushroom Upgrade")]
public class MushroomUpgrade : ScriptableObject
{
    private const int DefaultValue = 1;

    [SerializeField] private string _incomePerClick;
    [SerializeField] private string _price;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _gameSprite;

    public BigInteger IncomePerClick => BigInteger.TryParse(_incomePerClick, out BigInteger incomePerClick) ? incomePerClick : DefaultValue;
    public BigInteger Price => BigInteger.TryParse(_price, out BigInteger price) ? price : DefaultValue;
    public string Name => _name;
    public Sprite GameSprite => _gameSprite;
}