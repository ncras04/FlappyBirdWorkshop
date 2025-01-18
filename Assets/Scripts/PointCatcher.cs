using System;
using UnityEngine;

public class PointCatcher : MonoBehaviour
{
    public static event Action PointCollected;

    [SerializeField]
    private LayerMask _pointLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(1 << collision.gameObject.layer == _pointLayer)
            PointCollected?.Invoke();
    }
}
