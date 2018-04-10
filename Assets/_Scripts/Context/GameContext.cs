using System.Collections.Generic;
using UnityEngine;

public class GameContext : MonoBehaviour, ISwitchMissionContext
{
    public delegate void ExitGameContextHandler(GameContext context);
    public ExitGameContextHandler allMissionCompletedSubject;

    [Space(10)]
    public List<Mission> missions;

    private int currentMissionIndex;
    private Mission currentMission;

    private void Start()
    {
        this.currentMissionIndex = 0;

        if (this.missions == null || this.missions.Count == 0)
        {
            Debug.Log($"There is not any missions in {this}");
            return;
        }

        this.currentMission = this.missions[this.currentMissionIndex];

        this.allMissionCompletedSubject += (ctx) =>
        {
            Debug.Log("我订阅了自己，并且完成了！");
        };
    }

    private void Update()
    {
        this.currentMission?.Execute(this);
    }

    public void SwitchMission(Mission completedMission)
    {
        Debug.Log($"GameContext.SwitchMission: 刚完成的任务是{completedMission}");

        ++this.currentMissionIndex;

        if (this.currentMissionIndex == this.missions.Count)
        {
            if (this.allMissionCompletedSubject != null)
                this.allMissionCompletedSubject(this);

            this.currentMission = null;
            return;
        }

        this.currentMission = this.missions[this.currentMissionIndex];
    }

}
