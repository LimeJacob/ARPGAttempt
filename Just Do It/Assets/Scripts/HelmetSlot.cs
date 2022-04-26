using Unity;
using UnityEngine;
public class HelmetSlot : MonoBehaviour, IEquipSlot<Helmet> 
{
    public Helmet item;
    public Helmet GetItem()
    {
        throw new System.NotImplementedException();
    }

    public void SetItem(Helmet t)
    {
        throw new System.NotImplementedException();
    }
}