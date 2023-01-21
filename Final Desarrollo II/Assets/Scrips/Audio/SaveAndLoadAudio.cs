using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadAudio : MonoBehaviour
{
    string musicVolumePath = "MusicVolume";
    string sfxVolumePath = "SfxVolume";
    string isMutePath = "isMute";


    public void SaveMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(musicVolumePath, volume);
    }

    public void SaveSfxVolume(float volume)
    {
        PlayerPrefs.SetFloat(sfxVolumePath, volume);
    }

    public void SaveIsMute(bool mute)
    {
        PlayerPrefs.SetString(isMutePath, mute.ToString());
    }

    public float LoadMusicVolume()
    {
        return PlayerPrefs.GetFloat(musicVolumePath);
    }

    public float LoadSfxVolume()
    {
        return PlayerPrefs.GetFloat(sfxVolumePath);
    }

    public bool LoadIsMute()
    {
        return PlayerPrefs.GetString(isMutePath).Contains('1'); //Nose si funcara
    }
}
