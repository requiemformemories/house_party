using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour {
    public string SceneName;
    public TweenAlpha Black;
    public TweenAlpha White;
    public TweenAlpha TweenEffect;
    public bool isHeavenBtn;


    public void OnClick()
    {
        if (isHeavenBtn)
        {
            White.onFinished.Add(new EventDelegate(() =>
            {
                SceneManager.LoadScene(SceneName);
                SoundManager.instance.VolumeFadeout(1, SoundManager.Channel.bgmSource1);
            }));
            White.PlayForward();

        }
        else
        {

            Black.onFinished.Add(new EventDelegate(() =>
            {
                SceneManager.LoadScene(SceneName);
                SoundManager.instance.VolumeFadeout(1,SoundManager.Channel.bgmSource1);

            }));
            Black.PlayForward();
            if(TweenEffect != null)
            TweenEffect.PlayForward();
        }
    }


}
