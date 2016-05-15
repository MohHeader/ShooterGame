using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Resetable))]
public class DespawnOnReset : MonoBehaviour {

	void Start () {
		GetComponent<Resetable>().OnReset += delegate() {
			SimplePool.Despawn(gameObject);
		};
	}
}
