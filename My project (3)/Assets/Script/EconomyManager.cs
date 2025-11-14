using UnityEngine;
using Game.Data;

namespace Game.Runtime
{
    public class EconomyManager : MonoBehaviour
    {
        [SerializeField] EconomyConfig config;
        float survivalSeconds;
        int gold;

        void OnEnable()
        {
            EventHub.OnGoldChanged += AddGold;
            EventHub.OnCombatStarted += () => { survivalSeconds = 0f; gold = 0; };
        }
        void OnDisable()
        {
            EventHub.OnGoldChanged -= AddGold;
        }

        void Update()
        {
            survivalSeconds += Time.deltaTime;
        }

        public void ResetRun() { survivalSeconds = 0f; gold = 0; }

        void AddGold(int amount) { gold += amount; }

        public int ComputeFinalGold()
        {
            int timeBonus = Mathf.FloorToInt(survivalSeconds * config.deathGoldBonusPerSecond);
            return gold + timeBonus;
        }
    }
}