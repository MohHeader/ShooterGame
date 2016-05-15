using UnityEngine;
using System.Collections;

/// <summary>
/// if attached to a GameObject, Will Despawn self on OnGameStart.
/// </summary>

[RequireComponent(typeof(Resetable))]
public class DespawnOnReset : MonoBehaviour {
	void Start () {
		GameStateMaster.Instance.OnGameStart += delegate() {
			SimplePool.Despawn(gameObject);
		};
	}
}
