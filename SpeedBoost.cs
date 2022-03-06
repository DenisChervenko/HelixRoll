using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float _timeBetvenAcceleration;
    [SerializeField] private float _stepForBoostSpeed;
    [SerializeField] private float _maxSpeed;

    static public float _tempForSpeed = 1;

    private float _elapsedTime;

    private void FixedUpdate()
    {
        if(PoolOject._buttonWasPressed)
        {
            _elapsedTime += Time.fixedDeltaTime;

            if(_elapsedTime >= _timeBetvenAcceleration)
            {
                if(_tempForSpeed >= _maxSpeed)
                {
                    _tempForSpeed = _maxSpeed;
                }

                _tempForSpeed += _stepForBoostSpeed;

                Time.timeScale = _tempForSpeed;

                _elapsedTime = 0;
            }
        }
    }
}
