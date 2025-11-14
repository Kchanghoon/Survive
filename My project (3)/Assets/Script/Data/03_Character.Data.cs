namespace Game.Data
{
    using System;
    using UnityEngine;

    public enum TriggerType { OnHit, OnKill, OnDodge, OnMove, OnCrit, OnLevelUp }

    [Serializable]
    public struct PassiveEffect
    {
        public string description;
        public Tag tags;
        public float value;
        public float cooldown;
    }

    [CreateAssetMenu(fileName = "PassiveData", menuName = "Game/Upgrade/Passive")]
    public class PassiveData : IdScriptableObject
    {
        public TriggerType trigger;
        public PassiveEffect[] effects;
    }

    [Serializable]
    public struct UnlockCondition { public string description; public int requiredCount; }

    [CreateAssetMenu(fileName = "CharacterData", menuName = "Game/Character")]
    public class CharacterData : IdScriptableObject
    {
        public StatBlock baseStats;
        public AttackProfile attack;          // 투사체/근접 모두 AttackProfile로 통일
        public PassiveData[] passives;
        public UnlockCondition unlockCondition;
        public Sprite icon;
        public GameObject prefab;
    }
}
