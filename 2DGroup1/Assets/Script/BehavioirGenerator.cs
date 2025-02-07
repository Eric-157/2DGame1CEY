using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//This is the script that allows you to make new weapons that are easy to edit
//The parameters are the ones shown below that you can tweek in the INSPECTOR!, 
//dont mess with the code here like setting a value in script or else it will break.


[CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
public class EntityBehavior : ScriptableObject
{
    public float SPEED;
    public float JUMP_STRENGTH;
    public float HEALTH;
    public float MAX_ACCELERATION;
    public float ACCELERATION_RATE;
    public int MAX_ENERGY;

    public Sprite ENTITY_SPRITE;
}

