using UnityEngine;
using System.Collections;

/// <summary>
/// if attached to a GameObject, Will Despawn self after a specific time.
/// </summary>
public class SelfDespawnTimer : MonoBehaviour {
	public float Timer;

	float timerCounter;

	void OnEnable(){
		timerCounter = 0;
	}

	void Update () {
		if (GameStateMaster.IsPlaying () == false)
			return;

		timerCounter += Time.deltaTime;

		if (timerCounter >= Timer)
			SimplePool.Despawn (gameObject);
	}
}
