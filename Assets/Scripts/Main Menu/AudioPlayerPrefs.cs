using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerPrefs : MonoBehaviour
{
    public static readonly float AbsentAudioPreferencesVolume = -1;
    private static readonly string MusicWord = "Music";
    private static readonly string SoundWord = "Sound";
    private static readonly string VolumeWord = "Volume";

    public static float GetMusicVolume()
    {
        string musicPreference = MusicWord + VolumeWord;
        return GetVolume(musicPreference);
    }

    public static void SaveMusicVolume(float musicVolume)
    {
        string musicPreference = MusicWord + VolumeWord;
        SetVolume(musicPreference, musicVolume);
    }

    public static float GetSoundVolume()
    {
        string musicPreference = SoundWord + VolumeWord;
        return GetVolume(musicPreference);
    }

    public static void SaveSoundVolume(float musicVolume)
    {
        string musicPreference = SoundWord + VolumeWord;
        SetVolume(musicPreference, musicVolume);
    }

    private static float GetVolume(string audioVolumePreference)
    {
        if (PlayerPrefs.HasKey(audioVolumePreference))
        {
            return PlayerPrefs.GetFloat(audioVolumePreference);
        }
        return AbsentAudioPreferencesVolume;
    }

    private static void SetVolume(string audioVolumePreference, float audioVolume)
    {
        PlayerPrefs.SetFloat(audioVolumePreference, audioVolume);
    }
}
