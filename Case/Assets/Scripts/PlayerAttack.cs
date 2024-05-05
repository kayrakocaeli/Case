using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject closestEnemy;
    public GameObject Bullet;
    [SerializeField] private EnemySpawner enemySpawner;
    public float nextFire;
    public float shootingDistance = 10f;
    float offset = 0.1f;
    public Transform shotSpawnPoint;
    void Start()
    {
        nextFire = Time.time;
    }
    void Update()
    {
        EnemyFind();
    }
    void EnemyFind()
    {
        float minimumDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemySpawner.spawns)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                closestEnemy = enemy;
            }
        }
        if (Vector2.Distance(transform.position, closestEnemy.transform.position) < shootingDistance)
        {
            Rotate();
            Fire();
            StartCoroutine(Shoot());
        }
        else
        {
            Fire();
            StartCoroutine(Shoot());
        }
    }
    void Rotate()
    {
        Vector3 vectorToTarget = closestEnemy.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 5f);
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2f);
    }
    void Fire()
    {
        if (Time.time > nextFire)
        {
            Vector3 spawnPosition = shotSpawnPoint.position;
            var newShoot = ObjectPool.instance.Instantiate(Bullet);
            newShoot.transform.position = spawnPosition;
            newShoot.transform.rotation = transform.rotation;
            ObjectPool.instance.Destroy(newShoot,2f);

            if (GameManager.Instance.diagonalShootLevel>=1)
            {
                var newShoot1= ObjectPool.instance.Instantiate(Bullet);
                newShoot1.transform.position = spawnPosition;
                newShoot1.transform.rotation = transform.rotation;
                newShoot1.transform.Rotate(new Vector3(0f, 0f, 15f));
                ObjectPool.instance.Destroy(newShoot1, 2f);

                var newShoot2 = ObjectPool.instance.Instantiate(Bullet);
                newShoot2.transform.position = spawnPosition;
                newShoot2.transform.rotation = transform.rotation;
                newShoot2.transform.Rotate(new Vector3(0f, 0f, -15f));
                ObjectPool.instance.Destroy(newShoot2, 2f);
            }
            if (GameManager.Instance.shootLevel>=1)
            {
                spawnPosition = new Vector3(spawnPosition.x + offset, spawnPosition.y + offset, spawnPosition.z);
                var newShoot3 = ObjectPool.instance.Instantiate(Bullet);
                newShoot3.transform.position = spawnPosition;
                newShoot3.transform.rotation = transform.rotation;
                ObjectPool.instance.Destroy(newShoot3, 2f);
            }
            if (GameManager.Instance.shootLevel>=2 )
            {
                spawnPosition = new Vector3(spawnPosition.x - 2 * offset, spawnPosition.y - offset, spawnPosition.z);
                var newShoot4 = ObjectPool.instance.Instantiate(Bullet);
                newShoot4.transform.position = spawnPosition;
                newShoot4.transform.rotation = transform.rotation;
                ObjectPool.instance.Destroy(newShoot4, 2f);
            }
            if (GameManager.Instance.shootLevel >= 3)
            {
                spawnPosition = new Vector3(spawnPosition.x - offset, spawnPosition.y - 2 * offset, spawnPosition.z);
                var newShoot4 = ObjectPool.instance.Instantiate(Bullet);
                newShoot4.transform.position = spawnPosition;
                newShoot4.transform.rotation = transform.rotation;
                ObjectPool.instance.Destroy(newShoot4, 2f);
            }
            nextFire = Time.time + GameManager.Instance.fireRate;
        }
    }
}
