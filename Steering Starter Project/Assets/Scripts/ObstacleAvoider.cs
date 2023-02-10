using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoider : Kinematic
{
    ObstacleAvoid myMoveType;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new ObstacleAvoid();
        myMoveType.character = this;
        myMoveType.target = myTarget;
    }

    // Update is called once per frame
    void Update()
    {
        steeringUpdate = myMoveType.getSteering();
        base.Update();
    }
}
