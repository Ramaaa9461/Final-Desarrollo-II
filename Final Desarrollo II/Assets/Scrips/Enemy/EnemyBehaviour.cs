using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{

    public class EnemyBehaviour : MonoBehaviour
    {
        public SphereConfiguration sphereConfiguration;
        private MovementType movementType;

        AudioSource audioSource;
        [SerializeField] AudioClip jumpSound;
        [SerializeField] AudioClip slidingSound;
        [SerializeField] GameObject sphereDeadSoundPrefab;



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

        private void OnDisable()
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gameplay"))
            {
                Instantiate(sphereDeadSoundPrefab);
                Destroy(gameObject);
            }
        }

    }
}