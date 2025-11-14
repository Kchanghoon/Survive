using UnityEngine;
using Game.Data;

namespace Game.Runtime
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] UpgradeManager upgrade;
        [SerializeField] GameObject levelUpPanel;
        [SerializeField] GameObject resultPanel;

        void OnEnable()
        {
            EventHub.OnShowLevelUpUI += ShowLevelUp;
            EventHub.OnHideLevelUpUI += HideLevelUp;
            EventHub.OnShowResultUI += () => resultPanel?.SetActive(true);
        }

        void OnDisable()
        {
            EventHub.OnShowLevelUpUI -= ShowLevelUp;
            EventHub.OnHideLevelUpUI -= HideLevelUp;
        }

        void ShowLevelUp()
        {
            var options = upgrade.Offer3();
            // 카드 3개에 options 바인딩
            levelUpPanel?.SetActive(true);
        }

        public void OnSelectUpgrade(UpgradeData upg)
        {
            upgrade.Apply(upg);
        }

        public void ShowResult(int finalGold, bool playerDead)
        {
            // 결과 수치 바인딩
            resultPanel?.SetActive(true);
        }

        void HideLevelUp() => levelUpPanel?.SetActive(false);
    }
}