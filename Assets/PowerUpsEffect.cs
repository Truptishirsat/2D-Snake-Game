using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpsEffect : ScriptableObject
{
    public abstract void Apply(GameObject target);
}
