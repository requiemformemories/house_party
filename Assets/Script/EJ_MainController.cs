using UnityEngine;
using System.Collections;

//unity中使用Input.acceleration的x，y，z属性即可获得重力分量：
//Input.acceleration.x; 重力感应X轴的重力分量
//Input.acceleration.y; 重力感应Y轴的重力分量
//Input.acceleration.z; 重力感应Z轴的重力分量
//下面我们使用脚本来掩饰重力感应效果，分别控制贴图移动和方块移动。

public class EJ_MainController : MonoBehaviour {
	private int UpperBoundY;
	private int LowerBoundY;
	private float x,y;//贴图的坐标  
	private float gravZ;
	private float fYShift;

	void Start(){x = 0; y = 0;
		UpperBoundY = 1200;
		LowerBoundY = -600;
		gravZ = (float)-1.0;
		fYShift = (float)0.0;
	}

	// Update is called once per frame
	void Update()
	{
		gravZ = Input.acceleration.z;
		if (gravZ < 0.0)
			transform.Translate(0,transform.position.y - LowerBoundY,0);
		else if (gravZ >= 0.95)
			transform.TransformPoint(0,UpperBoundY - transform.position.y,0);
		else
			transform.TransformPoint(0,(transform.position.y - ((1800 * gravF + 1200) + 600 )),0);
	}

	public bool isStandUp(){
		if ((gravF - Mathf.Abs((float)-1.0)) <= 0.05) {
			return false;
		} else {
			return true;
		}
	}
	void OnGUI(){  
		//将重力分量打印出来  
		GUI.Label(new Rect(100,100,300,300),"x="+Input.acceleration.x+"   y="+Input.acceleration.y+"   z="+Input.acceleration.z);  
  
	}  
}