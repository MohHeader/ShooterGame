using UnityEngine;
using System.Collections;

public static class SpawnerHelper {

	public static Vector3 Top(){
		return WideTop(0);
	}

	public static Vector3 WideTop(float percentage = 1.5f){
		return new Vector3(Random.Range(-(1+percentage)*ScreenSize.Size.x, (1+percentage)*ScreenSize.Size.x), ScreenSize.Size.y, 0);
	}
}
