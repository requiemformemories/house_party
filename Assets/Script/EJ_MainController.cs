using UnityEngine;
using System.Collections;

//unity中使用Input.acceleration的x，y，z属性即可获得重力分量：
//Input.acceleration.x; 重力感应X轴的重力分量
//Input.acceleration.y; 重力感应Y轴的重力分量
//Input.acceleration.z; 重力感应Z轴的重力分量
//下面我们使用脚本来掩饰重力感应效果，分别控制贴图移动和方块移动。

public class EJ_MainController : MonoBehaviour {
	private float UpperBoundY;
	private float LowerBoundY; 

	private float UpperBoundX;
	private float LowerBoundX;

	private float gravX;
	private float gravZ;

	private float fYShift;
	private float fXShift;
    public bool isEnable;
    //新增是否躺好的bool
    public bool isDown;

    void Start(){
		UpperBoundY = (float)1.2;
		LowerBoundY = (float)-4;
		UpperBoundX = (float)0.35;
		LowerBoundX = (float)-0.35;
		gravZ = (float)-1.0;
		gravX = (float)0.0;
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

        transform.Translate (0, fYShift, 0);
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
		//将重力分量打印出来  
		GUI.Label(new Rect(100,100,300,300),"x="+Input.acceleration.x+"   y="+Input.acceleration.y+"   z="+Input.acceleration.z);  
  
	}  
}