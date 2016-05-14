using UnityEngine;
using System.Collections;

[RequireComponent(typeof(KeyboardController))]
public class ShipMovment : MonoBehaviour {
	
	public float Speed 	= 	1;

	public float HorizontalMargin 	=	0;
	public float VerticalMargin 	=	0;

	KeyboardController controller;

	Vector3 ScreenSize;
	Vector3 OriginalPosition;

	void Awake () {
		OriginalPosition = transform.position;
		ScreenSize = Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.pixelWidth
			, Camera.main.pixelHeight));
	}

	void Start(){
		GameStateMaster.Instance.OnGameStart += delegate() {
			transform.position = OriginalPosition;
		};
	}

	public void DirectionMove(Vector3 direction){
		direction = direction.normalized * Speed * Time.deltaTime;
		direction += transform.position;

		SetPosition (direction);
	}

	public void TargetMove(Vector3 target){
		// TODO: will be used for Mouse controller
	}

	void SetPosition(Vector3 pos){
		pos.x = Mathf.Clamp (pos.x, - ScreenSize.x + HorizontalMargin	, ScreenSize.x - HorizontalMargin);
		pos.y = Mathf.Clamp (pos.y, - ScreenSize.y + VerticalMargin		, ScreenSize.y - VerticalMargin);

		transform.position = pos;
	}
}
