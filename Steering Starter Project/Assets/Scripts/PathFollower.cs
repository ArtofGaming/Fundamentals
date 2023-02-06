using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : Kinematic
{
    FollowPath myMoveType;
    Face mySeekRotateType;


    public bool flee = false;
    public GameObject[] myPath;


    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new FollowPath();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.path = myPath;
        myMoveType.flee = flee;

        mySeekRotateType = new Face();
        mySeekRotateType.character = this;
        mySeekRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = mySeekRotateType.getSteering().angular;
        base.Update();
    }
}
