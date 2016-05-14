using UnityEngine;
using System.Collections;

public class RotateToTarget : MonoBehaviour {
	public void SetTarget(Transform target){
		transform.up = target.position - transform.position;
	}
}
