using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Resetable))]
public class Movement : MonoBehaviour {
	
	public float Speed 	= 	1;

	public void DirectionMove(Vector3 direction){
		if (GameStateMaster.IsPlaying () == false)
			return;

		transform.position += direction.normalized * Speed * Time.deltaTime;
	}

	public void TargetMove(Vector3 target){
		// TODO: will be used for Mouse controller
	}
}
