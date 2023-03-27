using System;

public class MusicToggle : AudioToggle
{
    protected override Func<float> ObtainAudioPreferencesGetMethod()
    {
        return AudioPlayerPrefs.GetMusicVolume;
    }

    protected override Action<float> ObtainAudioPreferencesSaveMethod()
    {
        return AudioPlayerPrefs.SaveMusicVolume;
    }
}
