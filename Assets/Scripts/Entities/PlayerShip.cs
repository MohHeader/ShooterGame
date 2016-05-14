using UnityEngine;
using System.Collections;

[RequireComponent(typeof(KeyboardController))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Resetable))]

public class PlayerShip : MonoBehaviour {
	void Awake () {
		// Keyboard Controller
		GetComponent<KeyboardController> ().OnControllerSet += GetComponent<Movement> ().DirectionMove;

		// Mouse Controller - Dummy not implemented
		// GetComponent<MouseController> ().OnUpdatePosition += GetComponent<ShipMovment> ().MoveTo;
	}

	void Start(){
		GameStateMaster.Instance.OnGameStart += GetComponent<Resetable> ().Reset;
	}
}
