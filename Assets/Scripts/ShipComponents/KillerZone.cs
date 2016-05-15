using UnityEngine;
using System.Collections;

/// <summary>
/// Killer zone, describes what Edge should despawn the gameobject when reached,
/// For Example : Player Bullets, would be destroyed when reached the top edge.
/// With four toggable edges, to provide maximum amount of control
/// </summary>
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
