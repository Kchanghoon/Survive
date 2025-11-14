using UnityEngine;
using Game.Data;

namespace Game.Runtime
{
    public class EnemyManager : MonoBehaviour
    {
        public void Spawn(EnemyData enemy, SpawnArea area, int count)
        {
            // 외곽 포지션 계산/풀링 적용은 이후
            for (int i = 0; i < count; i++)
            {
                // Instantiate(enemy.prefab, pos, rot) …
            }
        }

        // 디버그용: 전투 루프 연동 전까지 임시 피해 처리
        public void DebugSimulateProjectileHit(float damage)
        {
            // 가장 가까운 적에 damage 적용했다고 가정
            OnEnemyKilledInternal(null, 1, 1);
        }

        public void DebugSimulateMeleeHit(float damage)
        {
            // 범위 내 적 몇 마리 처치 가정
            OnEnemyKilledInternal(null, Random.Range(1, 3), 1);
        }

        void OnEnemyKilledInternal(EnemyData data, int killCount, int goldPerKill)
        {
            for (int i = 0; i < killCount; i++)
                EventHub.OnEnemyKilled?.Invoke(data);
            EventHub.OnGoldChanged?.Invoke(goldPerKill * killCount);
        }
    }
}