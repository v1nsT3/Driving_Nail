using UnityEngine;
using UnityEngine.Events;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] private float _currentValue;
    [SerializeField] private float _deltaValue;
    [SerializeField] private float _currentPrice;
    [SerializeField] private float _deltaPrice;

    public event UnityAction SkillUpgraded;

    public float CurrentValue => _currentValue;
    public float CurrentPrice => _currentPrice;

    public virtual void Upgrade()
    {
        _currentValue += _deltaValue;
        _deltaPrice++;
        _currentPrice += _deltaPrice;
        SkillUpgraded?.Invoke();
    }
}
