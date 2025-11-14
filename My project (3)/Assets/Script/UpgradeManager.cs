using UnityEngine;
using Game.Data;

namespace Game.Runtime
{
    public class UpgradeManager : MonoBehaviour
    {
        [SerializeField] PlayerManager player;
        [SerializeField] UpgradeData[] upgradePool; // юс╫ц г╝

        public UpgradeData[] Offer3()
        {
            var picks = new UpgradeData[3];
            for (int i = 0; i < 3; i++)
                picks[i] = upgradePool[Random.Range(0, upgradePool.Length)];
            EventHub.OnUpgradeOffered?.Invoke();
            return picks;
        }

        public void Apply(UpgradeData upg)
        {
            foreach (var m in upg.effects)
                player.ApplyModifier(m);
            EventHub.OnUpgradeSelected?.Invoke(upg);
            EventHub.OnHideLevelUpUI?.Invoke();
        }
    }
}