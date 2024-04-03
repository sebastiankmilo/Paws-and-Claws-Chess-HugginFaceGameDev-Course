using System;
using UnityEngine;

public class UIInputHandler : MonoBehaviour, IInputHandler
{
    public void ProcessInput(Vector3 inputPosition, GameObject selectedObject, Action onClick)
    {
        onClick?.Invoke();
    }
}
