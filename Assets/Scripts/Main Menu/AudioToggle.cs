using System;
using UnityEngine;

public abstract class AudioToggle : MonoBehaviour
{
    private const float _toggledOffVolume = 0;

    private AudioSource _audioSource;
    private float _initialVolume;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _initialVolume = _audioSource.volume;
        LoadAudioPreferences(ObtainAudioPreferencesGetMethod());
    }

    private void LoadAudioPreferences(Func<float> getAudioPreferences)
    {
        float audioPreferencesVolume = getAudioPreferences();

        if (audioPreferencesVolume != AudioPlayerPrefs.AbsentAudioPreferencesVolume)
        {
            _audioSource.volume = audioPreferencesVolume;
        }
    }

    public void ToggleAudio()
    {
        _audioSource.volume = _audioSource.volume == _toggledOffVolume ? _initialVolume : _toggledOffVolume;

        SaveAudioVolume();
    }

    private void SaveAudioVolume()
    {
        Action<float> audioPreferencesSaveMethod = ObtainAudioPreferencesSaveMethod();
        audioPreferencesSaveMethod(_audioSource.volume);
    }

    protected abstract Func<float> ObtainAudioPreferencesGetMethod();

    protected abstract Action<float> ObtainAudioPreferencesSaveMethod();
}
