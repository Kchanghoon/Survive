using UnityEngine;
using Game.Data;

namespace Game.Runtime
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] Transform playerRoot;

        public CharacterData Character { get; private set; }
        public StatBlock Stats { get; private set; }   // 값 타입 프로퍼티 (private set 유지)
        public AttackProfile Attack => Character?.attack;

        public void LoadCharacter(CharacterData data)
        {
            Character = data;
            Stats = data.baseStats;  // 초기 세팅
            // 프리팹 스폰 등 필요 시 처리
        }

        // StatModifier 적용: 로컬로 복사 → 수정 → 다시 세팅
        public void ApplyModifier(StatModifier m)
        {
            var s = Stats;

            switch (m.targetStat)
            {
                case StatType.Hp: s.hp = Apply(s.hp, m); break;
                case StatType.Atk: s.atk = Apply(s.atk, m); break;
                case StatType.AtkSpeed: s.atkSpeed = Apply(s.atkSpeed, m); break;
                case StatType.MoveSpeed: s.moveSpeed = Apply(s.moveSpeed, m); break;
                case StatType.CritChance: s.critChance = Apply(s.critChance, m); break;
                case StatType.CritDamage: s.critDamage = Apply(s.critDamage, m); break;
                case StatType.Range: s.range = Apply(s.range, m); break;
                case StatType.ProjectileSpeed: s.projectileSpeed = Apply(s.projectileSpeed, m); break;
                case StatType.Evasion: s.evasion = Apply(s.evasion, m); break;
                // ProjectileCount, ShieldInterval, ExpGainRate 등은
                // 플레이어 고정 스탯이 아니라 시스템/무기 쪽에서 별도 적용 권장
                default: break;
            }

            Stats = s;  // 수정한 값 다시 반영
        }

        // 값 타입 수정용 헬퍼: 새 값 계산 후 반환
        private float Apply(float current, StatModifier m)
        {
            switch (m.op)
            {
                case ModifierOp.Add: return current + m.value;
                case ModifierOp.Multiply: return current * m.value;
                case ModifierOp.Override: return m.value;
                default: return current;
            }
        }

        public void Damage(float amount)
        {
            var s = Stats;
            s.hp -= amount;
            Stats = s;

            EventHub.OnPlayerDamaged?.Invoke(amount);
            if (Stats.hp <= 0)
            {
                // 언더플로 방지
                s = Stats;
                s.hp = 0;
                Stats = s;

                EventHub.OnPlayerDied?.Invoke();
            }
        }
    }
}
