using UnityEngine;
using System.Collections;
using System;

public class SoundManager : MonoBehaviour
{
    bool isfading = false;
    float fadingTime;
    float originalVolme;
    int i;
    public AudioSource UISoundSource;
    public AudioSource FxSoundSource;
    public AudioSource bgmSource1;
    public AudioSource bgmSource2;
    public AudioSource[] AudioSources;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;
    Action onFadeoutFinished;
    
    public enum Channel
    {
        UISoundSource,
        FxSoundSource,
        bgmSource1,
        bgmSource2
    }
    public static SoundManager instance = null;
    

	// SoundManager won't be destroy
	void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Debug.LogError("why is there two SoundManager instance?!");
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

	}

    void Start()
    {
        AudioSources = new AudioSource[] { UISoundSource, FxSoundSource, bgmSource1, bgmSource2 };
    }


     void FixedUpdate()
    {
        if (isfading)
        {
            AudioSources[i].volume -= (1/ fadingTime ) * Time.deltaTime;
            if (AudioSources[i].volume < 0.01)
            {
                AudioSources[i].Stop();
                AudioSources[i].volume = originalVolme;
                isfading = false;
                if (onFadeoutFinished != null)
                {
                    onFadeoutFinished();
                    onFadeoutFinished = null;
                }
            }
        }
    }

    /// <summary>
    /// Fadeout volume to 0 in FadeTime of Target SoundChannel, then stop the clip, return original Volumn
    /// </summary>
    /// <param name="FadeTime"></param>
    /// <param name="SoundChannel"></param>
    public void VolumeFadeout(float FadeTime , Channel SoundChannel)
    {
        fadingTime = FadeTime;
        i = (int)SoundChannel;
        originalVolme = AudioSources[i].volume;
        isfading = true;
    }

    public void StopAll()
    {
        bgmSource1.Stop();
        bgmSource2.Stop();
        FxSoundSource.Stop();
        UISoundSource.Stop();

    }

    /// <summary>
    /// Play Fx Sound Of UI System (Completely)
    /// </summary>
    /// <param name="clip"></param>
    public void PlayUISound(AudioClip clip)
    {
        float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);
        UISoundSource.pitch = randomPitch;
        if (UISoundSource.isPlaying == false)
        {
            UISoundSource.clip = clip;
            UISoundSource.Play();
        }
    }
    /// <summary>
    /// Play Fx Sound of Special Fx (Completely)
    /// </summary>
    /// <param name="clip"></param>

    public void PlayFxSound(AudioClip clip)
    {
        float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);
        FxSoundSource.pitch = randomPitch;
        if (FxSoundSource.isPlaying == false)
        {
            FxSoundSource.clip = clip;
            FxSoundSource.Play();
        }
    }
    /// <summary>
    /// Play Fx Sound Of UI System (Rplaceable)
    /// </summary>
    /// <param name="clip"></param>

    public void PlayUISound_Shot(AudioClip clip)
    {
        float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);
        UISoundSource.pitch = randomPitch;
        UISoundSource.clip = clip;
        UISoundSource.Play();
    }

    /// <summary>
    /// Play Fx Sound of Special Fx (Rplaceable)
    /// </summary>
    /// <param name="clip"></param>

    public void PlayFxSound_Shot(AudioClip clip)
    {
        float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);
        FxSoundSource.pitch = randomPitch;
        FxSoundSource.clip = clip;
        FxSoundSource.Play();
    }

    /// <summary>
    /// Play BGM Music of Chennal 1
    /// </summary>
    /// <param name="clip"></param>
    public void PlayBgm1(AudioClip clip)
    {
        if (isfading)
            onFadeoutFinished = new Action( ()=> { PlayBgm1(clip); });
        else
        {
                bgmSource1.clip = clip;
                bgmSource1.Play();
        }
    }
    /// <summary>
    /// Play BGM Music of Chennal 2
    /// </summary>
    /// <param name="clip"></param>
    public void PlayBgm2(AudioClip clip)
    {
        if (isfading)
            onFadeoutFinished = new Action(() => { PlayBgm2(clip); });
        else
        {
                bgmSource2.clip = clip;
                bgmSource2.Play();

        }
    }
    

}
