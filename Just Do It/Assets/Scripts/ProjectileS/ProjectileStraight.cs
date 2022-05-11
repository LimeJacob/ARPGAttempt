using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileStraight : ProjectileBehaviour
{
    [SerializeField] float speed;
    public void FixedUpdate()
    {
        rb2D.velocity = speed * initalTrajectory;
    }
}
