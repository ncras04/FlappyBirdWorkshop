using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstacle = default;

    [SerializeField, Range(2.0f, 4.0f)]
    private float _spawnTime = 2.0f;

    private bool _isAlive = true;
    private float _timeSinceLastSpawn = 0.0f;
    private Stack<GameObject> _availableObjects = new(5);

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
        Death.DeathLayerTouched += OnDeathLayerTouched;
    }

    private void Start()
    {
        _isAlive = true;
    }

    private void Update()
    {
        if(!_isAlive)
            return;

        _timeSinceLastSpawn += Time.deltaTime;

        if (_timeSinceLastSpawn >= _spawnTime)
        {
            Spawn();
            _timeSinceLastSpawn = 0.0f;
            _spawnTime = Random.Range(2.0f, 4.0f);
        }
    }

    private void OnDisable()
    {
        Death.DeathLayerTouched -= OnDeathLayerTouched;
    }

    private void OnDeathLayerTouched()
    {
        _isAlive = false;
    }

    [ContextMenu("SPAWN!!")]
    private void Spawn()
    {
        if (_availableObjects.Count == 0)
            return;

        var obstacle = _availableObjects.Pop();
        float yPos = Random.Range(-1.5f, 3);

        obstacle.SetActive(true);
        obstacle.transform.position = new Vector3(5, yPos, 0);
    }
}
