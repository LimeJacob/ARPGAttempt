using UnityEngine;

public class WeaponAnimator : MonoBehaviour 
{
    private Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnAttack() 
    {
        animator.SetTrigger("Attack");
    }
}
