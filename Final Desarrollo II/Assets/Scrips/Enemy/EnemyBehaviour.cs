using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private MovementType movementType;

    void Awake()
    {
        if (Random.Range(0, 2) == 0)
        {
            movementType = gameObject.AddComponent<FollowMovement>();
        }
        else
        {
            movementType = gameObject.AddComponent<JumpingMovement>();
        }
    }

    void Update()
    {
        movementType.Move();
    }

    public void setMovementType(MovementType MT)
    {
        movementType = MT;
    }
}
