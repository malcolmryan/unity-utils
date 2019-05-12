using UnityEngine;
using System.Collections;

/**
 * Extensions to Unity's LayerMask class
 * 
 */
namespace WordsOnPlay.Utils {

public static class LayerMaskExtensions  {

	/**
	 * Check if a particular gameobject is included in the layermask
	 */

	public static bool Contains(this LayerMask layerMask, GameObject gameObject) {
		return (layerMask.value & (1 << gameObject.layer)) != 0;
	}
}
}