using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using WordsOnPlay.Utils;

public class GraphGizmo : MonoBehaviour
{
    [SerializeField]
    private Color rectColor;
    [SerializeField]
    private Color lineColor;
    [SerializeField]
    private float duration;
    [SerializeField]
    private Range range;
    [SerializeField]
    private Rect rect;

    private List<float> data = new List<float>();
    private List<float> time = new List<float>();

    void Update() 
    {
        float last = Time.time - duration;
        while (data.Count > 0 && time[0] < last)
        {
            data.RemoveAt(0);
            time.RemoveAt(0);
        }        
    }

    public void AddData(float value)
    {
        data.Add(value);
        time.Add(Time.time);
    }

    void OnDrawGizmos() 
    {
        Gizmos.color = rectColor;
        rect.DrawGizmo();

        if (data.Count > 0)
        {
            Gizmos.color = lineColor;
            float last = Time.time - duration;

            float x = (time[0] - last) / duration;
            float y = (data[0] - range.min) / (range.max - range.min);
            Vector2 p0 = rect.Point(x,y);

            for (int i = 1; i < data.Count; i++)
            {
                x = (time[i] - last) / duration;
                y = (data[i] - range.min) / (range.max - range.min);
                Vector2 p1 = rect.Point(x,y);

                Gizmos.DrawLine(p0, p1);
                p0 = p1;
            }

            Handles.Label(p0, $"{data[data.Count - 1]}");
        }
    }
 
 
}
