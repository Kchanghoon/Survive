namespace Game.Data
{
    using UnityEngine;

    public enum EnemyType { Melee, Ranged, Elite }

    [CreateAssetMenu(fileName = "AIProfile", menuName = "Game/AI/AIProfile")]
    public class AIProfile : IdScriptableObject
    {
        public bool straightChase = true;
        public bool keepDistance = false;
        public bool bulletHell = false;
        public float preferredRange = 6f;
    }

    [CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy")]
    public class EnemyData : IdScriptableObject
    {
        public EnemyType type = EnemyType.Melee;
        public StatBlock stats;
        public AIProfile aiProfile;
        public AttackProfile attack;      // 원거리면 Projectile, 근접이면 Melee 프로필 지정
        public float contactDamage = 10f;
        public int deathRewardExp = 1;
        public int deathRewardGold = 1;
        public GameObject prefab;
        public Tag tags;
    }

    [CreateAssetMenu(fileName = "BossPattern", menuName = "Game/Boss/Pattern")]
    public class BossPatternData : IdScriptableObject
    {
        public float windupTime = 0.6f;
        public float activeTime = 1.2f;
        public float cooldown = 2.0f;
        public float range = 2.5f;
        public float damageCoef = 1.5f;
        public float knockback = 0f;
        public float stunDuration = 0f;
    }

    [CreateAssetMenu(fileName = "BossData", menuName = "Game/Boss/Boss")]
    public class BossData : IdScriptableObject
    {
        public StatBlock stats;
        public AIProfile aiProfile;
        public BossPatternData[] patterns;
        public GameObject prefab;
        public Tag tags = Tag.Boss;
    }
}
