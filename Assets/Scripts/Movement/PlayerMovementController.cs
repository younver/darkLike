using Player.PlayerInput;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PlayerMovement
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private InputData _inputData;
        [SerializeField] private PlayerMovementSettings _settings;

        private void Update()
        {
            _rigidbody.MovePosition(_rigidbody.position + (_rigidbody.transform.forward * _inputData.Vertical * 
                _settings.VerticalSpeed * Time.deltaTime));

            _rigidbody.MovePosition(_rigidbody.position + (_rigidbody.transform.right * _inputData.Horizontal * 
                _settings.HorizontalSpeed * Time.deltaTime));
        }
    }
}