using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class IncreaseShoots : Skill
{
    public override void Activate(GameObject parent)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (GameManager.Instance.shootLevel <= 3 && GameManager.Instance.ISFee <= GameManager.Instance.gold)
            {
                GameManager.Instance.gold -= (int)GameManager.Instance.ISFee;
                EventManager.StartToSetData();
                GameManager.Instance.ISFee = GameManager.Instance.ISFee * 1.5;
                GameManager.Instance.shootLevel++;
            }
        }
    }
}
