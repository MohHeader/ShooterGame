using UnityEngine;
using System.Collections;

public static class SpawnerHelper {

	public static Vector3 Top(){
		return WideTop(0);
	}

	public static Vector3 WideTop(float percentage = 1.5f){
		Vector3 ScreenSize = Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.pixelWidth
			, Camera.main.pixelHeight));

		return new Vector3(Random.Range(-(1+percentage)*ScreenSize.x, (1+percentage)*ScreenSize.x), ScreenSize.y, 0);
	}
}
