using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _fillDuration = 10f;

    private Coroutine _changeHealthBarJob;
 
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
        if (_changeHealthBarJob != null)
            StopCoroutine(_changeHealthBarJob);

        _changeHealthBarJob = StartCoroutine(ChangeHealthBar(value, maxValue));
    }

    private IEnumerator ChangeHealthBar(int value, int maxValue)
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
