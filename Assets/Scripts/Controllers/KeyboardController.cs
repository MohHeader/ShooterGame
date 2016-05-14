using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {
	public float Horizontal { get; protected set; }
	public float Vertical 	{ get; protected set; }

	void Update () {
		if (GameStateMaster.IsPlaying ()) {
			Horizontal = Input.GetAxisRaw ("Horizontal");
			Vertical = Input.GetAxisRaw ("Vertical");

			if (OnControllerSet != null)
				OnControllerSet (new Vector3(Horizontal, Vertical, 0));

		} else {
			Horizontal = 0;
			Vertical = 0;
		}
	}

	public event System.Action<Vector3> OnControllerSet;
}
