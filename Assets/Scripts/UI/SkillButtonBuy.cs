using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class SkillButtonBuy : MonoBehaviour
{
    [SerializeField] private TMP_Text _value;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private PlayerWallet _playerWallet;
    [SerializeField] private Button _button;
    [SerializeField] private CanvasGroup _canvasGroup;

    protected PlayerWallet PlayerWallet => _playerWallet;
    protected Button Button => _button;

    protected void SkillUpgrade(Skill skill)
    {
        _playerWallet.DecreaseCoins((int)skill.CurrentPrice);
        skill.Upgrade();
    }

    protected void UpdateView(Skill skill)
    {
        if (_playerWallet.Coins < skill.CurrentPrice)
        {
            _button.interactable = false;
            _canvasGroup.alpha = 0.5f;
        }
        else
        {
            _button.interactable = true;
            _canvasGroup.alpha = 1f;
        }

        _value.text = skill.CurrentValue.ToString("0.0");
        _price.text = skill.CurrentPrice.ToString();
    }
}
