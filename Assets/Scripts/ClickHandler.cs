using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ClickHandler : MonoBehaviour
{
    public Action Clicked;

    private void OnMouseDown() => Clicked?.Invoke();
}