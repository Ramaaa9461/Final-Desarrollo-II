using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiAudioController : MonoBehaviour
{
    [SerializeField] SaveAndLoadAudio saveAndLoadAudio;
    [SerializeField] SetVolume setVolume;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Toggle muteToggle;

    private void Start()
    {
        musicSlider.value = saveAndLoadAudio.LoadMusicVolume();
        sfxSlider.value = saveAndLoadAudio.LoadSfxVolume();
        muteToggle.isOn = saveAndLoadAudio.LoadIsMute();

        MusicSliderController(musicSlider.value);
        SfxSliderController(sfxSlider.value);
        MuteToggleController(muteToggle.isOn);
    }

    public void MusicSliderController(float volume)
    {
        setVolume.setMusicVolume(volume);
        saveAndLoadAudio.SaveMusicVolume(volume);
    }

    public void SfxSliderController(float volume)
    {
        setVolume.setSfxVolume(volume);
        saveAndLoadAudio.SaveSfxVolume(volume);
    }

    public void MuteToggleController(bool mute)
    {
        setVolume.setAllAudiosInMute(mute);
        saveAndLoadAudio.SaveIsMute(mute);
    }


}
