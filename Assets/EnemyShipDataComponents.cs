using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Harmful))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(AddScoreOnHit))]
[RequireComponent(typeof(KillerZone))]
public class EnemyShipDataComponents : MonoBehaviour {

	SpriteRenderer spriteRenderer;
	Movement movment;
	Harmful harmful;
	Health health;
	AddScoreOnHit scoreOnHit;
	KillerZone killerZone;

	void Awake(){
		spriteRenderer = GetComponentInChildren<SpriteRenderer> ();
		if (spriteRenderer == null) {
			GameObject go = new GameObject ("View");
			go.transform.SetParent (transform, false);
			spriteRenderer = go.AddComponent<SpriteRenderer> ();
		}

		movment = gameObject.GetComponent<Movement> ();
		harmful = gameObject.GetComponent<Harmful> ();
		health  = gameObject.GetComponent<Health> ();
		scoreOnHit = gameObject.GetComponent<AddScoreOnHit> ();
		killerZone = gameObject.GetComponent<KillerZone> ();
	}

	public void SetShip(EnemyShipData data){
		if (data.Sprite != null) {
			spriteRenderer.sprite = data.Sprite;
		} else {
			Debug.LogError ("Enemy Ship should has a sprite to render !");
			return;
		}

		if (data.Speed > 0) {
			movment.enabled = true;
			movment.Speed = data.Speed;
		} else {
			movment.enabled = false;
		}

		if (data.CollisionDamage > 0 || data.DestroyOnCollision) {
			harmful.enabled = true;
			harmful.Amount = data.CollisionDamage;
			harmful.EnemyTag = "Player";
			harmful.SelfDestroy = data.DestroyOnCollision;
		} else {
			harmful.enabled = false;
		}

		if (data.MaxHealth > 0) {
			health.enabled = true;
			health.MaxHealth = data.MaxHealth;
		} else {
			health.enabled = false;
		}

		if (data.ScoreToAdd > 0) {
			scoreOnHit.enabled = true;
			scoreOnHit.ScoreToAdd = data.ScoreToAdd;
		} else {
			scoreOnHit.enabled = false;
		}

		killerZone.BottomZone	= data.BottomKillerZone;
		killerZone.TopZone		= data.TopKillerZone;
		killerZone.RightZone	= data.RightKillerZone;
		killerZone.LeftZone		= data.LeftKillerZone;
	}
}
