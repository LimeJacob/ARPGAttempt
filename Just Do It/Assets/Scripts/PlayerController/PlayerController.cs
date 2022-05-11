using System.Collections;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float vertical;
    [SerializeField] private float horizontal;

    [SerializeField] private bool attack;
    [SerializeField] private bool gaurd;
    [SerializeField] private bool interact;

    private float attackCooldown = 0f;

    [SerializeField] private Stats stats;
    [SerializeField] private EquipmentManager equipmentManager;

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerAnimations animations = new PlayerAnimations();

    PlayerState state = PlayerState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Stats>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
     
    // Update is called once per frame
    void Update()
    {
        GetInputs();

        animations.Update(vertical, horizontal);

        switch (state) 
        {
            case PlayerState.Attacking:
                attackCooldown -= Time.deltaTime;
                if (attackCooldown <= 0) SetState(PlayerState.Idle);
                break;
            case PlayerState.Gaurding:

                break;
            case PlayerState.Idle:
                if (gaurd) {
                    equipmentManager.Animators.Shield.SetTrigger("Gaurding");
                } 
                else if (attack)
                {
                    equipmentManager.Animators.Weapon.SetTrigger("Attacking");
                    equipmentManager.GetWeapon().Attack();
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case PlayerState.Attacking:
                Movement();
                break;
            case PlayerState.Gaurding:
                break;
            case PlayerState.Idle:
                Movement();
                break;
        }        
    }

    private void GetInputs() 
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        attack = Input.GetButton("Attack");
        gaurd = Input.GetButton("Gaurd");
        interact = Input.GetButtonDown("Interact");
    }

    public void Movement()
    {
        rigidBody.velocity = stats.Speed.GetValue() * new Vector2(horizontal, vertical);
    }

    public void SetState(PlayerState playerState) 
    {
        state = playerState;
    }

    public void SetAttackCooldown(float cooldown) 
    {
        attackCooldown = cooldown;
    }
    public Direction GetDirection() => animations.Dir;
}
