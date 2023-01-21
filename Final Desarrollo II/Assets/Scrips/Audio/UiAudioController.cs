using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UiAudioController : MonoBehaviour
{
    [SerializeField] SaveAndLoadAudio saveAndLoadAudio;
    [SerializeField] SetVolume setVolume;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] Toggle muteToggle;

    //inicializar con el save and load

    private void Start()
    {
        musicSlider.value = saveAndLoadAudio.LoadMusicVolume();
        sfxSlider.value = saveAndLoadAudio.LoadSfxVolume();
        muteToggle.value = saveAndLoadAudio.LoadIsMute();
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
