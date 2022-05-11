using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnEquip : MonoBehaviour
{
    public abstract void Apply(PlayerController player);
    public abstract void Remove(PlayerController player);
}
