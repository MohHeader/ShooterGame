using UnityEngine;
using System.Collections;

public class KillerZone : MonoBehaviour {
	void Update () {
		if (transform.position.y < - Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.pixelWidth
			, Camera.main.pixelHeight)).y)
			SimplePool.Despawn (gameObject);
	}
}
