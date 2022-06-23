using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _fillDuration = 10f;

    private Player _player;
    private Coroutine _changeHealthJob;
 

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        _slider.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    public void OnValueChanged(int value, int maxValue)
    {
        if (_changeHealthJob != null)
            StopCoroutine(_changeHealthJob);

        _changeHealthJob = StartCoroutine(ChangeHealth(value, maxValue));
    }

    private IEnumerator ChangeHealth(int value, int maxValue)
    {
        float targetValue = (float)value / maxValue;
        float delta = Time.deltaTime/_fillDuration;

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, delta);

            yield return null;
        }
    }
}
