using UnityEngine;

public class AccuracyRangeView : SkillRangeView
{
    [SerializeField] private Accuracy _accuracy;

    private void OnEnable()
    {
        _accuracy.SkillUpgraded += OnSkillUpgraded;
        OnSkillUpgraded();
    }

    private void OnDisable()
    {
        _accuracy.SkillUpgraded -= OnSkillUpgraded;
    }

    private void OnSkillUpgraded()
    {
        OnRangeChanged(_accuracy.CurrentValue);
    }
}
