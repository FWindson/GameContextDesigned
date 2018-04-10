using UnityEngine;

[CreateAssetMenu(menuName = "Pluginable/Action/AppearScareCowAction")]
public class AppearScareCowAction : Action
{
    
    public override void Do(ISwitchMissionContext context)
    {
        Debug.Log("Action.Do: 稻草人出现中");
    }

    public override bool EnableExitAction(ISwitchMissionContext context)
    {
        Debug.Log("Action.EnableExitAction: 稻草人还没升到最高处，不退出该行动");
        return false;
    }

    public override bool EnbaleEnterAction(ISwitchMissionContext context)
    {
        if (this.DoOnLoad)
        {
            Debug.Log($"Action.EnbaleEnterAction: {this}是立即执行的行动");
            return true;
        }
        Debug.Log($"Action.EnbaleEnterAction: {this}直接开始出现稻草人吧");
        return true;
    }
}
