using UnityEngine;
using System.Collections;

/// <summary>
/// Just Rotate the View, while moving Left or Right.
/// </summary>

public class ShipRotationView : MonoBehaviour {
	void Awake () {
		GetComponentInParent<InputController> ().OnMovementControllerSet += delegate(Vector3 direction) {
			transform.rotation = Quaternion.Euler (transform.eulerAngles.x, direction.x * 30, transform.eulerAngles.z);
		};
	}
}
