using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Healthbar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _animationStep = 0.005f;
    [SerializeField] private GameObject _fill;
    [SerializeField] private Color _maxHealthColor = new Color(0, 188, 25);
    [SerializeField] private Color _minHealthColor = new Color(255, 0, 0);
    [SerializeField] private float _distanseOfFreezedColor = 0.1f;

    private Slider _slider;
    private Image _fillImage;
    private Coroutine _previousCoroutine = null;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _fillImage = _fill.GetComponent<Image>();
        _slider.value = _player.GetComponent<Player>().Health;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value, int maxValue)
    {
        float newValue = (float)value / maxValue;

        if (_previousCoroutine != null)
            StopCoroutine( _previousCoroutine);

        _previousCoroutine = StartCoroutine(ChangeValue(newValue));
    }

    private IEnumerator ChangeValue(float newValue)
    {
        WaitForSeconds delay = new WaitForSeconds(0.01f);

        while (_slider.value != newValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, newValue, _animationStep);
            _fillImage.color = Color.Lerp(_minHealthColor, _maxHealthColor, _slider.value + _distanseOfFreezedColor);

            yield return delay;
        }
    }
}
