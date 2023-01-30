using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Face
{
    public float wanderOffset = 5f;
    public float wanderRadius = 0f;
    public Vector3 center;

    //The maximum rate at which the wander orientation can change.
    public float wanderRate = 40f;
    //The current orientation of the wander target.
    public float wanderOrientation;
    public float targetOrientation;
    //The maximum acceleration of the character.
    public float maxAcceleration = 2f; 
    //Again we don’t need a new target.
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        //1. Calculate the target to delegate to face
        //Update the wander orientation.
        wanderOrientation += randomBinomial() * wanderRate;
        targetOrientation = wanderOrientation + character.transform.eulerAngles.y;
        //Calculate the combined target orientation.
        //getTargetAngle();

        // Calculate the center of the wander circle.
        center = character.transform.position + wanderOffset * character.transform.eulerAngles;
        //Calculate the target location.
        center += wanderRadius * new Vector3(0,targetOrientation,0);
        //2. Delegate to face.
        result = base.getSteering();
        //3. Now set the linear acceleration to be at full
        //acceleration in the direction of the orientation.
        result.linear = maxAcceleration * character.transform.eulerAngles;
        //Return it.
        return result;
    } 

    public float randomBinomial()
    {
        return Random.Range(0, 1) - Random.Range(0, 1);
    }
}
