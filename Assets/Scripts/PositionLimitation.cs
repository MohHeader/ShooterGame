using UnityEngine;
using System.Collections;

public class PositionLimitation : MonoBehaviour {
	public float HorizontalLimit 	=	0;
	public float VerticalLimit 	=	0;

	void LateUpdate () {
		Vector3 pos = transform.position;

		pos.x = Mathf.Clamp (pos.x, - ScreenSize.Size.x + HorizontalLimit	, ScreenSize.Size.x - HorizontalLimit);
		pos.y = Mathf.Clamp (pos.y, - ScreenSize.Size.y + VerticalLimit		, ScreenSize.Size.y - VerticalLimit);

		transform.position = pos;
	}
}
