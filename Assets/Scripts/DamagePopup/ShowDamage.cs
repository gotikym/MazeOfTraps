using UnityEngine;

public class ShowDamage : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private DamagePopup _damagePopup;
    [SerializeField] private Transform _damagePopupSpawner;

    private void Awake()
    {
        _player.TakedDamage += SpawnDamagePopup;
    }

    private void OnDisable()
    {
        _player.TakedDamage -= SpawnDamagePopup;        
    }

    private void SpawnDamagePopup(float damage)
    {
        _damagePopup.create(_damagePopupSpawner.position, _player.transform.localRotation, damage);
    }
}
