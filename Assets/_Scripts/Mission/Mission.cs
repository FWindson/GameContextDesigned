using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pluginable/Mission")]
public class Mission : ScriptableObject
{
    public List<Action> actions;

    [Space(10)]
    public CompletedCondition completedCondition;

    public void Execute(ISwitchMissionContext context)
    {
        for (int i = 0; i < this.actions.Count;i++)
        {
            if (this.actions[i].EnableExitAction(context))
                return;
            
            if (this.actions[i].DoOnLoad || this.actions[i].EnbaleEnterAction(context))
            {
                this.actions[i].Do(context);
            }
        }

        if (this.completedCondition.IsCompleted(context))
        {
            context.SwitchMission(this);
        }
    }
}
