using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerReward))]
public class PlayerHitHandler : MonoBehaviour
{
    [SerializeField] private Accuracy _accuracy;
    [SerializeField] private Stamina _stamina;
    [SerializeField] private ParticleSystem _hitEffect;

    private Player _player;
    private PlayerReward _playerReward;
    private Nail _currentNail;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerReward = GetComponent<PlayerReward>();
    }

    private void OnEnable()
    {
        _player.StoppedMove += OnHit;
    }

    private void OnDisable()
    {
        _player.StoppedMove -= OnHit;
    }

    public void SetNail(Nail nail)
    {
        _currentNail = nail;
    }

    private void OnHit(float hitValue)
    {
        if (_currentNail.gameObject.activeSelf == false)
            return;

        ParticleSystem effect = Instantiate(_hitEffect, _currentNail.HatPoint.position, Quaternion.identity);
        effect.Play();

        if (_accuracy.HitValueIsRange(hitValue))
        {
            _currentNail.Move();
            _playerReward.SetSeriesForGreatHit();
            return;
        }
        
        if (_stamina.HitValueIsRange(hitValue))
        {
            _currentNail.Move();
            _playerReward.SetSeiresForGoodHit();
            return;
        }

        _currentNail.Break();
    }
}
