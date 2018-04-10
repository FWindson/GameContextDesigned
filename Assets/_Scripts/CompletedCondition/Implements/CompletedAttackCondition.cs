using UnityEngine;

[CreateAssetMenu(menuName = "Pluginable/CompletedCondition/CompletedAttackCondition")]
public class CompletedAttackCondition : CompletedCondition
{
    public int countDown = 3;

    public override bool IsCompleted(ISwitchMissionContext context)
    {
        --countDown;
        if (countDown == 0)
            return true;
        
        Debug.Log("玩家攻击了？不存在的！");
        return false;
    }
}
