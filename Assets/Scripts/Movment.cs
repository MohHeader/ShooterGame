using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Resetable))]
public class Movment : MonoBehaviour {
	
	public float Speed 	= 	1;

	public void DirectionMove(Vector3 direction){
		direction = direction.normalized * Speed * Time.deltaTime;

		transform.position += direction;
	}

	public void TargetMove(Vector3 target){
		// TODO: will be used for Mouse controller
	}
}
