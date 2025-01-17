using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _obstacle = default;

    private Stack<GameObject> _availableObjects = new();
    private int frame = 0;

    private void Awake()
    {
        for (int i = 0; i < 5; i++)
        {
            var tmp = Instantiate(_obstacle);
            tmp.SetActive(false);

            tmp.GetComponent<ObstacleMovement>().ReturnToSpawner = () => { _availableObjects.Push(tmp); tmp.SetActive(false); };

            _availableObjects.Push(tmp);

        }
    }

    private void OnEnable()
    {
        Death.DeathLayerTouched += OnDeathLayerTouched;
    }

    private void Update()
    {
        frame++;

        if (frame % 500 == 0)
        {
            Spawn();
        }
    }

    private void OnDisable()
    {
        Death.DeathLayerTouched -= OnDeathLayerTouched;
    }

    private void OnDeathLayerTouched()
    {
        this.gameObject.SetActive(false);
    }

    [ContextMenu("SPAWN!!")]
    private void Spawn()
    {
        var tmp = _availableObjects.Pop();
        float yPos = Random.Range(-1.5f, 3);
        tmp.SetActive(true);
        tmp.transform.position = new Vector3(5, yPos, 0);
    }
}
