using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {
	void Awake () {
		// Keyboard Controller
		GetComponent<KeyboardController> ().OnControllerSet += GetComponent<ShipMovment> ().MoveBy;

		// Mouse Controller - Dummy not implemented
		// GetComponent<MouseController> ().OnUpdatePosition += GetComponent<ShipMovment> ().MoveTo;
	}
}
