using System.Numerics;
using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Collector Upgrade", fileName = "New Collector Upgrade")]
public class CollectorUpgrade : ScriptableObject
{
    private const int DefaultValue = 1;

    [SerializeField] private string _price;
    [SerializeField] private float _delayBetweenCollecting;

    public BigInteger Price => BigInteger.TryParse(_price, out BigInteger price) ? price : DefaultValue;
    public float DelayBetweenCollecting => _delayBetweenCollecting;
}