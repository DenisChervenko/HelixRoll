using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CylindreRotate : MonoBehaviour
{
    [Header("Particle")]
    [SerializeField] private GameObject _particle;
    [SerializeField] private float _stepRotateParticle;
    [SerializeField] private Transform _pointForResetRotation;
    private Vector3 _particleRotate;

    [Header("Cylindre")]
    [SerializeField] private float _stepRotateLeft;
    [SerializeField] private float _stepRotateRight;

    private bool _leftRotate = false;
    private bool _rightRotate = false;

    private void FixedUpdate()
    {
        if(_leftRotate)
        {
            transform.Rotate(0, 0, _stepRotateLeft * Time.fixedDeltaTime, Space.World);
            ParticleRotateLeft();
        }

        if(_rightRotate)
        {
            transform.Rotate(0, 0, _stepRotateRight * Time.fixedDeltaTime, Space.World);
            ParticleRotateRight();
        }

        if(_leftRotate == false && _rightRotate == false)
        {
            ParticleResetAngle();
        }
    }

    public void LeftRotate()
    {
        _leftRotate = true;
    }
    public void LeftUnRot()
    {
        _leftRotate = false;
    }

    public void RightRotate()
    {
        _rightRotate = true;
    }
    public void RightUnRot()
    {
        _rightRotate = false;
    }

    private void ParticleRotateLeft()
    {
        _stepRotateParticle += 0.4f;

        _particle.transform.eulerAngles = new Vector3(0, _stepRotateParticle, 0);

        if(_stepRotateParticle >= 15f)
        {
            _stepRotateParticle = 15f;
        }
    }

    private void ParticleRotateRight()
    {
        _stepRotateParticle -= 0.4f;

        _particle.transform.eulerAngles = new Vector3(0, _stepRotateParticle, 0);

        if(_stepRotateParticle <= -15f)
        {
            _stepRotateParticle = -15f;
        }
    }

    private void ParticleResetAngle()
    {
        _stepRotateParticle = 0;
        _particle.transform.rotation = Quaternion.RotateTowards(_particle.transform.rotation, _pointForResetRotation.rotation, 0.5f);
    }
}
