using UnityEngine;
using Game.Data;
using System;

namespace Game.Runtime
{
    public class ExperienceManager : MonoBehaviour
    {
        [SerializeField] int baseReq = 20;
        int curExp, reqExp, level;

        void OnEnable() { EventHub.OnEnemyKilled += OnKill; }
        void OnDisable() { EventHub.OnEnemyKilled -= OnKill; }

        public void ResetRun()
        {
            level = 1;
            curExp = 0;
            reqExp = baseReq;
            EventHub.OnExpChanged?.Invoke(curExp, reqExp, level);
        }

        void OnKill(EnemyData _)
        {
            AddExp(1); // ±âº»°ª
        }

        public void AddExp(int amount)
        {
            curExp += amount;
            while (curExp >= reqExp)
            {
                curExp -= reqExp;
                LevelUp();
            }
            EventHub.OnExpChanged?.Invoke(curExp, reqExp, level);
        }

        void LevelUp()
        {
            level++;
            reqExp = Mathf.CeilToInt(reqExp * 1.25f);
            EventHub.OnLeveledUp?.Invoke();
            EventHub.OnShowLevelUpUI?.Invoke();
        }
    }
}