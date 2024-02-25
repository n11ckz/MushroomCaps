using UnityEngine;

public class WalletView : TextView
{
    [SerializeField] private Wallet _wallet;

    private void OnEnable() => _wallet.Changed += UpdateText;

    private void OnDisable() => _wallet.Changed -= UpdateText;
}