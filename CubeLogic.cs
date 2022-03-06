using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLogic : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private GameObject _cube;
    [SerializeField] private float _moveSpeed;

    private AudioSource _audioSource;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();


        if(!_cube.activeSelf)
        {
            _cube.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        MoveCube();
    }

    private void MoveCube()
    {
        _rb.velocity = new Vector3(0, 0, _moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _cube.SetActive(false);
        }
        if(other.gameObject.CompareTag("DisableEnemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
