using System;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Action ReturnToSpawner;

    [SerializeField]
    private float _translationSpeed = 5.0f;

    public float TranslationSpeed { get => _translationSpeed; private set => _translationSpeed = value; }

    private void OnEnable()
    {
        Death.DeathLayerTouched += OnDeathLayerTouched;
    }

    private void Update()
    {
        transform.position -= new Vector3(_translationSpeed, 0, 0) * Time.deltaTime;

        if (transform.position.x < -5)
            ReturnToSpawner();
    }
    private void OnDisable()
    {
        Death.DeathLayerTouched -= OnDeathLayerTouched;
    }
    private void OnDeathLayerTouched()
    {
        _translationSpeed = 0;
    }

    public void ChangeSpeed(float speedChange)
    {
        _translationSpeed += speedChange;
    }
}
