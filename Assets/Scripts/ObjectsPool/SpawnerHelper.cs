using UnityEngine;
using System.Collections;

/// <summary>
/// Just an helper to get Random positoin to Spawn on.
/// </summary>

public static class SpawnerHelper {

	public static Vector3 Top(){
		return WideTop(0);
	}

	public static Vector3 WideTop(float percentage = 1.5f){
		return new Vector3(Random.Range(-(1+percentage)*ScreenSize.Size.x, (1+percentage)*ScreenSize.Size.x), ScreenSize.Size.y, 0);
	}
}
