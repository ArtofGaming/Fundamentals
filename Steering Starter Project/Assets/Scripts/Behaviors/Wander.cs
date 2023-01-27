using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Face
{

    public float wanderOffset = 10f;
    public float wanderRadius = 5f;
    public Vector3 center;
    //The maximum rate at which the wander orientation can change.
    public float wanderRate = 40;
    //The current orientation of the wander target.
    public float wanderOrientation; 
    //The maximum acceleration of the character.
    public float maxAcceleration; 
    //Again we don’t need a new target. 16# ... Other data is derived from the superclass ... 17 18
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        //1. Calculate the target to delegate to face
        //Update the wander orientation.
        wanderOrientation += target.transform.eulerAngles.y * wanderRate;
        //Calculate the combined target orientation.
        getTargetAngle();

        // Calculate the center of the wander circle.
        center = character.transform.position + wanderOffset * character.transform.eulerAngles;
        //Calculate the target location.
        target.transform.position += wanderRadius * center;
        //2. Delegate to face.
        result = base.getSteering();
        //3. Now set the linear acceleration to be at full
        //acceleration in the direction of the orientation.
        result.linear = maxAcceleration * character.transform.eulerAngles;
        //Return it.
        return result;
    } 
}
