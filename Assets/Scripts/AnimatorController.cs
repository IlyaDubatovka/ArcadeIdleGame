
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] VirtualJoystick _joystick;
    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
  
        if (_joystick.isMoving)
        {
            _animator.speed=1;
        }
        else
        {
            _animator.speed=0;
        }
    }
}
