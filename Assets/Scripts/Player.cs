using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int value)
    {
        _currentHealth -= value;

        if (_currentHealth < 0)
            _currentHealth = 0;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }


    public void TakeHeal(int value)
    {
        _currentHealth += value;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
