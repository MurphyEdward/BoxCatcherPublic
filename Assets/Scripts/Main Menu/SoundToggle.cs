using System;

public class SoundToggle : AudioToggle
{
    protected override Func<float> ObtainAudioPreferencesGetMethod()
    {
        return AudioPlayerPrefs.GetSoundVolume;
    }

    protected override Action<float> ObtainAudioPreferencesSaveMethod()
    {
        return AudioPlayerPrefs.SaveSoundVolume;
    }
}
