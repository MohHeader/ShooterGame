using UnityEngine;
using System.Collections;

[System.Serializable]
public class EnemyShipData {
	[Header("Data")]
	public Sprite	Sprite;
	public float	Speed;
	public float	CollisionDamage;
	public bool		DestroyOnCollision;

	[Range(0,99)]
	public float	MaxHealth;

	public int		ScoreToAdd;

	[Header("KillerZones")]
	public bool		BottomKillerZone;
	public bool		TopKillerZone;
	public bool		RightKillerZone;
	public bool		LeftKillerZone;

	[Header("Behavior")]
	public ShipBehavior shipBehavior;
}
