/**
 * 
 * Base JSON Message class. Extend this to create specific message types
 * 
 * Note: Messages should only include serialisable fields. 
 * Unity's base Vector2 and Vector3 classes are NOT serialisable, 
 * so SerialisableVector2 and SerialisableVector3 classes are provided.
 *
 * If you want to output Quaternions, I recommend you convert them to eulerAngles.
 * 
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6000.0.40f1
 */
 
using System;
using UnityEngine;

[Serializable]
public class Message
{
    public string message;
    public float time;

    public Message()
    {
    }

    public Message(string type, string message)
    {
        this.time = Time.time;
        this.message = message;
    } 
}

