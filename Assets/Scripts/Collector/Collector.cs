using System;
using System.Collections;
using UnityEngine;

public class Collector : MonoBehaviour, IUpgradable
{
    public event Action<string> PriceChanged;

    [SerializeField] private CollectorUpgrade _currentUpgrade;

    private bool _isBought = false;
    private float _remainingTime;
    private Upgrader<CollectorUpgrade> _upgrader;
    private Mushroom _mushroom;
    private Wallet _wallet;

    public void Init(Mushroom mushroom, Wallet wallet)
    {
        _mushroom = mushroom;
        _wallet = wallet;
        LoadUpgrade();
    }

    public void Upgrade()
    {
        if (_upgrader.IsMaxUpgrade || !_wallet.TrySpend(_upgrader.NextUpgrade.Price))
            return;
        _currentUpgrade = _upgrader.GetNextUpgrade();
        InvokeAction();
        Run();
    }

    private void Run()
    {
        if (_isBought)
        {
            _remainingTime = 0;
            return;
        }
        _isBought = true;
        PlayerPrefs.SetInt(nameof(Collector), Convert.ToInt32(_isBought));
        StartCoroutine(Collect());
    }

    private IEnumerator Collect()
    {
        while (true)
        {
            _remainingTime = _currentUpgrade.DelayBetweenCollecting;
            while (_remainingTime > 0)
            {
                _remainingTime -= Time.deltaTime;
                yield return null;
            }
            _mushroom.Collect();
        }
    }

    private void LoadUpgrade()
    {
        _upgrader = new Upgrader<CollectorUpgrade>(nameof(CollectorUpgrade));
        _currentUpgrade = _upgrader.GetPreviousUpgrade();
        InvokeAction();
        if (Convert.ToBoolean(PlayerPrefs.GetInt(nameof(Collector), 0)))
            Run();
    }

    private void InvokeAction()
    {
        string currentInfo = _upgrader.IsMaxUpgrade ?
            "Max" + _upgrader.Info :
            _upgrader.NextUpgrade.Price.GetReducedNumber() + _upgrader.Info;
        PriceChanged?.Invoke(currentInfo);
    }
}