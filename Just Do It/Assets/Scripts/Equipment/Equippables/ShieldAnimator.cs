using UnityEngine;

public class ShieldAnimator : MonoBehaviour 
{
    private Animator animator;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnGaurd()
    {
        animator.SetBool("Gaurd", true);
    }
    public void OnGaurdStop() 
    {
        animator.SetBool("Gaurd", false);
    }
}