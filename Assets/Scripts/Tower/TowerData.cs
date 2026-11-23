using UnityEngine;
using System.Collections.Generic;
using Unity.Android.Gradle;

[CreateAssetMenu(fileName = "FireTower", menuName = "TD/Tower Data")]
public class TowerData : ScriptableObject
{
    public string towerName;
    public float constructionTime;

    public float maxDamage;
    public float minDamage;
    public float range;
    public float attackSpeed;
    public DamageType damageType;

    public List<TowerEffect> effects;
}
