using TMPro;
using UnityEngine;

public abstract class TextView : MonoBehaviour
{
    protected TextMeshProUGUI Text;

    private void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
        OnAwake();
    }

    protected virtual void UpdateText(string text) => Text.text = text;

    protected virtual void OnAwake() { }
}