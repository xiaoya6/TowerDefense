using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurrentData{

    public GameObject turrentPrefab;
    public int cost;
    public GameObject turrentUpgradedPrefab;
    public int costUpgraded;
    public TurrentType type;

    public enum TurrentType {
        LaserTurrent,
        MissibleTurrent,
        StandardTurrent
    }
}
