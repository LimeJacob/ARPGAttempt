using UnityEngine;

[System.Serializable]
public class EquipAnimators 
{
    [SerializeField]
    Animator weapon;
    [SerializeField]
    Animator shield;
    public Animator Weapon { get => weapon; set { weapon = value; } }
    public Animator Shield { get => shield; set { weapon = value; } }
}