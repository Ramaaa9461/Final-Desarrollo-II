using UnityEngine;


namespace Game
{

    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] AudioClip jumpSound;
        [SerializeField] AudioClip slidingSound;


        public SphereConfiguration sphereConfiguration;
        private MovementType movementType;
        AudioSource audioSource;


        private void Awake()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }
        void Start()
        {
            if (gameObject.GetComponent<JumpingMovement>())
            {
                audioSource.clip = jumpSound;
            }
            else
            {
                audioSource.clip = slidingSound;
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
}