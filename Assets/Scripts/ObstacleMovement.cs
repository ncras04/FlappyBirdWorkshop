using System;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Action ReturnToSpawner;

    [SerializeField]
    private float _translationSpeed = 5.0f;
    private bool _gameRunning;

    public float TranslationSpeed { get => _translationSpeed; private set => _translationSpeed = value; }

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

        transform.position -= new Vector3(_translationSpeed, 0, 0) * Time.deltaTime;
    }
    private void OnDisable()
    {
        GameBorderDetection.BorderTouched -= OnBorderTouched;
    }
    private void OnBorderTouched()
    {
        _gameRunning = false;
    }

    public void ChangeSpeed(float speedChange)
    {
        _translationSpeed += speedChange;
    }
}
