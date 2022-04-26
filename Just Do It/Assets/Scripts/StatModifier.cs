using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatModifier : MonoBehaviour
{
    [SerializeField] private float value;
    public abstract void Apply();
    public abstract void Remove();
}
