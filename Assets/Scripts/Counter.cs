public class Counter
{
    private float _count;

    public float Count => _count;

    public void Increase(float _valueForIncreaseSeconds)
    {
        _count += _valueForIncreaseSeconds;
    }
}
