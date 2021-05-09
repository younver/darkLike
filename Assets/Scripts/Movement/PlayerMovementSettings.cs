using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PlayerMovement
{
    [CreateAssetMenu(menuName = "Player/Movement/Movement Settings")]
    public class PlayerMovementSettings : ScriptableObject
    {
        public float HorizontalSpeed = 5f;
        public float VerticalSpeed = 5f;
        
    }
}