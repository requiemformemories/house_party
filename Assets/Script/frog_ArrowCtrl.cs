using UnityEngine;
using System.Collections;

public class frog_ArrowCtrl : MonoBehaviour {
    public EJ_MainController Ctrl;
    public bool isShootable = false;
    bool isDown;
    bool isStand;
    int energy;
    int skill;
    int dmg;
    public UISprite ShootSprite;
    public UISprite Arrow;
    public UISpriteAnimation A_Shoot;
    public UISprite EnergyBar;
    frog_Monster Mon;
    // Use this for initialization
    public void IsStand()
    {
        if (isStand)
        {
            isStand = false;
        }
        else
            isStand = true;
        Debug.Log(isStand);

    }
    public void IsDown()
    {
        if (isDown)
        {
            isDown = false;
        }
        else
            isDown = true;
        //Debug.Log(isDown);

    }

    void Start ()
    {
        energy = 0;
        skill = -1;
        dmg = 0;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        isDown = Ctrl.isDown();

        EnergyBar.fillAmount = (float)energy / 100f;
        //Debug.Log(energy);
        if (isDown)
        {
            if (energy < 100)
            {

                energy++;
                if (!Arrow.enabled)
                {
                    Arrow.enabled = true;
                }
            }
        }
        else
            if (energy > 0)
                {
                    energy = 0;
                    if (isShootable)
                    {
                        shoot();
                        energy = 0;
                    }

                }


    }
    


    void shoot()
    {
        Arrow.enabled = false;
        ShootSprite.enabled = true;
        A_Shoot.Play();
        if (energy == 100)
        {
            frog_Stagedata.instance.combo++;
            if (frog_Stagedata.instance.combo > 6)
            {
                frog_Stagedata.instance.isFever = true;
            }
            else
                frog_Stagedata.instance.isFever = false;
        }
        else
        {
            frog_Stagedata.instance.combo = 0;
            frog_Stagedata.instance.isFever = false;    

        }
        skill = Random.Range(0, 5);
        //switch (skill)
        //{
        //    case 0:
        //        dmg = Random.Range(10000, 15000);
        //        break;
        //    case 1:
        //        dmg = Random.Range(20000, 25000);
        //        break;
        //    case 2:
        //        dmg = Random.Range(30000, 35000);
        //        break;
        //    case 3:
        //        dmg = 400;
        //        break;
        //    case 4:
        //        dmg = Random.Range(20000, 100000);
        //        break;
        //}
        //Debug.Log(dmg);
        Mon = GameObject.FindObjectOfType<frog_Monster>();
        //Debug.Log(Mon);
        Mon.Hp = 0;
    }
}
