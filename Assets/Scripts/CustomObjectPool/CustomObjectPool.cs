using System.Collections.Generic;
using UnityEngine;

public class CustomObjectPool<T> where T : MonoBehaviour
{
    private T _prefab;
    private Stack<T> _objects;
    private Transform _container;

    public CustomObjectPool(T prefab, List<T> createdObjects, Transform container)
    {
        _prefab = prefab;
        _objects = new Stack<T>(createdObjects);
        _container = container;
        foreach (T item in _objects)
            item.Deactivate();
    }

    public CustomObjectPool(T prefab, int numbersOfObjects, Transform container)
    {
        _prefab = prefab;
        _objects = new Stack<T>();
        _container = container;
        for (int i = 0; i < numbersOfObjects; i++)
            Return(Create());
    }

    public T Get()
    {
        if (!_objects.TryPop(out T obj))
            return Create();
        obj.Activate();
        return obj;
    }

    public void Return(T obj)
    {
        obj.Deactivate();
        _objects.Push(obj);
    }

    private T Create() => Object.Instantiate(_prefab, _container);
}