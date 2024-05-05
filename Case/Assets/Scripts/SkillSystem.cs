using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillInfo
{
    public Skill skill;
    public float cooldownTime;
    public float activeTime;
    public KeyCode key;
}

public class SkillSystem : MonoBehaviour
{
    public List<SkillInfo> skillInfos = new List<SkillInfo>();
    private AbilityState[] states;
    private enum AbilityState
    {
        Ready,
        Active,
        Cooldown
    }
    private void Start()
    {
        states = new AbilityState[skillInfos.Count];

        for (int i = 0; i < skillInfos.Count; i++)
        {
            states[i] = AbilityState.Ready;
        }
    }
    private void Update()
    {
        for (int i = 0; i < skillInfos.Count; i++)
        {
            switch (states[i])
            {
                case AbilityState.Ready:
                    if (Input.GetKeyDown(skillInfos[i].key))
                    {
                        skillInfos[i].skill.Activate(gameObject);
                        states[i] = AbilityState.Active;
                        skillInfos[i].activeTime = skillInfos[i].skill.activeTime;
                    }
                    break;

                case AbilityState.Active:
                    if (skillInfos[i].activeTime > 0)
                    {
                        skillInfos[i].activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        states[i] = AbilityState.Cooldown;
                        skillInfos[i].cooldownTime = skillInfos[i].skill.cooldownTime;
                    }
                    break;

                case AbilityState.Cooldown:
                    if (skillInfos[i].cooldownTime > 0)
                    {
                        skillInfos[i].cooldownTime -= Time.deltaTime;
                    }
                    else
                    {
                        states[i] = AbilityState.Ready;
                    }
                    break;
            }
        }
    }
}