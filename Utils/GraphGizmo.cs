using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordsOnPlay.Utils;


namespace WordsOnPlay.Utils {

public class GraphGizmo : MonoBehaviour
{
    [SerializeField]
    private float duration = 30; // seconds
    [SerializeField]
    private float range = 1;
    [SerializeField]
    private Rect rect;
    [SerializeField]
    private Color rectColor = Color.yellow;
    [SerializeField]
    private Color lineColor = Color.green;

    private Queue<float> values = new Queue<float>();
    private Queue<float> times = new Queue<float>();

    public void Clear() 
    {
        values.Clear();
        times.Clear();
    }

    public void Add(float value)
    {
        values.Enqueue(value);
        times.Enqueue(Time.time);
    }

    public void Update()
    {
        while (times.Count > 0 && times.Peek() < Time.time - duration)
        {
            values.Dequeue();
            times.Dequeue();
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = rectColor;
        rect.DrawGizmo();

        IEnumerator<float> vIt = values.GetEnumerator();
        IEnumerator<float> tIt = times.GetEnumerator();

        bool first = true;
        Vector3 p0 = Vector3.zero;
        Gizmos.color = lineColor;

        while (vIt.MoveNext() && tIt.MoveNext())
        {
            float x = 1 - (Time.time - tIt.Current) / duration;
            float y = vIt.Current / range;

            Vector3 p1 = rect.Point(x,y);

            if (first)
            {
                first = false;
            }
            else 
            {
                Gizmos.DrawLine(p0, p1);
            }
            p0 = p1;
        }
    }

}
}