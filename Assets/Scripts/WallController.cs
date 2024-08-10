using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    private Transform _transform;
    
    // Start is called before the first frame update
    void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
