using UnityEngine;

public class SaveDestroyer : MonoBehaviour
{
    [ContextMenu(nameof(DeleteSaves))]
    private void DeleteSaves() => PlayerPrefs.DeleteAll();
}