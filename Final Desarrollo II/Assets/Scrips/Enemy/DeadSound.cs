using UnityEngine;

namespace Game
{
    public class DeadSound : MonoBehaviour
    {
        AudioSource audioSource;
        SaveAndLoadAudio loadAudio;

        private void Awake()
        {
            audioSource = gameObject.GetComponent<AudioSource>();
            loadAudio = gameObject.GetComponent<SaveAndLoadAudio>();
        }


        private void Start()
        {
            audioSource.mute = loadAudio.LoadIsMute();
            if (!audioSource.mute)
            {
                audioSource.volume = loadAudio.LoadSfxVolume();
            }
            audioSource.Play();
        }

        private void Update()
        {
            if (!audioSource.isPlaying)
            {
                Destroy(gameObject);
            }
        }



    }
}
