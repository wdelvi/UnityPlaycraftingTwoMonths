using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectibleType
{
    GoalMarkers,
    HealthPowerup,
    JumpPowerup,
    Token
}

public class Collectible : MonoBehaviour
{
    public CollectibleType collectibleType;
}
