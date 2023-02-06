using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPath : Seek
{
    public GameObject[] path;

    public float targetRadius = .5f;
    public int currentParam;
    public int closestParam = 0;
    public float lowestDist = Mathf.Infinity;
    
    public override SteeringOutput getSteering()
    {
        ///Vector3 currentPos = character.transform.position;
        //Vector3 futurePos = character.transform.position * predictTime * Time.deltaTime;
        if (target == null)
        {
            
            for (int i = 0; i < 2; i++)
            {
                if (i > 1)
                {
                    break;
                }
                if (Vector3.Distance(character.transform.position, path[i].transform.position) < lowestDist)
                {
                    lowestDist = Vector3.Distance(character.transform.position, path[i].transform.position);
                    target = path[i + 1];
                    closestParam = i;
                }
            }
        }
        lowestDist = (target.transform.position - character.transform.position).magnitude;
        if(lowestDist < targetRadius)
        {
            currentParam = closestParam;
            closestParam++;
            if (currentParam > 1)
            {
                return base.getSteering();
            }
            target = path[currentParam];
        }

        return base.getSteering();
    }
}
