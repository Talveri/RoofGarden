using UnityEngine;

public interface IInteractable
{
#nullable enable
    void Interact<T>(T data);
}
