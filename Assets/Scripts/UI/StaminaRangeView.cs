using UnityEngine;

public class StaminaRangeView : SkillRangeView
{
    [SerializeField] private Stamina _stamina;

    private void OnEnable()
    {
        _stamina.SkillUpgraded += OnSkillUpgraded;
        OnSkillUpgraded();
    }

    private void OnDisable()
    {
        _stamina.SkillUpgraded -= OnSkillUpgraded;
    }

    private void OnSkillUpgraded()
    {
        OnRangeChanged(_stamina.CurrentValue);
    }
}
