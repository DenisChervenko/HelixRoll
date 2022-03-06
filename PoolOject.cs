 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolOject : MonoBehaviour
{
    [Header("Particle")]
    [SerializeField] private GameObject _cube;
    [SerializeField] private List<GameObject> _particleSpawned;
    [SerializeField] private Transform _pointForSpawnCube;
    [SerializeField] private int _countCube;
    private int _currentTurnParticle;
    private Vector3 _spawnPlaceForParticle;

    [Header("GameObject")]
    [SerializeField] private GameObject[] _objectForSpawn;
    [SerializeField] private List<GameObject> _objectWasSpawned;
    [SerializeField] private List<int> _numWasUsed;
    [SerializeField] private Transform _parentForPoolObject;
    [SerializeField] private int _countObjectForSpawn;
    private int _iteration;
    private int _iterationBetwenCheckDisableObject = 30;
    private int _turnEnemy;

    //variable for block duplicate
    private int _currentNumInList;
    private int _currentNumInListForDelete;
    private int _tempForMarkList;


    [Header("Spawn")]
    [SerializeField] private Transform _pointForSpawn;
    [SerializeField] private int _iterationBetwenMinusTimeSpawn;
    private int _iterationSpawnTime;
    private bool _doMoreIteration = true;
    private bool _needSpawn;
    private Vector3 _spawnPlace;
    static public bool _buttonWasPressed = false;

    [Header("Time")]
    [SerializeField] private float _timeBetwenSpawn;
    private float _elapsedTime;


    private void Start()
    {
        //spawn, adopt and disable gameObject
        for(int i = 0; i <= _countObjectForSpawn; i++)
        {
            _objectWasSpawned.Add(Instantiate(_objectForSpawn[0]));
            _objectWasSpawned.Add(Instantiate(_objectForSpawn[1]));
            _objectWasSpawned.Add(Instantiate(_objectForSpawn[2]));
            _objectWasSpawned.Add(Instantiate(_objectForSpawn[3]));


            if(i >= _countObjectForSpawn)
            {
                for(int j = 0; j <= 83; j++)
                {
                    _objectWasSpawned[j].transform.parent = _parentForPoolObject.transform;
                    if(j >= 83)
                    {
                        for(int k = 0; k <= 83; k++)
                        {
                            _objectWasSpawned[k].gameObject.SetActive(false);
                        }
                    }
                }
            }
        }

        //initialize place for spawn gameObject
        _spawnPlace = _pointForSpawn.transform.position;

        //particle
        for(int i = 0; i <= _countCube; i++)
        {
            _particleSpawned.Add(Instantiate(_cube));

            if(i >= _countCube)
            {
                for(int j = 0; j <= _countCube; j++)
                {
                    _particleSpawned[j].transform.SetParent(_parentForPoolObject);

                    if(j >= _countCube)
                    {
                        for(int k = 0; k <= _countCube; k++)
                        {
                            _particleSpawned[k].gameObject.SetActive(false);
                        }
                        
                    }
                }
            }
        }

        _spawnPlaceForParticle =_pointForSpawnCube.transform.position;
        
    }

    private void FixedUpdate()
    {
        if(_buttonWasPressed)
        {
            _elapsedTime += Time.fixedDeltaTime;

            if(_timeBetwenSpawn < 1)
            {
                _timeBetwenSpawn = 1;
                _doMoreIteration = false;
            }

            if(_elapsedTime >= _timeBetwenSpawn)
            {
                if(_doMoreIteration)
                {
                    _iterationSpawnTime++;

                    if(_iterationBetwenMinusTimeSpawn == _iterationSpawnTime)
                    {
                        _timeBetwenSpawn -= 0.2f;

                        _iterationSpawnTime = 0;
                    }
                }
                
                _turnEnemy = Random.Range(0, 83);

                //mark was used object
                for(int i = 0; i <= 83; i++)
                {
                    if(_numWasUsed[i] == _turnEnemy)
                    {
                        _needSpawn = false;
                        break;
                    }
                }

                for(int i = 0; ; ++i)
                {
                    i = _tempForMarkList;

                    if(i == 83)
                    {
                        if(_currentNumInListForDelete > 83)
                        {
                            _currentNumInListForDelete = 0;
                        }

                        i = 0;
                        _tempForMarkList = 0;

                        _numWasUsed[_currentNumInListForDelete] = 0;
                        _currentNumInListForDelete++;  
                    }

                    _numWasUsed[i] = _turnEnemy;
                    _tempForMarkList++;

                    break;
                }

                _currentNumInList++;
                if(_currentNumInList > 83)
                {
                    _currentNumInList = 0;
                }

                if(_needSpawn)
                {
                    _objectWasSpawned[_turnEnemy].transform.position = _spawnPlace;
                    _objectWasSpawned[_turnEnemy].gameObject.SetActive(true);

                    Debug.Log(_needSpawn);
                }
                else
                {
                    _particleSpawned[_currentTurnParticle].transform.position = _spawnPlaceForParticle;
                    _particleSpawned[_currentTurnParticle].gameObject.SetActive(true);

                    _currentTurnParticle++;

                    if(_currentTurnParticle > _countCube)
                    {
                        _currentTurnParticle = 0;
                    }

                    Debug.Log(_needSpawn);
                    _needSpawn = true;
                    
                }

                //clean list from disable object
                if(_iteration == _iterationBetwenCheckDisableObject)
                {
                    for(int i = 0; i <= 20; i++)
                    {
                        if(_currentNumInListForDelete > 83)
                        {
                            _currentNumInListForDelete = 0;
                        }

                        _numWasUsed[_currentNumInListForDelete] = 0;
                        _currentNumInListForDelete++;
                    }
                    _iteration = 0;
                }

                _iteration += 1;
                _elapsedTime = 0;
            } 
        }
    }
}
