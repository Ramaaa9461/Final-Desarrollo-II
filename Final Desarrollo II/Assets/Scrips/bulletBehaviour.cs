using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    [SerializeField] float velocity;
    Rigidbody RB;

    private void Awake()
    {
        RB = transform.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }
    void FixedUpdate()
    {
        // transform.position += transform.forward * velocity * Time.deltaTime;
        // RB.AddForce(transform.forward * velocity * Time.deltaTime, ForceMode.Impulse);
        RB.MovePosition(transform.position + transform.forward * velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Choco");
        Destroy(gameObject);
    }
}
