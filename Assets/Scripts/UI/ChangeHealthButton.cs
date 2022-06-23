using UnityEngine;

public class ChangeHealthButton : MonoBehaviour
{
    [SerializeField] private int _healthChangeValue = 10;

    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    public void OnButtonClick()
    {
        _player.ChangeHealth(_healthChangeValue);
    }
}
