using UnityEngine;
using System.Collections;

public class KillerZone : MonoBehaviour {
	public bool BottomZone;
	public bool TopZone;

	Vector3 Size;

	void Awake(){
		Size = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth
			, Camera.main.pixelHeight));
	}

	void Update () {
		if (BottomZone && transform.position.y < - Size.y) {
			SimplePool.Despawn (gameObject);
		}

		if (TopZone && transform.position.y > Size.y) {
			SimplePool.Despawn (gameObject);
		}
	}
}
