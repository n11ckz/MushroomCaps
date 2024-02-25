using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PopUpTextSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _spawnArea;
    [SerializeField] private List<PopUpText> _createdTexts;

    private CustomObjectPool<PopUpText> _objectPool;

    public void Init() => _objectPool = new CustomObjectPool<PopUpText>(_createdTexts.First(), _createdTexts, transform);

    public void Spawn(string income)
    {
        PopUpText text = _objectPool.Get();
        text.transform.localPosition = GetRandomSpawnPoint();
        text.PopUp(income);
        StartCoroutine(WaitToReturn(text));
    }

    private Vector2 GetRandomSpawnPoint() => new Vector2(Random.Range(-_spawnArea.x, _spawnArea.x), Random.Range(-_spawnArea.y, _spawnArea.y));

    private IEnumerator WaitToReturn(PopUpText text)
    {
        WaitUntil waitUntil = new WaitUntil(() => text.CanReturnToPool);
        yield return waitUntil;
        _objectPool.Return(text);
    }
}