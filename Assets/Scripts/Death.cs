using System;
using UnityEngine;

public class Death : MonoBehaviour
{
    public static event Action DeathLayerTouched;

    [SerializeField]
    private LayerMask _deathLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == _deathLayer)
            DeathLayerTouched?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (1 << collision.gameObject.layer == _deathLayer)
            DeathLayerTouched?.Invoke();
    }
}
