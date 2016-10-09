using UnityEngine;
using System.Collections;

public class TEST : MonoBehaviour {
    public EJ_MainController Ctrl;

    void Start()
    {
    }
    public void StandSwich()
    {
        if (Ctrl.isDown == true)
            Ctrl.isDown = false;
        else
            Ctrl.isDown = true;
    }
}
