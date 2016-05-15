using UnityEngine;
using System.Collections;

/// <summary>
/// if attached to a GameObject, Will Despawn self on Reset.
/// </summary>

[RequireComponent(typeof(Resetable))]
public class DespawnOnReset : MonoBehaviour {
	void Start () {
		GetComponent<Resetable>().OnReset += delegate() {
			SimplePool.Despawn(gameObject);
		};
	}
}
