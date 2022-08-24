using UnityEngine;

[System.Serializable]
public struct Series 
{
    [SerializeField] private string _name;
    [SerializeField] private Income _income;
    [SerializeField] private int _multiplier;
    [SerializeField] private int _multiplierIncome;

    public string Name => _name;
    public int Multiplier => _multiplier;
    public int CoinsAmmount => (int) _income.CurrentValue * _multiplierIncome;
}
