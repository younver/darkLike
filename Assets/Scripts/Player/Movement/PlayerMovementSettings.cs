using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PlayerMovement
{
    [CreateAssetMenu(menuName = "Player/Movement/Movement Settings")]
    public class PlayerMovementSettings : ScriptableObject
    {
        public float Gravity = -9.81f;
        public float Speed = 3f;
        public float SprintSpeed = 7f;
        public float JumpSpeed = 10f;
        public float RotationSpeed = 15f;
        public float AnimationBlendSpeed = 5f;
        
    }
}