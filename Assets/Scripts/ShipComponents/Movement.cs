using UnityEngine;
using System.Collections;

/// <summary>
/// This Script, is the real responsible to position the GameObject in the SceneView
/// Currently, Only one script could override it's effect ( PositionLimitation.cs ) 
/// </summary>

[RequireComponent(typeof(Resetable))]
public class Movement : MonoBehaviour {
	public float Speed		= 1;
	float SAFE_THRESHOLD 	= 0.3f;

	// Move in a specific Direction
	public void DirectionMove(Vector3 direction){
		if (GameStateMaster.IsPlaying () == false)
			return;

		transform.position += direction.normalized * Speed * Time.deltaTime;
	}

	// Move toward a specific Target
	public void TargetMove(Vector3 target){
		if(Vector3.Distance(target, transform.position) > SAFE_THRESHOLD)
			DirectionMove (target - transform.position);
	}
}
