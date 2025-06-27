using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ChangedCurrentTime += ShowCounter;
    }

    private void OnDisable()
    {
        _counter.ChangedCurrentTime -= ShowCounter;
    }

    private void ShowCounter(float count)
    {
        Debug.Log($"Текущее время: {count}");
    }
}
