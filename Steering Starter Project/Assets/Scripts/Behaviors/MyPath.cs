using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPath : MonoBehaviour
{
    public List <Vector3> positions = new List<Vector3>() {new Vector3(0,0,0), new Vector3 (3,0,0)};
    public int GetParam(Vector3 position, int lastParam)
    {
        if (Vector3.Distance(position, positions[lastParam]) > Vector3.Distance(position, positions[lastParam + 1]))
        {
            if (lastParam + 1 > positions.Count + 1)
            {
                return 0;
            }
            return lastParam + 1;
        }
        else
        {
            return lastParam;
        }
    }

    public Vector3 GetPosition(int param)
    {
        Vector3.MoveTowards(this.transform.position, positions[param], Mathf.Infinity);
        return new Vector3(0, 0, 0);
    }

}
