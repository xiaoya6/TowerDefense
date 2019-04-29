using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManger : MonoBehaviour {

    public TurrentData laserTurrentData;
    public TurrentData missibleTurrentData;
    public TurrentData standardTurrentData;

    //表示当前选择的炮台（要建造的炮台）
    private TurrentData selectedTurrentData;

    public Text moneyText;
    public Animator moneyAnim;
    public int money = 1000;

    void ChangeMoney(int change) {
        money += change;
        moneyText.text = "$"+ money;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (!EventSystem.current.IsPointerOverGameObject()) {
                //开发炮台建造
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray,out hit,1000, LayerMask.GetMask("MapCube"));
                if (isCollider) {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();

                    if (selectedTurrentData != null && mapCube.turrentGo == null)
                    {
                        //创建
                        if (money > selectedTurrentData.cost)
                        {
                            ChangeMoney(-selectedTurrentData.cost);
                            mapCube.BuildTurrent(selectedTurrentData.turrentPrefab);
                        }
                        else {
                            //钱不够
                            moneyAnim.SetTrigger("filker");
                        }

                    }
                    else if(mapCube.turrentGo != null)
                    {

                        //TODO 升级

                    }
                }
            }
        }
    }

    public void OnLaserSelected(bool isOn) {
        if (isOn) {
            selectedTurrentData = laserTurrentData;
        }
    }

    public void OnMissibleSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurrentData = missibleTurrentData;
        }
    }

    public void OnStandardSelected(bool isOn)
    {
        if (isOn)
        {
            selectedTurrentData = standardTurrentData;
        }
    }
}
