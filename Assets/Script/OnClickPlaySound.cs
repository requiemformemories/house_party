using UnityEngine;
using System.Collections;

public class OnClickPlaySound : MonoBehaviour {
    public AudioClip SoundResource;
    public float DelayTime = 0;
    public enum AudioTrack
    {
        BGM1,
        BGM2,
        Sfx1,
        Sfx2,
        Sfx1_Shot,
        Sfx2_Shot,
    }

    public AudioTrack audiotrack;

	void OnClick()
    {
        this.Invoke("play", DelayTime);
    }

    void play()
    {
        if (SoundResource != null)
        {
            if (audiotrack == AudioTrack.BGM1)
                SoundManager.instance.PlayBgm1(SoundResource);
            else if (audiotrack == AudioTrack.BGM2)
                SoundManager.instance.PlayBgm2(SoundResource);
            else if (audiotrack == AudioTrack.Sfx1)
                SoundManager.instance.PlayUISound(SoundResource);
            else if (audiotrack == AudioTrack.Sfx2)
                SoundManager.instance.PlayFxSound(SoundResource);
            else if (audiotrack == AudioTrack.Sfx1_Shot)
                SoundManager.instance.PlayUISound_Shot(SoundResource);
            else if (audiotrack == AudioTrack.Sfx2_Shot)
                SoundManager.instance.PlayFxSound_Shot(SoundResource);
        }
        else
            Debug.Log("SoundResource not found");
    }

}
