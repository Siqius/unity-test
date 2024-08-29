using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapons/MeleeSO")]
public class MeleeSO : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public string Description;
    public string Rarity;

    [Header("Damage")]
    public float AttackDamage;
    public float HeavyAttackDamage;

    [Header("Stats")]
    [Tooltip("AttackSpeed in Seconds")]
    public float AttackSpeed;
    public float AttackRange;

    [Header("Abilities")]
    public bool CanBlock;
}
