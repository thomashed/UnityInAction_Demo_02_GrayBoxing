using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UnityDemo.EntityBehaviors
{
    public class ControllableView: BaseView<ControllableModel, ControllableController>
    {
        [SerializeField] private float _movementSpeed = 40f;
        [FormerlySerializedAs("_rotationSpeed")] [SerializeField] private float _rotationSpeedVertical = 10f;
        [SerializeField] private float _rotationSpeedHorizontal = 10f;

        private readonly float _minRotationLimit = -45f;
        private readonly float _maxRotationLimit = 45f;
        private float _verticalRotation = 0f;
        private float _horizontalRotation = 0f;

        [SerializeField]
        private AxisToTrackRotation _axesRotation;

        private enum AxisToTrackPosition
        {
            AxisX,
            AxisY,
            AxisZ,
            AxisXYZ
        }
        
        private enum AxisToTrackRotation
        {
            AxisX = 0,
            AxisY = 1,
            AxisZ = 2,
            AxisXYZ = 3
        }


        protected override void Awake()
        {
            base.Awake();
            
        }

        private void Update()
        {
            Movement();
            Rotation();
        }

        private void Rotation()
        {
            var deltaY = 0f;
            var deltaX = 0f;
            
            if (_axesRotation == AxisToTrackRotation.AxisY)
            {
                deltaY = Input.GetAxis("Mouse X") * _rotationSpeedHorizontal;
            }
            
            if (_axesRotation == AxisToTrackRotation.AxisX)
            {
                deltaX = Input.GetAxis("Mouse Y") * _rotationSpeedVertical;
            }
            
            _horizontalRotation += deltaY * Time.deltaTime;
            _verticalRotation -= Mathf.Clamp(deltaX, _minRotationLimit, _maxRotationLimit) * Time.deltaTime;
            
            transform.localEulerAngles = new Vector3(_verticalRotation,_horizontalRotation,0);
        }

        private void Movement()
        {
            var (newX, newZ) = GetAxisValuesMovement();
            var newPosition = new Vector3(newX * _movementSpeed, 0f, newZ * _movementSpeed) * Time.deltaTime;
            newPosition = Vector3.ClampMagnitude(newPosition, _movementSpeed);
            
            transform.Translate(newPosition);
        }

        private (float, float) GetAxisValuesMovement() => (
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical")
                );

        private (float, float) GetAxisRotation() => (
            Input.GetAxis("Mouse X"), 
            Input.GetAxis("Mouse Y")
            );

    }

    public class ControllableController : BaseController<ControllableModel>
    {
        
    }
    
    [Serializable]
    public class ControllableModel : BaseModel
    {
        [SerializeField]
        private string TestPropFromInheritor = "HiHi";
    }
    
}


