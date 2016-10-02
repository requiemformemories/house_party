using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour {
    public int StageID;
    public string SceneName;
    public float BlackFadinTime;
    public bool IsNormalButton;
    public bool IsIdAssignedButton;
    public bool IsTestMode;
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
