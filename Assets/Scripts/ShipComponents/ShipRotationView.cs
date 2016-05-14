using UnityEngine;
using System.Collections;

public class ShipRotationView : MonoBehaviour {
	void Awake () {
		GetComponentInParent<KeyboardController> ().OnControllerSet += delegate(Vector3 direction) {
			transform.rotation = Quaternion.Euler (transform.eulerAngles.x, direction.x * 30, transform.eulerAngles.z);
		};
	}
}
