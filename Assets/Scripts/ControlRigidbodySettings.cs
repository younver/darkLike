using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName="Player/Controller/Rigidbody Controller Settings")]
    public class ControlRigidbodySettings : ScriptableObject
    {
        [SerializeField] private float _moveSpeed;
        public float MoveSpeed { get { return _moveSpeed; } }
    }
}
