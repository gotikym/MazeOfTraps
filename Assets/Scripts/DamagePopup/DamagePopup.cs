using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private Transform _damagePopupSpawner;

    private float _disappearSpeed = 4f;
    private float _dividerInHalf = 0.5f;
    private int _minSpread = -10;
    private int _maxSpread = 10;

    private TextMeshPro _textMeshPro;
    private float _disappearTimer;
    private float _maxDisappearTimer;
    private Color _textColor;
    private Vector3 _moveVector;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        float increaseScaleAmount = 0.5f;
        float moveYSpeed = 0.01f;
        transform.position += _moveVector * Time.deltaTime;
        _moveVector -= _moveVector * moveYSpeed * Time.deltaTime;

        if (_disappearTimer > _maxDisappearTimer * _dividerInHalf)
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        else
            transform.localScale -= Vector3.one * increaseScaleAmount * Time.deltaTime;

        _disappearTimer -= Time.deltaTime;

        if (_disappearTimer < 0)
        {
            _textColor.a -= _disappearSpeed * Time.deltaTime;
            _textMeshPro.color = _textColor;

            if (_textColor.a < 0)
                Destroy(gameObject);
        }
    }

    public DamagePopup create(Vector3 position, Quaternion rotarion, float damageAmount)
    {
        Transform damagePopupTransform = Instantiate(_damagePopupSpawner, position, rotarion);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }

    public void Setup(float DamageAmount)
    {       
        _textMeshPro.SetText(DamageAmount.ToString());
        _textColor = _textMeshPro.color;
        _disappearTimer = 0.1f;
        _maxDisappearTimer = _disappearTimer;
        _moveVector = new Vector3(Random.Range(_minSpread, _maxSpread), Random.Range(_minSpread, _maxSpread), Random.Range(_minSpread, _maxSpread));
    }
}