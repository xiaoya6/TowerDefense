using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour {

    [HideInInspector]
    public GameObject turrentGo;//保存Cube当前身上的炮台
    public GameObject buildEffect;
    [HideInInspector]
    public bool isUpgraded;
    private Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    public void BuildTurrent(GameObject turrentPrefab) {
        isUpgraded = false;
        turrentGo = GameObject.Instantiate(turrentPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        GameObject.Destroy(effect, 1);
    }

    private void OnMouseEnter()
    {
        if (turrentGo == null && !EventSystem.current.IsPointerOverGameObject()) {
            render.material.color = Color.red;
        }
    }

    private void OnMouseExit()
    {
        render.material.color = Color.white;
    }
}
