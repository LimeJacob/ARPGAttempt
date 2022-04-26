using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Reflection;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float vertical;
    [SerializeField] private float horizontal;

    [SerializeField] private bool attack;
    [SerializeField] private bool gaurd;
    [SerializeField] private bool interact;

    [SerializeField] private Stats stats;

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerAnimations animations = new PlayerAnimations();

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
     
    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        attack = Input.GetButtonDown("Attack");
        gaurd = Input.GetButtonDown("Gaurd");
        interact = Input.GetButtonDown("Interact");

        animations.Update(vertical, horizontal);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = stats.Speed.GetValue() * new Vector2(horizontal, vertical);
    }
}

[System.Serializable]
public class PlayerAnimations
{
    [SerializeField] private List<Animator> animators;

    [Range(0f, 1f)]
    [SerializeField]
    private float verticalThreshold;

    [Range(0f, 1f)]
    [SerializeField]
    private float horizontalThreshold;

    public void Update(float vertical, float horizontal)
    {
        foreach (var animator in animators) 
        {
            animator.SetInteger("Horizontal", GetHorizontal(horizontal));
            animator.SetInteger("Vertical", GetVertical(vertical));
        }
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