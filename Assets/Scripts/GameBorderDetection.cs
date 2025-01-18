using System;
using UnityEngine;

public class GameBorderDetection : MonoBehaviour
{
    public static event Action BorderTouched;

    [SerializeField]
    private LayerMask _borderLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == _borderLayer)
            BorderTouched?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (1 << collision.gameObject.layer == _borderLayer)
            BorderTouched?.Invoke();
    }
}
