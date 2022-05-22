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

    public SpriteLibrary Weapon { get => weapon; set { weapon = value; } }
    public SpriteLibrary Shield { get => shield; set { shield = value; } }
    public SpriteLibrary Armor { get => armor; set { armor = value; } }
    public SpriteLibrary Leggings { get => leggings; set { leggings = value; } }
    public SpriteLibrary Helmet { get => helmet; set { helmet = value; } }
}
