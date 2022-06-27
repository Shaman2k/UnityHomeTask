using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    public event UnityAction InvasionDetected;
    public event UnityAction InvasionEnd;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            InvasionDetected?.Invoke();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            InvasionEnd?.Invoke();
    }
}
