namespace Game.Data
{
    using System;
    using UnityEngine;

    public enum SpawnArea { OuterRing, RandomEdge }

    [Serializable]
    public struct SpawnEntry
    {
        public EnemyData enemy;
        public float weight;           // 가중치
        public float spawnRatePerSec;  // 기본 스폰 속도
        public SpawnArea spawnArea;
    }

    [CreateAssetMenu(fileName = "WaveData", menuName = "Game/Stage/Wave")]
    public class WaveData : IdScriptableObject
    {
        public float waveDuration = 30f;
        public SpawnEntry[] spawnEntries;
    }

    [CreateAssetMenu(fileName = "StageData", menuName = "Game/Stage/Stage")]
    public class StageData : IdScriptableObject
    {
        public WaveData[] waves;
        public BossData boss;
        [Header("난이도 증가율(%)")]
        public float healthGrowthPerStage = 25f;
        public float spawnDensityGrowthPerStage = 15f;
    }
}
