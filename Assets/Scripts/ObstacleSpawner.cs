using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private bool _gameRunning = true;
    public GameObject _obstacle;

    [Range(2.0f, 4.0f)]
    public float _spawnTime = 2.0f;
    private float _timeSinceLastSpawn = 0.0f;


    private Stack<GameObject> _availableObjects = new Stack<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            var obstacle = Instantiate(_obstacle, this.transform);
            obstacle.SetActive(false);
            obstacle.GetComponent<ObstacleMovement>().ReturnToSpawner = () => { _availableObjects.Push(obstacle); obstacle.SetActive(false); };
            _availableObjects.Push(obstacle);
        }
    }

    private void OnEnable()
    {
        GameBorderDetection.BorderTouched += OnBorderTouched;
    }

    private void Start()
    {
        _gameRunning = true;
    }

    private void Update()
    {
        if (!_gameRunning)
            return;
    }

    private void Spawn()
    {
        if (_availableObjects.Count == 0)
            return;
    }

    private void OnDisable()
    {
        GameBorderDetection.BorderTouched -= OnBorderTouched;
    }

    private void OnBorderTouched()
    {
        _gameRunning = false;
    }
}
