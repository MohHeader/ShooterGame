using UnityEngine;
using System.Collections;

/// <summary>
/// Keyboard controller
/// Using Unity Input system
/// </summary>
public class InputController : MonoBehaviour {
	public float Horizontal { get; protected set; }
	public float Vertical 	{ get; protected set; }

	public static bool IsFiring { get; protected set; }

	void Update () {
		if (GameStateMaster.IsPlaying ()) {
			Horizontal = Input.GetAxisRaw ("Horizontal");
			Vertical = Input.GetAxisRaw ("Vertical");

			if (OnMovementControllerSet != null)
				OnMovementControllerSet (new Vector3(Horizontal, Vertical, 0));

			if (OnMouseUpdatePosition != null) {
				Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				mouse.z = 0;
				OnMouseUpdatePosition (mouse);
			}

			if (Input.GetButton ("Fire1") || Input.GetButton ("Fire2")) {
				IsFiring = true;

				if (OnFireControllerSet != null)
					OnFireControllerSet ();
			} else {
				IsFiring = false;
			}

		} else {
			Horizontal = 0;
			Vertical = 0;
			IsFiring = false;
		}
	}

	public event System.Action<Vector3> OnMovementControllerSet;
	public event System.Action OnFireControllerSet;
	public event System.Action<Vector3> OnMouseUpdatePosition;
}
