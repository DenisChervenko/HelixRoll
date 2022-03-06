using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    private float _angleForRandomRotate;

    private Rigidbody _rb;


    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();

        _angleForRandomRotate = Random.Range(0, 360);

        gameObject.transform.Rotate(0, 0, _angleForRandomRotate);
    }

    private void FixedUpdate()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        _rb.velocity = new Vector3(0, 0, _speedMove);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DisableEnemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
