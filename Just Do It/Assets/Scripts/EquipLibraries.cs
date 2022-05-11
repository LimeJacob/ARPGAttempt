using UnityEngine;
using UnityEngine.U2D.Animation;

[System.Serializable]
public class EquipLibraries
{
    [SerializeField]
    SpriteLibrary weapon;
    [SerializeField]
    SpriteLibrary shield;
    [SerializeField]
    SpriteLibrary armor;
    [SerializeField]
    SpriteLibrary leggings;
    [SerializeField]
    SpriteLibrary helmet;

    public SpriteLibrary Weapon { get => weapon; }
    public SpriteLibrary Shield { get => shield; }
    public SpriteLibrary Armor { get => armor; }
    public SpriteLibrary Leggings { get => leggings; }
    public SpriteLibrary Helmet { get => helmet; }
}
