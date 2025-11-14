namespace Game.Data
{
    using System;
    using UnityEngine;

    [Serializable]
    public struct StatModifier
    {
        public StatType targetStat;
        public ModifierOp op;
        public float value;
    }

    [CreateAssetMenu(fileName = "UpgradeData", menuName = "Game/Upgrade/Upgrade")]
    public class UpgradeData : IdScriptableObject
    {
        public Tier tier = Tier.Common;
        public Tag tags = Tag.None;
        public StatModifier[] effects;
        public Tag[] synergyHints;
        public Sprite icon;
    }
}
