using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 _cameraOffset;

    [SerializeField] private Transform _playerTransform;

    private void Awake()
    {
        var transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position =new Vector3(_playerTransform.position.x+_cameraOffset.x,_cameraOffset.y,_playerTransform.position.z+_cameraOffset.z);
        transform.position = _playerTransform.position + _cameraOffset;
    }
}
