using System;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteA;
    [SerializeField]
    private SpriteRenderer _spriteB;

    [SerializeField]
    float translationSpeed = 1.0f;

    private Vector3 _startPositionA;
    private Vector3 _startPositionB;
    private bool _isAlive;

    private void OnEnable()
    {
        Death.DeathLayerTouched += OnDeathLayerTouched;
    }

    private void Start()
    {
        _isAlive = true;
        _startPositionA = _spriteA.transform.position;
        _startPositionB = _spriteB.transform.position;
    }

    private void Update()
    {
        if (_isAlive)
        {
            if (_spriteB.transform.position.x <= _startPositionA.x)
            {
                _spriteA.transform.position = _startPositionB;

                (_spriteA, _spriteB) = (_spriteB, _spriteA);
            }

            _spriteA.transform.position += new Vector3(-translationSpeed, 0, 0) * Time.deltaTime;
            _spriteB.transform.position += new Vector3(-translationSpeed, 0, 0) * Time.deltaTime;
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
}

