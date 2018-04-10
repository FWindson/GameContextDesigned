using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompletedCondition : ScriptableObject
{
    public abstract bool IsCompleted(ISwitchMissionContext context);
}
