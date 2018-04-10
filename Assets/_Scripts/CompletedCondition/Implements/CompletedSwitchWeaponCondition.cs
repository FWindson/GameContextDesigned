using UnityEngine;

[CreateAssetMenu(menuName = "Pluginable/CompletedCondition/CompletedSwitchWeaponCondition")]
public class CompletedSwitchWeaponCondition : CompletedCondition
{
    public int excutedCount = 0;

    public override bool IsCompleted(ISwitchMissionContext context)
    {
        if (excutedCount > 0)
        {
            Debug.Log("CompletedSwitchWeaponCondition.IsCompleted: 玩家居然会切换武器？？？");
            return true;
        }

        ++excutedCount;
        Debug.Log("CompletedSwitchWeaponCondition.IsCompleted: 玩家完成了切换武器？不存在的！");
        return false;
    }
}
