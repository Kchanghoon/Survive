namespace Game.Data
{
    using UnityEngine;

    public enum AttackKind { Projectile, Melee }

    [CreateAssetMenu(fileName = "AttackProfile", menuName = "Game/Combat/AttackProfile")]
    public class AttackProfile : IdScriptableObject
    {
        [Header("공통")]
        public AttackKind kind = AttackKind.Projectile;
        public float fireRateBase = 1.0f;   // 초당 1회 기준
        public float rangeBase = 5.0f;
        public float critMultiplier = 1.5f;
        public Tag tags;

        [Header("투사체 전용")]
        public float projSpeed = 10f;
        public float projLifetime = 5f;
        public float projSize = 1f;
        public int projPierce = 0;
        public float projDamageCoef = 1.0f;
        public GameObject projectilePrefab;
        public AudioClip projectileHitSfx;

        [Header("근접 전용")]
        public float arcAngle = 60f;
        public float radius = 1.5f;
        public float swingDuration = 0.2f;
        public float meleeDamageCoef = 1.0f;
        public float meleeHitInterval = 0.2f;
        public GameObject swingVfx;
        public AudioClip meleeHitSfx;
    }
}
