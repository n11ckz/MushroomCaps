using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private PopUpTextSpawner _spawner;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Mushroom _mushroom;
    [SerializeField] private Collector _collector;
    [SerializeField] private UpgradeButton _mushroomUpgradeButton;
    [SerializeField] private UpgradeButton _collectorUpgradeButton;

    private void Start()
    {
        _spawner.Init();
        _wallet.Init();
        _mushroom.Init(_wallet, _spawner);
        _collector.Init(_mushroom, _wallet);
        _mushroomUpgradeButton.Init(_mushroom);
        _collectorUpgradeButton.Init(_collector);
    }
}