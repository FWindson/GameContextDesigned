using UnityEngine;

public abstract class Action : ScriptableObject
{
    public bool DoOnLoad;

    public abstract bool EnbaleEnterAction(ISwitchMissionContext context);

    public abstract void Do(ISwitchMissionContext context);

    public abstract bool EnableExitAction(ISwitchMissionContext context);
}
