using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public void Init(IUpgradable upgradable) => GetComponent<Button>().onClick.AddListener(upgradable.Upgrade);
}