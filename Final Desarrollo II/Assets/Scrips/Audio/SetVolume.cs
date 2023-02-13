using System.Collections.Generic;
using UnityEngine;


namespace Game
{

    public class SetVolume : MonoBehaviour
    {
        [SerializeField] List<AudioSource> musicList;
        [SerializeField] List<AudioSource> sfxList;

        SaveAndLoadAudio saveAndLoadAudio;
        private void Awake()
        {
            saveAndLoadAudio = gameObject.GetComponent<SaveAndLoadAudio>();

            AudioSource[] audioSource;

            audioSource = GameObject.FindObjectsOfType<AudioSource>();


            for (int i = 0; i < audioSource.Length; i++)
            {
                if (audioSource[i].loop)
                {
                    musicList.Add(audioSource[i]);
                }
                else
                {
                    sfxList.Add(audioSource[i]);
                }
            }

            //setMusicVolume(saveAndLoadAudio.LoadMusicVolume()); //Lo setea el UIController para evitar leer innesariamente datos del disco
            //setSfxVolume  (saveAndLoadAudio.LoadSfxVolume());
            //setAllAudiosInMute(saveAndLoadAudio.LoadIsMute());
        }

        public void setMusicVolume(float volume)
        {
            foreach (AudioSource AS in musicList)
            {
                AS.volume = volume;

            }
        }

        public void setSfxVolume(float volume)
        {
            foreach (AudioSource AS in sfxList)
            {
                AS.volume = volume;
            }
        }

        public void setAllAudiosInMute(bool isMute)
        {
            foreach (AudioSource AS in musicList)
            {
                AS.mute = isMute;
            }

            foreach (AudioSource AS in sfxList)
            {
                AS.mute = isMute;
            }
        }

        public void RemoveAudioSource(AudioSource audioSourceToRemove)
        {
            sfxList.Remove(audioSourceToRemove);
        }


    }
}