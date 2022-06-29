using UnityEngine;

public class DoorsAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.name);
 //       if (collision.TryGetComponent<Enemy>(out Enemy enemy))
 //           _animator.Play("OpenDoor");
 //       GetComponent<BoxCollider>().enabled = false
    }
}
