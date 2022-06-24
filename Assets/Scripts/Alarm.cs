using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private GameObject _alarmLight;
    [SerializeField] private Color _alarmColor;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _volumeChangeDuration = 5f;

    private Renderer _renderer;
    private Color _defaultColor;
    private Coroutine _coroutine;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    
    private void Start()
    {
        _renderer = _alarmLight.GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _renderer.material.color = _alarmColor;
            _audioSource.volume = _minVolume;
            _audioSource.Play();

            if(_coroutine !=null)
            StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(IncreaseVolume(_minVolume, _maxVolume));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _renderer.material.color = _defaultColor;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(DecreaseVolume(_minVolume));
        }
    }

    private IEnumerator IncreaseVolume(float startVolume, float targetVolume)
    {
        float currentTime = 0;

        while (currentTime < _volumeChangeDuration)
        {
            currentTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / _volumeChangeDuration);
            yield return null;
        }
        yield break;
    }

    private IEnumerator DecreaseVolume(float targetVolume)
    {
        float currentTime = 0;
        float startVolume = _audioSource.volume;

        while (currentTime < _volumeChangeDuration* startVolume)
        {
            currentTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(startVolume, targetVolume, currentTime / (_volumeChangeDuration * startVolume));
            yield return null;
        }
        _audioSource.Stop();
        yield break;
    }
}
