using UnityEngine;

public class Accuracy : Skill
{
    private float _startValueInHitBar = 0.5f;
    private float _deltaSpreadValue = 0.009f;
    private float _spreadValue = 0.008f;

    private float _maxSpread => _startValueInHitBar + _spreadValue;
    private float _minSpread => _startValueInHitBar - _spreadValue;

    public override void Upgrade()
    {
        _spreadValue += _deltaSpreadValue;
        base.Upgrade();
    }

    public bool HitValueIsRange(float hitValue)
    {
        return hitValue >= _minSpread && hitValue <= _maxSpread;
    }
}
