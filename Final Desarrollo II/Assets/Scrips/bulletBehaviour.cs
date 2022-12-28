using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
  [SerializeField] float velocity;


    void Update()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Choco");
        Destroy(gameObject);
    }
}
