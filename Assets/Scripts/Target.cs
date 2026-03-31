using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    None,
    Ground,
    Enemy,
    Item
}

public class Target 
{
    public Transform transform;
    public TargetType type;
}
