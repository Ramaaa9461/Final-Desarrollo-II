using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingMovement : MonoBehaviour, MovementType
{
    Rigidbody RB;


    float distToGround;
    float velocity = 5;
    void Awake()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }
    private void Start()
    {
        distToGround = gameObject.GetComponentInChildren<Collider>().bounds.extents.y;
    }
    bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector3.up,Color.yellow , distToGround + 0.1f);
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }


    public void Move()
    {
        Debug.Log(IsGrounded());

        if (IsGrounded())
        {
            //   RB.AddForce(Vector3.up * velocity );
            RB.velocity = new Vector3(0, velocity,0);
        }
    }
}
