using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSlot<T> : MonoBehaviour
{
    [SerializeField]
    T item;

    public T GetItem() => item;

    private void Start()
    {
        item = GetComponentInChildren<T>();
    }
}
