using UnityEngine;
using Game.Data;
using System.Collections;

namespace Game.Runtime
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] EnemyManager enemy;
        StageData stage;
        int totalKills;
        bool running;

        void OnEnable()
        {
            EventHub.OnEnemyKilled += _ => { totalKills++; EventHub.OnKillCountChanged?.Invoke(totalKills); };
        }
        void OnDisable()
        {
            EventHub.OnEnemyKilled -= _ => { };
        }

        public void Setup(StageData s)
        {
            stage = s;
            totalKills = 0;
            running = true;
            StopAllCoroutines();
            StartCoroutine(CoWaves());
        }

        public void StopAll() { running = false; StopAllCoroutines(); }

        IEnumerator CoWaves()
        {
            if (stage == null || stage.waves == null) yield break;

            foreach (var wave in stage.waves)
            {
                float t = 0f;
                while (t < wave.waveDuration && running)
                {
                    t += Time.deltaTime;
                    float spawnMultiplier = Mathf.Max(0, Mathf.Round(totalKills * 1.5f)); // 누적 처치 × 1.5
                    foreach (var entry in wave.spawnEntries)
                    {
                        // 간단 샘플: 초당 spawnRatePerSec × multiplier 확률 스폰
                        if (Random.value < entry.spawnRatePerSec * Time.deltaTime)
                        {
                            int count = Mathf.Clamp((int)spawnMultiplier, 1, 20);
                            enemy.Spawn(entry.enemy, entry.spawnArea, count);
                        }
                    }
                    yield return null;
                }
            }
            // 웨이브 끝 → 보스는 BossManager가 처리
        }
    }
}