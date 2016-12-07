using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour {
    TweenAlpha FadeTA;
    UISprite FadeSprite;
    GameObject Fade;
    public enum Scenes
    {
        MainMenu,
        Normal,
        Hard,
        Endless,
    }

    public Scenes TargetScene;
    public float DelayTime;
    public float FadeTime;
    public TweenAlpha TweenEffect;
    public bool UseWhiteFade;




    void Awake()
    {
        Fade = (GameObject)Instantiate(Resources.Load("White"));
        Fade.transform.position = Vector3.zero;
        Fade.transform.parent = GameObject.Find("Camera").transform;
        FadeSprite = Fade.GetComponent<UISprite>();
        FadeTA = Fade.GetComponent<TweenAlpha>();
        FadeTA.duration = FadeTime;
    }

    public void OnClick()
    {
        switch (TargetScene)
        {
            case Scenes.MainMenu:
                this.Invoke("GoMainMenu", DelayTime);
                break;
            case Scenes.Normal:
                Parameter.Mode = 0;
                this.Invoke("GoStage",DelayTime);
                break;
            case Scenes.Hard:
                Parameter.Mode = 1;
                this.Invoke("GoStage", DelayTime);
                break;
            case Scenes.Endless:
                Parameter.Mode = 2;
                this.Invoke("GoStage", DelayTime);
                break;
        }

    }

    void GoStage()
    {
        if (UseWhiteFade)
        {
            FadeTA.onFinished.Add(new EventDelegate(() =>
            {
                SceneManager.LoadScene("Stage");
                SoundManager.instance.VolumeFadeout(1, SoundManager.Channel.bgmSource1);
            }));
            FadeTA.PlayForward();
        }
        else
        {
            FadeSprite.color = Color.black;
            FadeTA.onFinished.Add(new EventDelegate(() =>
            {
                SceneManager.LoadScene("Stage");
                SoundManager.instance.VolumeFadeout(1, SoundManager.Channel.bgmSource1);
            }));
            FadeTA.PlayForward();
            if (TweenEffect != null)
                TweenEffect.PlayForward();
        }
    }

    void GoMainMenu()
    {
        if (UseWhiteFade)
        {
            FadeTA.onFinished.Add(new EventDelegate(() =>
            {
                SceneManager.LoadScene("FTScene");
                SoundManager.instance.VolumeFadeout(1, SoundManager.Channel.bgmSource1);
            }));
            FadeTA.PlayForward();
        }
        else
        {
            FadeSprite.color = Color.black;
            FadeTA.onFinished.Add(new EventDelegate(() =>
            {
                SceneManager.LoadScene("FTScene");
                SoundManager.instance.VolumeFadeout(1, SoundManager.Channel.bgmSource1);
            }));
            FadeTA.PlayForward();
            if (TweenEffect != null)
                TweenEffect.PlayForward();
        }

    }


}
