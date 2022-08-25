using UnityEngine;

public class AccuracyButton : SkillButtonBuy
{
    [SerializeField] private Accuracy _accuracy;

    private void OnEnable()
    {
        _accuracy.SkillUpgraded += OnSkillUpgraded;
        PlayerWallet.CoinsChanged += OnCoinsChanged;
        Button.onClick.AddListener(OnClickButton);
    }

    private void OnDisable()
    {
        _accuracy.SkillUpgraded -= OnSkillUpgraded;
        PlayerWallet.CoinsChanged -= OnCoinsChanged;
        Button.onClick.RemoveListener(OnClickButton);
    }

    private void OnCoinsChanged(int coins)
    {
        UpdateView(_accuracy);
    }

    private void OnSkillUpgraded()
    {
        UpdateView(_accuracy);
    }

    private void OnClickButton()
    {
        SkillUpgrade(_accuracy);
    }
}
