using UnityEngine;
using System.Collections;
/// <summary>
/// Screen size, to cache the Camera screen size.
/// </summary>
public static class ScreenSize {
	static Vector3 size = Vector3.zero;
	public static Vector3 Size {
		get {
			if (size == Vector3.zero) {
				size = Camera.main.ScreenToWorldPoint (new Vector3 (Camera.main.pixelWidth, Camera.main.pixelHeight));
			}
			return size;
		}
	}
}
