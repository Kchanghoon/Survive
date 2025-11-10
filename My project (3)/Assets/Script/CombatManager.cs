using UnityEngine;
using Game.Data;
using System.Collections;

namespace Game.Runtime
{
    public class CombatManager : MonoBehaviour
    {
        [SerializeField] PlayerManager player;
        [SerializeField] EnemyManager enemy;
        [SerializeField] EconomyManager economy;

        float fireTimer;
        bool running;

        public void Begin()
        {
            running = true;
            fireTimer = 0f;
        }

        public void End() => running = false;

        void Update()
        {
            if (!running || player.Attack == null) return;

            // 초당 1회 × 공속
            float interval = 1f / Mathf.Max(0.01f, player.Stats.atkSpeed * player.Attack.fireRateBase);
            fireTimer += Time.deltaTime;
            if (fireTimer >= interval)
            {
                fireTimer -= interval;
                FireOnce();
            }
        }

        void FireOnce()
        {
            if (player.Attack.kind == AttackKind.Projectile)
            {
                // 투사체 발사 (풀링/방향 계산은 이후 확장)
                enemy.DebugSimulateProjectileHit(player.Stats.atk * player.Attack.projDamageCoef);
            }
            else
            {
                // 근접 판정 (OverlapSphere / 2D OverlapCircle 등)
                enemy.DebugSimulateMeleeHit(player.Stats.atk * player.Attack.meleeDamageCoef);
            }
        }
    }
}
