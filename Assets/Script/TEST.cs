using UnityEngine;
using System.Collections;

public class TEST : MonoBehaviour {
    public UITweener MyTween;
    void OnClick()
    {
        MyTween.PlayForward();
    }
}
