using UnityEngine;
using System.Collections;

/// <summary>
/// Reset GameObject position to it's initial position.
/// Example : Player Ship, return to it's initial position when Game restarted.
/// </summary>

[RequireComponent(typeof(Resetable))]
public class ResetPosition : MonoBehaviour {
	Vector3 InitialPosition;

	void Start () {
		InitialPosition = transform.position;
	}

	void OnEnable(){
		GetComponent<Resetable> ().OnReset += Reset;
	}

	void OnDisable(){
		GetComponent<Resetable> ().OnReset -= Reset;
	}

	void Reset(){
		transform.position = InitialPosition;
	}
}
