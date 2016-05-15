using UnityEngine;
using System.Collections;

[RequireComponent(typeof(InputController))]
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Resetable))]
public class PlayerShip : MonoBehaviour {
	Gun[] guns;

	void Awake () {
		guns = GetComponentsInChildren<Gun> ();

		// Keyboard Controller
		GetComponent<InputController> ().OnMovementControllerSet += GetComponent<Movement> ().DirectionMove;

		// Mouse Controller - For Better Controller Enable only one Either Mouse Controller or Keyboard Controller
//		GetComponent<InputController> ().OnMouseUpdatePosition += GetComponent<Movement> ().TargetMove;

		GetComponent<InputController> ().OnFireControllerSet += delegate() {
			foreach(var gun in guns)
				gun.Fire();
		};
	}

	void Start(){
		GameStateMaster.Instance.OnGameStart += GetComponent<Resetable> ().Reset;
	}
}
