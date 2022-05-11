using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slasher : Weapon
{
    [SerializeField] private GameObject slash;
    public override void Attack()
    {
        base.Attack();
        Instantiate(slash, playerController.transform.position, DirectionHelper.GetQuaternion(playerController.GetDirection()))
            .GetComponent<ProjectileBehaviour>().Shoot(DirectionHelper.GetVector2(playerController.GetDirection()));
    }
}
