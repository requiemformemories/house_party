using UnityEngine;
using System.Collections;

//unity中使用Input.acceleration的x，y，z屬性即可獲得重力分量：
//Input.acceleration.x; 重力感應X軸的重力分量
//Input.acceleration.y; 重力感應Y軸的重力分量
//Input.acceleration.z; 重力感應Z軸的重力分量

public class EJ_MainController : MonoBehaviour {
	//
	private const float UpperBoundY = 1.2f;
	//
	private const float LowerBoundY = -4.0f; 
	//
	private const float f_isDown_threshold = 0.48f;
	//
	private const float speed = 5.0f;
	//
	private const float UpperBoundX = 0.35f;
	//
	private const float LowerBoundX = -0.35f;
	//位移至少要超過這個值才不會被視為是抖動，細微抖動不處理
	private const float twitchingThreshold = 0.01f;

	//private float gravX; // X方向的重力分量 (本情境中不使用)
	private float gravZ; // Z方向的重力分量 (本情境中將之轉換為Y方向位移)

	private float fYShift; // Y方向的位移量
	//private float fXShift; // X方向的位移量(本情境中不使用)
	//是否啟動本Script
    public bool isEnable;
    //新增是否躺好的bool
    public bool isDown;

    void Start(){
		gravZ = (float)-1.0;
		//gravX = (float)0.0;
		fYShift = 0.0f;
		//fXShift = 0.0f;
	}

	// Update is called once per frame
	void Update()
	{

		gravZ = Input.acceleration.y;

        //改成每偵判斷isDown布林值，實機測試前要啟用(去掉註解)
        if (gravZ >= 0.48)
            isDown = true;
        else
            isDown = false;

        if (isEnable)
        {

			if (gravZ < 0.10)
				fYShift = -transform.position.y + LowerBoundY;
			else if (gravZ >= 0.95)
				fYShift = -transform.position.y + UpperBoundY;
			else
				fYShift = -transform.position.y + (UpperBoundY - LowerBoundY) *
				(float)(gravZ - (float)0.10) / (float)0.85 + LowerBoundY;
        }

        //		gravX = Input.acceleration.x;
        //		if (gravX < -0.85)
        //			fXShift = -transform.position.x + LowerBoundX;
        //		else if (gravX >= 0.85)
        //			fXShift = -transform.position.x + UpperBoundX;
        //		else
        //			fXShift = -transform.position.x + (UpperBoundX - LowerBoundX) *
        //				(float)(gravX + (float)0.85) / (float)1.7 + LowerBoundX;

		if (isEnable && fYShift >= twitchingThreshold) 
		{
			//float step = speed * Time.deltaTime;
			Vector3 _v3 = new Vector3 (0, transform.position.y + fYShift, 0);
			//transform.Translate (0, fYShift, 0);
			transform.Translate (_v3 * Time.deltaTime * fYShift / Time.deltaTime, Space.World);
		}
	}


    //舊版API
    //public bool isDown()
    //{
    //    if (gravZ >= 0.48)
    //        return true;
    //    else
    //        return false;
    //}

	void OnGUI(){  
		//把抓取到的X,Y,Z軸分量放到畫面上  
		GUI.Label(new Rect(100,100,300,300),"x="+Input.acceleration.x+"   y="+Input.acceleration.y+"   z="+Input.acceleration.z);  
  
	}  
}