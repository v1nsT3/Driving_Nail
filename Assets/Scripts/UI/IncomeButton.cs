using UnityEngine;

public class IncomeButton : SkillButtonBuy
{
    [SerializeField] private Income _income;

    private void OnEnable()
    {
        _income.SkillUpgraded += OnSkillUpgraded;
        PlayerWallet.CoinsChanged += OnCoinsChanged;
        Button.onClick.AddListener(OnClickButton);
    }

    private void OnDisable()
    {
        _income.SkillUpgraded -= OnSkillUpgraded;
        PlayerWallet.CoinsChanged -= OnCoinsChanged;
        Button.onClick.RemoveListener(OnClickButton);
    }

    private void OnCoinsChanged(int coins)
    {
        UpdateView(_income);
    }

    private void OnSkillUpgraded()
    {
        UpdateView(_income);
    }

    private void OnClickButton()
    {
        SkillUpgrade(_income);
    }
}
