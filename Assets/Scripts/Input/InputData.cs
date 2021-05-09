using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PlayerInput
{
    [CreateAssetMenu(menuName = "Player/Input/Input Data")]
    public class InputData : ScriptableObject
    {
        public float Horizontal;
        public float Vertical;
    }
}