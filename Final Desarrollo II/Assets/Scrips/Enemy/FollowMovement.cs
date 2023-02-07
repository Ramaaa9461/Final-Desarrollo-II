using UnityEngine;

namespace Game
{
    public class FollowMovement : MonoBehaviour, MovementType
    {
        SphereConfiguration sphereConfiguration;
        GameObject player;
        Rigidbody RB;

        Vector3 direction;
        float velocity = 20;

        void Awake()
        {
            RB = gameObject.GetComponent<Rigidbody>();
            sphereConfiguration = gameObject.GetComponent<EnemyBehaviour>().sphereConfiguration;
            player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Start()
        {
            velocity = sphereConfiguration.velocity;
        }

        public void Move()
        {
            direction = player.transform.position - transform.position;

            RB.AddForce(direction * velocity * Time.deltaTime);
        }
    }
}