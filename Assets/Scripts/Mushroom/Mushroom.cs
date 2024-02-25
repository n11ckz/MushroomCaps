using System;
using UnityEngine;

public class Mushroom : MonoBehaviour, IUpgradable
{
    public event Action<string> PriceChanged;

    [SerializeField] private MushroomUpgrade _currentUpgrade;
    [SerializeField] private AudioClip _collectClip;

    private string _cachedReduce = "1";
    private Wallet _wallet;
    private PopUpTextSpawner _textSpawner;
    private Upgrader<MushroomUpgrade> _upgrader;
    private ClickHandler _clickHandler;
    private MushroomAnimation _mushroomAnimation;

    private void OnDisable() => _clickHandler.Clicked -= Collect;

    public void Init(Wallet wallet, PopUpTextSpawner spawner)
    {
        GetComponents();
        LoadUpgrade();
        _wallet = wallet;
        _textSpawner = spawner;
        _clickHandler.Clicked += Collect;
    }

    public void Collect()
    {
        _wallet.Add(_currentUpgrade.IncomePerClick);
        _textSpawner.Spawn(_cachedReduce);
        _mushroomAnimation.Play();
        SoundPlayer.Instance.Play(_collectClip);
    }

    public void Upgrade()
    {
        if (_upgrader.IsMaxUpgrade || !_wallet.TrySpend(_upgrader.NextUpgrade.Price))
            return;
        _currentUpgrade = _upgrader.GetNextUpgrade();
        Refresh();
    }

    private void GetComponents()
    {
        _clickHandler = GetComponent<ClickHandler>();
        _mushroomAnimation = GetComponent<MushroomAnimation>();
    }

    private void LoadUpgrade()
    {
        _upgrader = new Upgrader<MushroomUpgrade>(nameof(MushroomUpgrade));
        _currentUpgrade = _upgrader.GetPreviousUpgrade();
        Refresh();
    }

    private void Refresh()
    {
        gameObject.name = _currentUpgrade.Name;
        _cachedReduce = _currentUpgrade.IncomePerClick.GetReducedNumber();
        _mushroomAnimation.UpdateSprite(_currentUpgrade.GameSprite);
        string currentInfo = _upgrader.IsMaxUpgrade ?
            "Max" + _upgrader.Info :
            _upgrader.NextUpgrade.Price.GetReducedNumber() + _upgrader.Info;
        PriceChanged?.Invoke(currentInfo);
    }
}