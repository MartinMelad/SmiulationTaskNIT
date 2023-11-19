using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager 
{
    #region Fields

    private static bool  initialized = false;
    private static AudioSource audioSource;
    private static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    #endregion

    #region properties

    public static bool Initialized
    {
        get { return initialized; }
    }

    #endregion

    #region Public Methods

    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        
        audioClips.Add(AudioClipName.BakraFak,
            Resources.Load<AudioClip>("فك البكرة"));
        audioClips.Add(AudioClipName.NutFak,
            Resources.Load<AudioClip>("فك الصامولة"));
        audioClips.Add(AudioClipName.NutReturn,
            Resources.Load<AudioClip>("ارجاع الصامولة"));
        audioClips.Add(AudioClipName.NutRpt,
            Resources.Load<AudioClip>("ربط الصامولة"));
        audioClips.Add(AudioClipName.BakraReturn,
            Resources.Load<AudioClip>("ارجاع البكرة"));
        audioClips.Add(AudioClipName.BakraRpt,
            Resources.Load<AudioClip>("ربط البكرة"));
        audioClips.Add(AudioClipName.Con,
            Resources.Load<AudioClip>("مبروك"));
        audioClips.Add(AudioClipName.ClicButton,
            Resources.Load<AudioClip>("ClicButton3"));
    }

    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }

    #endregion
}
