using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent : MonoBehaviour {

    public List<GameObject> enemys = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            enemys.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
    }

    public float attackRateTime = 1;//多少秒攻击一次
    private float timer = 0;

    public GameObject bulletPrefab;//子弹
    public Transform firePosition;
    public Transform head;

    private void Start()
    {
        timer = attackRateTime;
    }

    private void Update()
    {
        if (enemys.Count > 0 && enemys[0] != null)
        {

            Vector3 targetPosition = enemys[0].transform.position;
            targetPosition.y = head.position.y;
            head.LookAt(targetPosition);
        }

        timer += Time.deltaTime;

        if (enemys.Count>0 && timer > attackRateTime) {
            timer =0;
            Attack();
        }

        
    }

    void Attack() {
        if (enemys[0] == null) {
            UpdateEnemys();
        }
        if (enemys.Count > 0)
        {
            GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
        }
        else {
            timer = attackRateTime;
        }
        
    }

    void UpdateEnemys() {
        List<int> emptyIndex = new List<int>();
        for (int i = 0; i < enemys.Count; i++)
        {
            if (enemys[i] == null) {
                emptyIndex.Add(i);
            }
        }

        for (int i = 0; i < emptyIndex.Count; i++)
        {
            enemys.RemoveAt(emptyIndex[i] - i);
        }
    }
}
