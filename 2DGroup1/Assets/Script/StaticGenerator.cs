using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Static", menuName = "Static")]
public class StaticBehavior : ScriptableObject
{
    public float SPEED;
    public float JUMP_STRENGTH;
    public float HEALTH;
    public float MAX_ACCELERATION;
    public float ACCELERATION_RATE;
    public int MAX_ENERGY;

    public Sprite ENTITY_SPRITE;
}
