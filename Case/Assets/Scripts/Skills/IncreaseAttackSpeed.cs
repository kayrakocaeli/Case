using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class IncreaseAttackSpeed : Skill
{
    public override void Activate(GameObject parent)
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (GameManager.Instance.attackSpeedLevel < 40 && GameManager.Instance.ASFee <= GameManager.Instance.gold)
            {
                GameManager.Instance.gold -= (int)GameManager.Instance.ASFee;
                EventManager.StartToSetData();
                GameManager.Instance.ASFee = GameManager.Instance.ASFee * 1.1;
                GameManager.Instance.fireRate *= 0.95f;
                GameManager.Instance.attackSpeedLevel++;
            }
        }
    }
}
