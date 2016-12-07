using UnityEngine;
using System.Collections;

public class MyCursor : MonoBehaviour
{
    float countdown;
    bool isPressedBtn;
    GameObject btn;

    public void EnableMe()
    {
        gameObject.SetActive(true);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Button")
        {
            btn = other.gameObject;
            NGUITools.AddChild(other.gameObject, (GameObject)Resources.Load("StarEffect"));
            isPressedBtn = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Button")
        {
            Destroy(GameObject.Find("StarEffect(Clone)"));
            Awake();
        }
    }


    void Awake()
    {
        countdown = 1f;
        isPressedBtn = false;
    }

    void FixedUpdate()
    {
        if (isPressedBtn)
        {
            Debug.Log(countdown);
            if (countdown > 0)
                countdown -= Time.deltaTime;
            else
                EventDelegate.Execute(btn.gameObject.GetComponent<UIEventTrigger>().onClick);
            

        }
    }
}
