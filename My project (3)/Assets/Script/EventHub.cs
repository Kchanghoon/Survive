using System;
using Game.Data;
using UnityEngine;

namespace Game.Runtime
{
    public static class EventHub
    {
        // 전투 루프
        public static Action OnCombatStarted;
        public static Action OnCombatEnded;

        // 플레이어/전투
        public static Action<float> OnPlayerDamaged;             // 피해량
        public static Action OnPlayerDied;
        public static Action<EnemyData> OnEnemyKilled;
        public static Action<int> OnKillCountChanged;

        // 경험치/레벨업
        public static Action<int, int, int> OnExpChanged;        // cur, req, level
        public static Action OnLeveledUp;

        // 강화
        public static Action OnUpgradeOffered;
        public static Action<UpgradeData> OnUpgradeSelected;

        // 경제
        public static Action<int> OnGoldChanged;
        public static Action<int> OnGoldFinalized;

        // UI
        public static Action OnShowLevelUpUI;
        public static Action OnHideLevelUpUI;
        public static Action OnShowResultUI;
    }
}
