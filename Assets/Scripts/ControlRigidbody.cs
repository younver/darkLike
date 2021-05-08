using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class ControlRigidbody : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ControlRigidbodySettings _settings;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            
        }
    }
}