using System;
using System.Numerics;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private const string StartMoney = "0";

    public event Action<string> Changed;

    private BigInteger _currentMoney;

    public void Init()
    {
        _currentMoney = BigInteger.Parse(PlayerPrefs.GetString(nameof(Wallet), StartMoney));
        Changed?.Invoke(_currentMoney.GetReducedNumber());
    }

    public void Add(BigInteger amount)
    {
        if (amount < 0)
            return;
        _currentMoney += amount;
        PlayerPrefs.SetString(nameof(Wallet), _currentMoney.ToString());
        Changed?.Invoke(_currentMoney.GetReducedNumber());
    }

    public bool TrySpend(BigInteger amount)
    {
        if (_currentMoney - amount < 0 || amount < 0)
            return false;
        _currentMoney -= amount;
        PlayerPrefs.SetString(nameof(Wallet), _currentMoney.ToString());
        Changed?.Invoke(_currentMoney.GetReducedNumber());
        return true;
    }
}