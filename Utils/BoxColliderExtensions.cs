using UnityEngine;
using System.Collections;
using UnityEditor;

/**
 * Extension methods for the Rect class
 */

namespace WordsOnPlay.Utils {
public static class BoxColliderExtensions  {


	/**
	 * Get the objects inside a box collider
	 */

	public static Collider[] Occupied(this BoxCollider collider, Transform transform, LayerMask layerMask) {
            Vector3 centre = transform.TransformPoint(collider.center);
            Vector3 size = Vector3.Scale(collider.size, transform.lossyScale);
            Collider[] hit = Physics.OverlapBox(centre, size / 2, transform.rotation, layerMask);
            return hit; 
	}

	/**
	 * Get the objects inside a box collider
	 */

	public static bool IsOccupied(this BoxCollider collider, Transform transform, LayerMask layerMask) {
            Vector3 centre = transform.TransformPoint(collider.center);
            Vector3 size = Vector3.Scale(collider.size, transform.lossyScale);
            Collider[] hit = Physics.OverlapBox(centre, size / 2, transform.rotation, layerMask);
            return hit.Length > 0; 
	}


}
}