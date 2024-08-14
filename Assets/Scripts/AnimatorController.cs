
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] VirtualJoystick _joystick;

    [SerializeField] private float _timerFreezingAnimation=1f;

    private float _timer;
    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _timer = _timerFreezingAnimation;
        _animator.speed=0;

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_joystick.isMoving)
        {
            _timer = 0;
            _animator.speed=1;
        }
        else
        {
            if (_timer<=_timerFreezingAnimation)
            {
                _animator.speed=0.3f;
                return;
            }
            _animator.speed=0;
        }
    }
}
