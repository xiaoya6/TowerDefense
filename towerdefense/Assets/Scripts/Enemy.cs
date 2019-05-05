using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float speed = 10;
    public int hp = 150;
    public GameObject explosionEffect;
    public Slider hpSlider;
    private int totalHp;
    private Transform[] positions;
    private int index = 0;

    private void Start()
    {
        positions = Waypoints.positions;
        totalHp = hp;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        if (index > positions.Length - 1) return;
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.2f) {
            index ++;
        }

        if (index > positions.Length - 1) {
            ReachDestination();
        }
    }

    void ReachDestination() {
        GameObject.Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        EnemySpawner.CountEnemyAlive--;
    }

    public void TakeDamage(int damage) {
        if (hp <= 0) return;
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;
        if (hp <= 0) {
            Die();
        }
    }

    void Die() {
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
        Destroy(this.gameObject);
    }
}
