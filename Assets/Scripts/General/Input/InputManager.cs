using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PlayerInput
{

    public class InputManager : MonoBehaviour
    {
        [SerializeField] InputData _inputData;

        private void Update()
        {
            _inputData.Horizontal = Input.GetAxisRaw("Horizontal");
            _inputData.Vertical = Input.GetAxisRaw("Vertical");
            _inputData.SprintTrigger = Input.GetKey(KeyCode.LeftShift);
            _inputData.JumpTrigger = Input.GetButtonDown("Jump");
        }
    }
}
