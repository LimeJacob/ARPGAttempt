using UnityEngine;
using System.Collections.Generic;

public abstract class ProjectileBehaviour : MonoBehaviour
{
    protected Rigidbody2D rb2D;
    protected Vector2 initalTrajectory;
    [SerializeField]
    protected List<MonoBehaviour> associatedBehaviours = new List<MonoBehaviour>();
    public void Shoot(Vector2 d)
    {
        initalTrajectory = d;
        enabled = true;
    }
    private void OnEnable()
    {
        rb2D = GetComponent<Rigidbody2D>();
        foreach (MonoBehaviour behaviour in associatedBehaviours)
            behaviour.enabled = true;
    }
}