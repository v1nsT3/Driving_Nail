using UnityEngine;

public class StaminaButton : SkillButtonBuy
{
    [SerializeField] private Stamina _stamina;

    private void OnEnable()
    {
        _stamina.SkillUpgraded += OnSkillUpgraded;
        PlayerWallet.CoinsChanged += OnCoinsChanged;
        Button.onClick.AddListener(OnClickButton);
    }

    private void OnDisable()
    {
        _stamina.SkillUpgraded -= OnSkillUpgraded;
        PlayerWallet.CoinsChanged -= OnCoinsChanged;
        Button.onClick.RemoveListener(OnClickButton);
    }

    private void OnCoinsChanged(int coins)
    {
        UpdateView(_stamina);
    }

    private void OnSkillUpgraded()
    {
        UpdateView(_stamina);
    }

    private void OnClickButton()
    {
        SkillUpgrade(_stamina);
    }
}
