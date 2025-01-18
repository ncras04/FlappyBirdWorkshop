using System;
using TMPro;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    private TextMeshProUGUI _counterField;

    private int _counter = 0;

    private void Awake()
    {
        _counterField = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        PointCatcher.PointCollected += OnPointCollected;
    }

    private void Start()
    {
        _counterField.text = _counter.ToString();
    }

    private void OnDisable()
    {
        PointCatcher.PointCollected -= OnPointCollected;
    }

    private void OnPointCollected()
    {
        _counter += 1;
        _counterField.text = _counter.ToString();
    }
}
