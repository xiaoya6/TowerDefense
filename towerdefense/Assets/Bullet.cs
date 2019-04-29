using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage = 50;
    public float speed = 30;
    private Transform target;
    public GameObject explosionEffectPrefab;

    public void SetTarget(Transform _target) {
        this.target = _target;
    }
	
	void Update () {

        if (target == null) {
            Die();
            return;
        }
        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Die();
        }
    }

    public void Die() {
        GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);
        Destroy(effect, 1);
        Destroy(this.gameObject);

    }
}
