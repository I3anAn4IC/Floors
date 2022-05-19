using System.Linq;
using Fungus;
using UnityEngine;
using UnityEngine.Audio;

public class StaticMusicObject : MonoBehaviour
{
    public AudioMixer audioMixer;
    private void Awake()
    {
        var audioSources = FungusManager.Instance.GetComponents<AudioSource>();
        var mgroup = audioMixer.FindMatchingGroups("Master").First();
        foreach (var audioSource in audioSources)
        {
            audioSource.outputAudioMixerGroup = mgroup;
        }

        if (!FungusPrefs.HasKey(0, "Volume"))
        {
            FungusPrefs.SetFloat(0,"Volume", 1f);
            FungusPrefs.Save();
        }
        DebugLog.print(FungusPrefs.GetFloat(0, "Volume"));
        audioMixer.SetFloat("volume", FungusPrefs.GetFloat(0, "Volume"));
    }

}
