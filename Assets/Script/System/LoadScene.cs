using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour {
    public string SceneName;
    public TweenAlpha blk;
    public TweenAlpha white;
    public TweenAlpha btn;
    public bool isHeavenBtn;


    public void OnClick()
    {
        if (isHeavenBtn)
        {
            white.onFinished.Add(new EventDelegate(() =>
            {
                SceneManager.LoadScene(SceneName);
            }));
            white.PlayForward();

        }
        else
        {
            blk.onFinished.Add(new EventDelegate(() =>
            {
                SceneManager.LoadScene(SceneName);
            }));
            blk.PlayForward();
            btn.PlayForward();
        }
    }


}
