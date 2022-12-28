using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour, MovementType
{
    GameObject player;
    Rigidbody RB;

    Vector3 direction;
    float velocity = 20;
    void Awake()
    {
        RB = gameObject.GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Move()
    {
        direction = player.transform.position - transform.position;

        RB.AddForce(direction * velocity * Time.deltaTime);
    }
}
