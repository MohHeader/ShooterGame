using UnityEngine;
using System.Collections;

[RequireComponent(typeof(KeyboardController))]
public class ShipMovment : MonoBehaviour {
	
	public float HorizontalSpeed 	= 	1;
	public float VerticalSpeed 		=	1;

	public float HorizontalMargin 	=	0;
	public float VerticalMargin 	=	0;

	KeyboardController controller;

	Vector2 ScreenSize;

	void Awake () {
		ScreenSize = Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.pixelWidth
			, Camera.main.pixelHeight));
	}

	public void MoveBy(float X, float Y){
		X *= HorizontalSpeed * Time.deltaTime;
		Y *= VerticalSpeed * Time.deltaTime;

		X += transform.position.x;
		Y += transform.position.y;

		SetPosition (new Vector2 (X, Y));
	}

	public void MoveTo(Vector2 target){
		// TODO: will be used for Mouse controller
	}

	void SetPosition(Vector2 pos){
		pos.x = Mathf.Clamp (pos.x, - ScreenSize.x + HorizontalMargin	, ScreenSize.x - HorizontalMargin);
		pos.y = Mathf.Clamp (pos.y, - ScreenSize.y + VerticalMargin		, ScreenSize.y - VerticalMargin);

		transform.position = pos;
	}
}
