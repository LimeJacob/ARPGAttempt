using UnityEngine;

public static class DirectionHelper
{
    public static Vector2 GetVector2(Direction d) 
    {
        switch (d)
        {
            case Direction.Up:
                return new Vector2(0, 1);
            case Direction.Down:
                return new Vector2(0, -1);
            case Direction.Left:
                return new Vector2(-1, 0);
            case Direction.Right:
                return new Vector2(1, 0);
            default:
                Debug.LogError("Unrecognized or unimplemented direction (Quaternion)");
                return new Vector2(0, 0);
        }
    }

    public static Quaternion GetQuaternion(Direction d)
    {
        switch (d)
        {
            case Direction.Up:
                return Quaternion.Euler(new Vector3(0, 0, 90));
            case Direction.Down:
                return Quaternion.Euler(new Vector3(0, 0, 270));
            case Direction.Left:
                return Quaternion.Euler(new Vector3(0, 0, 180));
            case Direction.Right:
                return Quaternion.Euler(new Vector3(0, 0, 0));
            default:
                Debug.LogError("Unrecognized or unimplemented direction (Quaternion)");
                return new Quaternion(0, 0, 0, 0);
        }
    }
}