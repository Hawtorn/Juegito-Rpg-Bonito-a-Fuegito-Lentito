using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill
{
    public abstract IEnumerator ExecuteSkill(Battler user, Battler[] targets);
    public abstract int GetMPCost();
}
