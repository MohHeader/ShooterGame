using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public GameObject Bullet;
	public float Frequency;
	float untilFrequency = 0;

	static Transform BulletsParent;

	void Awake(){
		if (BulletsParent == null) {
			BulletsParent = GameObject.Find ("Bullets").transform;
		}
	}

	void Update () {
		untilFrequency += Time.deltaTime;

		if (untilFrequency >= Frequency &&  Input.GetButton ("Fire1")) {
			untilFrequency = 0;
			SimplePool.Spawn (Bullet, transform.position, Quaternion.identity).transform.SetParent (BulletsParent);
		}
	}
}
