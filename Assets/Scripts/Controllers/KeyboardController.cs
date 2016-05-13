using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {
	public float Horizontal { get; protected set; }
	public float Vertical 	{ get; protected set; }

	void Update () {
		if (GameStateMaster.IsPlaying ()) {
			Horizontal = Input.GetAxis ("Horizontal");
			Vertical = Input.GetAxis ("Vertical");

			if (OnControllerSet != null)
				OnControllerSet (Horizontal, Vertical);

		} else {
			Horizontal = 0;
			Vertical = 0;
		}
	}

	public event System.Action<float, float> OnControllerSet;
}
