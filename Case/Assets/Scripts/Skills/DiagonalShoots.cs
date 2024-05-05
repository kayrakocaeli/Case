using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DiagonalShoots : Skill
{
    public override void Activate(GameObject parent)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameManager.Instance.diagonalShootLevel < 1 && GameManager.Instance.gold >= 15)
            {
                GameManager.Instance.gold -= 15;
                EventManager.StartToSetData();
                GameManager.Instance.diagonalShootLevel++;
            }
        }       
    }
}
