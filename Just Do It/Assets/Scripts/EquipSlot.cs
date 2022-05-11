using UnityEngine;

public abstract class EquipSlot<T> : MonoBehaviour where T : Equippable
{
    [SerializeField] T item;
    public void SetItem(T t) 
    {
        // Switch item on cursor and item in slot
        item = t;
    }
    public T GetItem() 
    {
        return item;
    }
}
