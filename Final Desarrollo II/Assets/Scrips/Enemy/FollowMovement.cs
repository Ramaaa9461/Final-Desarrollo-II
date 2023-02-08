using UnityEngine;

namespace Game
{
    public class FollowMovement : MonoBehaviour, MovementType
    {
        AudioSource audioSource;

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
            audioSource = gameObject.GetComponent<AudioSource>();

        }

        private void Start()
        {
            velocity = sphereConfiguration.velocity;
        }

        public void Move()
        {
            direction = player.transform.position - transform.position;

            RB.AddForce(direction * velocity * Time.deltaTime);

            if (Time.timeScale == 1)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
        }
    }
}