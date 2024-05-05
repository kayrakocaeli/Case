
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;
    private Transform player;
    public int enemyHP=0,currentHp,HpIncreaseInterval=5,HpIncreaseAmount=5;
    public  float EnemySpeed=1;
    int kill = 0;
    private void Start()
    {
        currentHp = enemyHP;
        enemyHP = enemyType.enemyHP;
        EnemySpeed = enemyType.EnemySpeed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("IncreaseHealth", HpIncreaseInterval, HpIncreaseAmount);
    }
    private void Update()
    {
        Chase();
        EnemyIsDead();
    }
    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, EnemySpeed * Time.deltaTime);
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 270f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.playerHP-=20;
            EventManager.StartToSetData();
            ObjectPool.instance.Destroy(gameObject);
        }
    }
    private void EnemyIsDead()
    {
        if (currentHp <= 0)
        {
            ObjectPool.instance.Destroy(gameObject);
            kill++;
            GameManager.Instance.gold += (enemyHP/3);
            EventManager.StartToSetData();
        }
    }
    private void IncreaseHealth()
    {
        enemyHP += HpIncreaseAmount;
    }
}
