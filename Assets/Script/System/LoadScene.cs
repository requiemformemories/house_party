using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour {
    public string SceneName;
    public TweenAlpha blk;
    public TweenAlpha btn;



    void OnClick()
    {
        blk.onFinished.Add(new EventDelegate(() =>
        {
            SceneManager.LoadScene(SceneName);
        }));
        blk.PlayForward();
        btn.PlayForward();
    }


}
