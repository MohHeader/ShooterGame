using UnityEngine;
using System.Collections;

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
