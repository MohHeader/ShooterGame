using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Harmful))]
[RequireComponent(typeof(Movement))]
public class Bullet : MonoBehaviour {
	public void SetDate(BulletData data){
		GetComponent<Harmful> ().Amount = data.DamageAmount;
		GetComponent<Movement> ().Speed = data.Speed;
		transform.localScale = Vector3.one *  data.Scale;
	}
}
