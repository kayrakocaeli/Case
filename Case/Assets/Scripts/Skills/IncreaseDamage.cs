using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class IncreaseDamage : Skill
{
    public override void Activate(GameObject parent)
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (GameManager.Instance.DamageLevel < 40 && GameManager.Instance.DFee <= GameManager.Instance.gold)
            {
                GameManager.Instance.gold -= (int)GameManager.Instance.DFee;
                EventManager.StartToSetData();
                GameManager.Instance.DFee = GameManager.Instance.DFee * 1.1;
                GameManager.Instance.damage += 1;
                GameManager.Instance.DamageLevel++;
            }
            
        }
    }
}
