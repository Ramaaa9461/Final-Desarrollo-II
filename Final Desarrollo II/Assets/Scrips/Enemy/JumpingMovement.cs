using UnityEngine;


namespace Game
{

    public class JumpingMovement : MonoBehaviour, MovementType
    {
        [SerializeField] AudioClip jumpSound;
        AudioSource audioSource;

        SphereConfiguration sphereConfiguration;
        Rigidbody RB;



        float distToGround;
        float velocity = 5;

        void Awake()
        {
            RB = gameObject.GetComponent<Rigidbody>();
            sphereConfiguration = gameObject.GetComponent<EnemyBehaviour>().sphereConfiguration;
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        private void Start()
        {
            distToGround = gameObject.GetComponentInChildren<Collider>().bounds.extents.y;
            velocity = sphereConfiguration.jumpForce;
        }

        bool IsGrounded()
        {
            Debug.DrawRay(transform.position, -Vector3.up, Color.yellow, distToGround + 0.1f);
            return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        }


        public void Move()
        {
            if (IsGrounded())
            {
                //   RB.AddForce(Vector3.up * velocity );
                RB.velocity = new Vector3(0, velocity, 0);
                audioSource.Play();
            }
        }
    }
}