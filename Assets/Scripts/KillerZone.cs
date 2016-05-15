using UnityEngine;
using System.Collections;

public class KillerZone : MonoBehaviour {
	public bool BottomZone;
	public bool TopZone;

	public bool RightZone;
	public bool LeftZone;

	Vector3 Size;

	void Awake(){
		Size = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth
			, Camera.main.pixelHeight));
	}

	void Update () {
		if (BottomZone && transform.position.y < - Size.y) {
			SimplePool.Despawn (gameObject);
		}
		else if (TopZone && transform.position.y > Size.y) {
			SimplePool.Despawn (gameObject);
		}
		else if (RightZone && transform.position.x > Size.x) {
			SimplePool.Despawn (gameObject);
		}
		else if (LeftZone && transform.position.x < - Size.x) {
			SimplePool.Despawn (gameObject);
		}
	}
}
