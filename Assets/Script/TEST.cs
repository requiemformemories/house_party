using UnityEngine;
using System.Collections;

public class TEST : MonoBehaviour {
    public EJ_MainController Ctrl;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StandSwich();
        }
        
    }
    public void StandSwich()
    {
        if (Ctrl.isDown == true)
            Ctrl.isDown = false;
        else
            Ctrl.isDown = true;
    }
}
