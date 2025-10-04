using UnityEngine;
using System;
using System.Collections;

/**
 * Extensions to Unity's LayerMask class
 * 
 */
namespace WordsOnPlay.Utils {

public static class AnimationCurveExtensions  {

	public static IEnumerator Run(this AnimationCurve curve, Action<float> evalCallback, Action doneCallback) {

	    float max = curve.keys[curve.length-1].time;
        float t = 0;
        evalCallback(curve.Evaluate(t));

        while (t < max) 
        {
            yield return null;            
            t += Time.deltaTime;
            t = Mathf.Clamp(t,0,max);
            evalCallback(curve.Evaluate(t));
        }
		doneCallback();
	}


}
}