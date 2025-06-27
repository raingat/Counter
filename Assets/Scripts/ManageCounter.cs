using System.Collections;
using UnityEngine;

public class ManageCounter : MonoBehaviour
{
    [SerializeField] private float _waitSeconds = 0.5f;
    [SerializeField] private float _valueForIncreaseSeconds = 1;

    private bool _isWork = false;

    private Counter _counter = new Counter();
    private CounterView _counterView = new CounterView();

    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isWork)
            {
                SuspendTimer();
            }
            else
            {
                ResumeTimer();
            }
        }
    }

    private void SuspendTimer()
    {
        Debug.Log("Счетчик приостановлен.");

        _isWork = false;
        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private void ResumeTimer()
    {
        Debug.Log("Счетчик запустился.");

        _isWork = true;
        _coroutine = StartCoroutine(IncreaseSeconds());
    }

    private IEnumerator IncreaseSeconds()
    {
        WaitForSeconds wait = new WaitForSeconds(_waitSeconds);

        while (true)
        {
            _counter.Increase(_valueForIncreaseSeconds);

            _counterView.ShowCounter(_counter.Count);

            yield return wait;
        }
    }
}
