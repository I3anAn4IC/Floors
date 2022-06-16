using Fungus;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volumee : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] public Image image;
    [SerializeField] private Slider slider; 

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

    private void Start()
    {
        if (slider == null) return;
        var saved = FungusPrefs.GetFloat(0, "Volume");
        slider.value = (saved + 80) / 100;
    }

    public void SetVolume(float sliderValue)
    {
        var v = -80 + sliderValue*100;
        FungusPrefs.SetFloat(0,"Volume", v);
        audioMixer.SetFloat("volume", v);
        FungusPrefs.Save();
        if (sliderValue == 0f)
        {
            image.sprite = Resources.Load<Sprite>("non_sound");
        }
        else
        {
            image.sprite = Resources.Load<Sprite>("sound");
        }
    }
}
