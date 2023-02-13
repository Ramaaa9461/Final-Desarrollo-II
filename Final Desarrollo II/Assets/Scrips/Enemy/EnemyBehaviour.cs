using UnityEngine;
using UnityEngine.Events;
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

        public UnityEvent<AudioSource> removeAudioSource;

        private void Awake()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            removeAudioSource.AddListener(GameObject.FindObjectOfType<SetVolume>().RemoveAudioSource);
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


        public void ActiveDeadSound()
        {
            Instantiate(sphereDeadSoundPrefab);
            removeAudioSource.Invoke(audioSource);
            Destroy(gameObject);
        }

    }
}