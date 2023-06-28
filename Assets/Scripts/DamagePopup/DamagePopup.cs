using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private Transform _damagePopupSpawner;

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

        if (_disappearTimer > _maxDisappearTimer * 0.5f)
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        else
            transform.localScale -= Vector3.one * increaseScaleAmount * Time.deltaTime;

        _disappearTimer -= Time.deltaTime;

        if (_disappearTimer < 0)
        {
            float disappearSpeed = 4f;
            _textColor.a -= disappearSpeed * Time.deltaTime;
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
        _moveVector = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
    }
}