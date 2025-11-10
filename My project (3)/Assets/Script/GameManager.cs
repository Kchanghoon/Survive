using UnityEngine;
using Game.Data;
using UnityEditor.Overlays;

namespace Game.Runtime
{
    public enum GameState { Lobby, Combat, Result }

    public class GameManager : MonoBehaviour
    {
        [Header("참조")]
        [SerializeField] PlayerManager player;
        [SerializeField] SpawnManager spawn;
        [SerializeField] CombatManager combat;
        [SerializeField] ExperienceManager exp;
        [SerializeField] UpgradeManager upgrade;
        [SerializeField] BossManager boss;
        [SerializeField] EconomyManager economy;
        [SerializeField] UIManager ui;

        [Header("데이터")]
        [SerializeField] StageData stage;
        [SerializeField] CharacterData defaultCharacter;

        public GameState State { get; private set; } = GameState.Lobby;

        void Start()
        {
            ToLobby();
        }

        public void ToLobby()
        {
            State = GameState.Lobby;
            // 로비 UI 준비
        }

        public void StartCombat()
        {
            State = GameState.Combat;
            player.LoadCharacter(defaultCharacter);
            economy.ResetRun();
            exp.ResetRun();
            spawn.Setup(stage);
            combat.Begin();
            boss.Setup(stage.boss);
            EventHub.OnCombatStarted?.Invoke();
        }

        public void EndCombat(bool playerDead)
        {
            State = GameState.Result;
            combat.End();
            spawn.StopAll();
            boss.Despawn();
            EventHub.OnCombatEnded?.Invoke();

            int finalGold = economy.ComputeFinalGold();
            EventHub.OnGoldFinalized?.Invoke(finalGold);
            ui.ShowResult(finalGold, playerDead);
        }
    }
}
