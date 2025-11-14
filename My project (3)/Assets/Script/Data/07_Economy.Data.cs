namespace Game.Data
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "EconomyConfig", menuName = "Game/Economy/Config")]
    public class EconomyConfig : IdScriptableObject
    {
        public float deathGoldBonusPerSecond = 1.2f;
        public AnimationCurve dropGoldCurve;
    }

    [CreateAssetMenu(fileName = "PermanentUpgrade", menuName = "Game/Economy/PermanentUpgrade")]
    public class PermanentUpgradeData : IdScriptableObject
    {
        public StatModifier statModifier;
        public int maxLevel = 5;
        public int[] costPerLevel;
        public Sprite icon;
    }
}
