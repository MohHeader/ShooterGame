using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public GameObject Bullet;
	public BulletData data;

	public float CoolDownTime;
	float untilCoolDown = 0;

	static Transform BulletsParent;

	void Awake(){
		if (BulletsParent == null) {
			BulletsParent = GameObject.Find ("Bullets PlaceHolder").transform;
		}
	}

	void Update () {
		if (GameStateMaster.IsPlaying () == false)
			return;
		
		untilCoolDown += Time.deltaTime;
	}

	public void Fire(){
		if (untilCoolDown >= CoolDownTime) {
			untilCoolDown = 0;

			GameObject go = SimplePool.Spawn (Bullet, transform.position, Quaternion.identity);
			go.transform.SetParent (BulletsParent);

			go.GetComponent<Bullet> ().SetDate (data);
		}
	}
}
