using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _waitTime = 0.5f;
    [SerializeField] private float _valueForIncreaseTime = 1;

    private int _numberLeftMouseButton = 0;

    private float _currentTime = 0;

    private Coroutine _coroutine;

    public event Action<float> ChangedCurrentTime;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_numberLeftMouseButton))
        {
            if (_coroutine != null)
            {
                Suspend();
            }
            else
            {
                Resume();
            }
        }
    }

    private void Suspend()
    {
        Debug.Log("Счетчик приостановлен.");

        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private void Resume()
    {
        Debug.Log("Счетчик запустился.");

        _coroutine = StartCoroutine(IncreaseTime());
    }

    private IEnumerator IncreaseTime()
    {
        WaitForSeconds wait = new WaitForSeconds(_waitTime);

        while (true)
        {
            _currentTime += _valueForIncreaseTime;

            ChangedCurrentTime?.Invoke(_currentTime);

            yield return wait;
        }
    }
}
