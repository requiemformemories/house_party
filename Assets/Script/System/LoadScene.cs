using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour {
    public string SceneName;
    public TweenAlpha BlackFade;
    public TweenAlpha WhiteForHeaven;
    public TweenAlpha TweenEffect;
    public bool isHeavenBtn;


    public void OnClick()
    {
        if (isHeavenBtn)
        {
            WhiteForHeaven.onFinished.Add(new EventDelegate(() =>
            {
                SceneManager.LoadScene(SceneName);
                SoundManager.instance.VolumeFadeout(1, SoundManager.Channel.bgmSource1);
            }));
            WhiteForHeaven.PlayForward();

        }
        else
        {

            BlackFade.onFinished.Add(new EventDelegate(() =>
            {
                SceneManager.LoadScene(SceneName);
                SoundManager.instance.VolumeFadeout(1,SoundManager.Channel.bgmSource1);

            }));
            BlackFade.PlayForward();
            if(TweenEffect != null)
            TweenEffect.PlayForward();
        }
    }


}
