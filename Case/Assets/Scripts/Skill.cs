using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public float cooldownTime,activeTime;
    public virtual void Activate(GameObject parent) { }
}
