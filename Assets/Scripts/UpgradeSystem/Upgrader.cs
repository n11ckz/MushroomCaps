using System.Linq;
using UnityEngine;

public class Upgrader<T> where T : ScriptableObject
{
    private readonly string _key;

    public T NextUpgrade => IsMaxUpgrade ? _upgrades.Last() : _upgrades[_currentUpgradeIndex + 1];
    public bool IsMaxUpgrade => _currentUpgradeIndex + 1 >= _upgrades.Length;
    public string Info => $"\t{_currentUpgradeIndex + 1}/{_upgrades.Length}";

    private T[] _upgrades;
    private int _currentUpgradeIndex;

    public Upgrader(string resourcesPath)
    {
        _upgrades = Resources.LoadAll<T>(resourcesPath);
        _key = resourcesPath;
        _currentUpgradeIndex = PlayerPrefs.GetInt(_key, 0);
    }

    public T GetNextUpgrade()
    {
        if (IsMaxUpgrade)
            return _upgrades.Last();
        _currentUpgradeIndex++;
        PlayerPrefs.SetInt(_key, _currentUpgradeIndex);
        return _upgrades[_currentUpgradeIndex];
    }

    public T GetPreviousUpgrade()
    {
        if (_currentUpgradeIndex <= 0)
            return _upgrades.First();
        return _upgrades[_currentUpgradeIndex];
    }
}