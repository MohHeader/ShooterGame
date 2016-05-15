using UnityEngine;
using System.Collections;

public class KillerZone : MonoBehaviour {
	public bool BottomZone;
	public bool TopZone;

	public bool RightZone;
	public bool LeftZone;

	void Update () {
		if (BottomZone && transform.position.y < - ScreenSize.Size.y) {
			SimplePool.Despawn (gameObject);
		}
		else if (TopZone && transform.position.y > ScreenSize.Size.y) {
			SimplePool.Despawn (gameObject);
		}
		else if (RightZone && transform.position.x > ScreenSize.Size.x) {
			SimplePool.Despawn (gameObject);
		}
		else if (LeftZone && transform.position.x < - ScreenSize.Size.x) {
			SimplePool.Despawn (gameObject);
		}
	}
}
