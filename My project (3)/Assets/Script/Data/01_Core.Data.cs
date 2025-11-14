namespace Game.Data
{
    using System;
    using UnityEngine;

    public abstract class IdScriptableObject : ScriptableObject
    {
        [SerializeField] string id;
        [SerializeField] string displayName;
        public string Id => id;
        public string DisplayName => displayName;
    }

    [Serializable]
    public struct StatBlock
    {
        public float hp, atk, atkSpeed, moveSpeed, critChance, critDamage, range, projectileSpeed, evasion;
    }

    [Flags]
    public enum Tag
    {
        None = 0, Projectile = 1 << 0, Melee = 1 << 1, Bleed = 1 << 2, Lifesteal = 1 << 3,
        Explosive = 1 << 4, AOE = 1 << 5, Orbit = 1 << 6, Utility = 1 << 7,
        Boss = 1 << 8, Runner = 1 << 9, Tank = 1 << 10, Mage = 1 << 11, Swordsman = 1 << 12
    }

    public enum Tier { Common, Rare, Epic, Legendary }
    public enum ModifierOp { Add, Multiply, Override }
    public enum StatType { Hp, Atk, AtkSpeed, MoveSpeed, CritChance, CritDamage, Range, ProjectileSpeed, Evasion, ProjectileCount, ShieldInterval, ExpGainRate }
}
