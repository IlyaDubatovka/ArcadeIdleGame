using UnityEngine;

public class WallController : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _initialPosition;

    [SerializeField] private float _speed = 5f;

    [SerializeField] private float _distance = 10f;
    // Start is called before the first frame update
    void Awake()
    {
        _transform = GetComponent<Transform>();
        _initialPosition = _transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var position = _transform.position;
        position.x =_initialPosition.x+ Mathf.PingPong(Time.time*_speed , _distance);
        _transform.position = position;
    }
}
