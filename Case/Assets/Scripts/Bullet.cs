using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f,lifeTime=10f;
    void Update()
    {
        transform.Translate(new Vector3(0f, speed, transform.position.z), Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().currentHp -= GameManager.Instance.damage;
            EventManager.StartToSetData();
            ObjectPool.instance.Destroy(gameObject);
        }
    }
}
