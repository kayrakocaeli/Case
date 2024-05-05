using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class DamageAllEnemies : Skill
{
    public GameObject[] enemies;
    public override void Activate(GameObject parent)
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (GameManager.Instance.gold >= 25)
            {
                GameManager.Instance.gold -= 25;
                EventManager.StartToSetData();
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject Enemy in enemies)
                {
                    if (50f > Vector2.Distance(GameObject.Find("Player").transform.position, Enemy.transform.position))
                    {
                        ObjectPool.instance.Destroy(Enemy);
                    }
                }
            }
        }
    }
    
}
