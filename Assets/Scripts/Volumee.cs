using Fungus;
using UnityEngine;
using UnityEngine.Audio;

public class Volumee : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Awake()
    {
        var audioSources = FungusManager.Instance.GetComponents<AudioSource>();
        foreach (var audioSource in audioSources)
        {
            audioSource.outputAudioMixerGroup = audioMixer.outputAudioMixerGroup;
        }
        if (!FungusPrefs.HasKey(0, "Volume"))
        {
            FungusPrefs.SetFloat(0,"Volume", 1f);
            FungusPrefs.Save();
        }
        audioMixer.SetFloat("volume", FungusPrefs.GetFloat(0,"Volume"));
    }

    public void SetVolume(float sliderValue)
    {
        var v = -80 + sliderValue*100;
        FungusPrefs.SetFloat(0,"Volume", v);
        audioMixer.SetFloat("volume", v);
        FungusPrefs.Save();
    }
}
