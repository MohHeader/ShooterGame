using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Resetable))]
public class ResetPosition : MonoBehaviour {
	Vector3 OriginalPosition;

	void Start () {
		OriginalPosition = transform.position;
		GetComponent<Resetable> ().OnReset += delegate() {
			transform.position = OriginalPosition;
		};
	}
}
