using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
  [SerializeField] float velocity;

    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    void Update()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Intancias particulas
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }
}
