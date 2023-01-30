using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPath : Seek
{
    public MyPath path = GameObject.Find("follower01").GetComponent<MyPath>();

    public float pathOffset;

    public int currentParam;
    public int targetParam;
    public int closestParam = 0;
    public float lowestDist = 10;
    public float predictTime = 0.1f;
    
    public override SteeringOutput getSteering()
    {
        Vector3 currentPos = character.transform.position;
        Vector3 futurePos = character.transform.position * predictTime * Time.deltaTime;
        for (int i = closestParam; i < path.positions.Count;i++ )
        {
            if (Vector3.Distance(currentPos, path.positions[i]) < lowestDist)
            {
                lowestDist = Vector3.Distance(currentPos, path.positions[i]);
                closestParam = i;
            }
        }
        currentParam = path.GetParam(futurePos,closestParam);
        targetParam = currentParam + (int)pathOffset;
        target.transform.position = path.GetPosition(targetParam);
        return base.getSteering();
    }
}
