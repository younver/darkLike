using Player.PlayerInput;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PlayerMovement
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller; //rigidbody-controller
        [SerializeField] private InputData _inputData;
        [SerializeField] private PlayerMovementSettings _settings;
        [SerializeField] private Camera _camera;
        [SerializeField] private Animator _animator;

        private float mDesiredRotation = 0f;
        private float mDesiredAnimationSpeed = 0f;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector3 movement = new Vector3(_inputData.Horizontal,
                0, _inputData.Vertical).normalized;

            Vector3 rotatedMovement = Quaternion.Euler(0, _camera.transform.rotation.eulerAngles.y, 0) * movement;

            _controller.Move(rotatedMovement * (_inputData.isSprinting ? _settings.SprintSpeed : _settings.Speed) * Time.deltaTime );

            if(rotatedMovement.magnitude > 0)
            {
                mDesiredRotation = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                mDesiredAnimationSpeed = _inputData.isSprinting ? 1f : 0.5f;
            }
            else
            {
                mDesiredAnimationSpeed = 0f;
            }

            _animator.SetFloat("Move_LocalPlayer", Mathf.Lerp(_animator.GetFloat("Move_LocalPlayer"), mDesiredAnimationSpeed, _settings.AnimationBlendSpeed * Time.deltaTime));

            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0, mDesiredRotation, 0);
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, _settings.RotationSpeed * Time.deltaTime);
        }
    }
}