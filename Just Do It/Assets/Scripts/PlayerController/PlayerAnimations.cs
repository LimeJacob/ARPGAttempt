using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
#endif
using System;

[System.Serializable]
public class PlayerAnimations
{
    private Direction direction;

    public Direction Dir { get => direction; }
    
    [SerializeField] private List<Animator> animators;

    [Range(0f, 1f)]
    [SerializeField]
    private float verticalThreshold;

    [Range(0f, 1f)]
    [SerializeField]
    private float horizontalThreshold;

    public void Update(float vertical, float horizontal)
    {
        var horiz = GetHorizontal(horizontal);
        var vert = GetVertical(vertical);
        foreach (var animator in animators)
        {
            animator.SetInteger("Horizontal", horiz);
            animator.SetInteger("Vertical", vert);
        }

        if (horiz == 1) 
        { direction = Direction.Right; }
        else if (horiz == -1) 
        { direction = Direction.Left; }
        else if (vert == 1)
        { direction = Direction.Up; }
        else if (vert == -1)
        { direction = Direction.Down; }
    }
    private int GetHorizontal(float raw)
    {
        if (Mathf.Abs(raw) > horizontalThreshold) return Math.Sign(raw);
        else return 0;
    }

    private int GetVertical(float raw)
    {
        if (Mathf.Abs(raw) > verticalThreshold) return Math.Sign(raw);
        else return 0;
    }
}