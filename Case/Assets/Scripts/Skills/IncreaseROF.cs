using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class IncreaseROF : Skill
{
    float normalAttackSpeed;
    public override void Activate(GameObject parent)
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (GameManager.Instance.gold >= 15)
            {
                GameManager.Instance.gold -= 15;
                EventManager.StartToSetData();
                normalAttackSpeed = GameManager.Instance.fireRate;
                GameManager.Instance.normalFireRate = normalAttackSpeed;
                GameManager.Instance.fireRate = 0.1f;
                GameManager.Instance.NormalFireRate();
            }
        }
    }
}
