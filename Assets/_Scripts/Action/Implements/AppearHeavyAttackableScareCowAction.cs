using UnityEngine;

[CreateAssetMenu(menuName = "Pluginable/Action/AppearHeavyAttackableScareCowAction")]
public class AppearHeavyAttackableScareCowAction : Action
{
    public override void Do(ISwitchMissionContext context)
    {
        Debug.Log("重砍才能破坏的稻草人升上来中");
    }

    public override bool EnableExitAction(ISwitchMissionContext context)
    {
        Debug.Log("重砍才能破坏的稻草人还没升上来");

        return false;
    }

    public override bool EnbaleEnterAction(ISwitchMissionContext context)
    {
        Debug.Log("既然进来了就开始吧");
        return true;
    }
}
