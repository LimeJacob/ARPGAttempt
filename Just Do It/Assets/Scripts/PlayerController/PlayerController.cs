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

    [SerializeField] private float maxSpeed;

    private float attackCooldown = 0f;

    [SerializeField] private Stats stats;
    [SerializeField] private EquipmentManager equipmentManager;

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private PlayerAnimations animations = new PlayerAnimations();

    [SerializeField]
    public PlayerMovement movement;

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

        switch (state) 
        {
            case PlayerState.Attacking:
                animations.Update(vertical, horizontal, false);
                attackCooldown -= Time.deltaTime;
                if (attackCooldown <= 0) SetState(PlayerState.Idle);
                break;
            case PlayerState.Gaurding:
                animations.Update(vertical, horizontal, true);
                if (!gaurd)
                {
                    rigidBody.drag = 3f;
                    state = PlayerState.Idle;
                    equipmentManager.Animators.Shield.SetBool("Gaurding", false);
                }
                break;
            case PlayerState.Idle:
                animations.Update(vertical, horizontal, false);
                if (gaurd) {
                    equipmentManager.Animators.Shield.SetBool("Gaurding", true);
                    state = PlayerState.Gaurding;
                    rigidBody.drag = 7f;
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
        movement.Calculate(horizontal, vertical, rigidBody, stats.Speed.GetValue());
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
[System.Serializable]
public class PlayerMovement
{
    [SerializeField] private float prevVert;
    [SerializeField] private float prevHor;

    [SerializeField] Vector2 targetVel = new Vector2();

    [Range (-1f, 1f)]
    [SerializeField] private float pushback;

    public void Calculate(float horiz, float vert, Rigidbody2D rb, float speed)
    {
        // If velocity is less than maxSpeed or is in the opposite direction, increase by constant factor until it is equal to maxSpeed.
        // Afterwards maintain a cruising velocity
        targetVel.Set(speed * horiz, speed * vert);

        if (Mathf.Sign(Mathf.Abs(vert) - Mathf.Abs(prevVert)) < 0 && Mathf.Abs(vert) < 1)
        {
            targetVel.y *= pushback;
        }
        if (Mathf.Sign(Mathf.Abs(horiz) - Mathf.Abs(prevHor)) < 0 && Mathf.Abs(horiz) < 1)
        {
            targetVel.x *= pushback;
        }
        
        rb.AddForce(targetVel);

        prevHor = horiz;
        prevVert = vert;
    }
}