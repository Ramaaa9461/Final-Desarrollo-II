using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    List<AudioSource> musicList;
    List<AudioSource> sfxList;

    private void Awake()
    {
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
        if (isMute)
        {
            setMusicVolume(0);
            setSfxVolume(0);
        }
        else
        {
            setMusicVolume(1);
            setSfxVolume(1);
        }
    }
}
