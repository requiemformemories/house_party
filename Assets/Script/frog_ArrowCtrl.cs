using UnityEngine;
using System.Collections;

public class frog_ArrowCtrl : MonoBehaviour {

    public bool isShootable = false;
    bool isDown;
    bool isStand;
    int energy;
    int skill;
    int dmg;
    public UISprite A_Soul;
    public UISprite Arrow;
    public UI2DSpriteAnimation A_Shoot;

	// Use this for initialization
	void Start ()
    {
        energy = 0;
        skill = -1;
        dmg = 0;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (energy <100)
        {
            if (isDown)
            {
                energy++;
                if (!Arrow.enabled)
                {
                    Arrow.enabled = true;
                }
            }
            else
                energy--;
        }
        if (isStand)
        {
            if (isShootable)
            {
                shoot();
                energy = 0;
            }
        }
    }
    

    void shoot()
    {

        A_Shoot.Play();
        
        skill = Random.Range(0, 5);
        switch (skill)
        {
            case 0:
                dmg = Random.Range(100, 150);
                break;
            case 1:
                dmg = Random.Range(200, 250);
                break;
            case 2:
                dmg = Random.Range(300, 350);
                break;
            case 3:
                dmg = 400;
                break;
            case 4:
                dmg = Random.Range(200, 1000);
                break;
        }


    }
}
