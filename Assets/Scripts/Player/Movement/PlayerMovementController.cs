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
        private float mSpeedY = 0f;
        private bool mJumping = false;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            //JUMP
            if(_inputData.JumpTrigger && !mJumping)
            {
                mJumping = true;
                _animator.SetTrigger("Jump");

                mSpeedY += _settings.JumpSpeed;
            }

            //GRAVITY
            if (!_controller.isGrounded)
            {
                mSpeedY += _settings.Gravity * Time.deltaTime;
            }
            else if (mSpeedY<0)
            {
                mSpeedY = 0f;
            }

            _animator.SetFloat("SpeedY", mSpeedY / _settings.JumpSpeed);

            //LAND
            if (mJumping && mSpeedY < 0)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f, LayerMask.GetMask("Default")))
                {
                    mJumping = false;
                    _animator.SetTrigger("Land");
                }
            }

            //MOVEMENT
            Vector3 movement = new Vector3(_inputData.Horizontal,
                0, _inputData.Vertical).normalized;

            Vector3 rotatedMovement = Quaternion.Euler(0, _camera.transform.rotation.eulerAngles.y, 0) * movement;
            Vector3 verticalMovement = Vector3.up * mSpeedY;

            _controller.Move((verticalMovement + (rotatedMovement * (_inputData.SprintTrigger ? _settings.SprintSpeed : _settings.Speed))) * Time.deltaTime );

            if(rotatedMovement.magnitude > 0)
            {
                mDesiredRotation = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                mDesiredAnimationSpeed = _inputData.SprintTrigger ? 1f : 0.5f;
            }
            else
            {
                mDesiredAnimationSpeed = 0f;
            }

            _animator.SetFloat("Speed", Mathf.Lerp(_animator.GetFloat("Speed"), mDesiredAnimationSpeed, _settings.AnimationBlendSpeed * Time.deltaTime));

            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0, mDesiredRotation, 0);
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, _settings.RotationSpeed * Time.deltaTime);
        }
    }
}