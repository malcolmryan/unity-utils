using UnityEngine;
using System;
using System.Collections;

/**
 * Extensions to Unity's LayerMask class
 * 
 */
namespace WordsOnPlay.Utils {

public static class InlineCR {
    public static IEnumerator Now(Action action)
    {
        action();
        yield return action;
    }

    public static IEnumerator Next(Action action)
    {
        // wait a frame
        yield return null;
        action();
        yield return action;
    }

}
}