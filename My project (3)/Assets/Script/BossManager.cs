using UnityEngine;
using Game.Data;
using System.Collections;

namespace Game.Runtime
{
    public class BossManager : MonoBehaviour
    {
        BossData boss;
        GameObject instance;

        public void Setup(BossData data)
        {
            boss = data;
            // 웨이브 종료 조건과 연동해서 SpawnBoss() 호출하도록 추가
        }

        public void SpawnBoss(Vector3 pos)
        {
            if (boss == null || boss.prefab == null) return;
            instance = Instantiate(boss.prefab, pos, Quaternion.identity);
            StopAllCoroutines();
            StartCoroutine(CoPatterns());
        }

        public void Despawn()
        {
            if (instance != null) Destroy(instance);
            StopAllCoroutines();
        }

        IEnumerator CoPatterns()
        {
            while (true)
            {
                foreach (var p in boss.patterns)
                {
                    yield return new WaitForSeconds(p.windupTime);
                    // 돌진/점프충격파 등은 실제 전투 시스템에서 구현
                    yield return new WaitForSeconds(p.activeTime);
                    yield return new WaitForSeconds(p.cooldown);
                }
                yield return null;
            }
        }
    }
}
