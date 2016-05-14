using UnityEngine;
using System.Collections;

public class PositionLimitation : MonoBehaviour {
	public float HorizontalLimit 	=	0;
	public float VerticalLimit 	=	0;

	Vector3 ScreenSize;

	void Awake(){
		ScreenSize = Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.pixelWidth
			, Camera.main.pixelHeight));
	}

	void LateUpdate () {
		Vector3 pos = transform.position;

		pos.x = Mathf.Clamp (pos.x, - ScreenSize.x + HorizontalLimit	, ScreenSize.x - HorizontalLimit);
		pos.y = Mathf.Clamp (pos.y, - ScreenSize.y + VerticalLimit		, ScreenSize.y - VerticalLimit);

		transform.position = pos;
	}
}
