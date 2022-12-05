public class Health
{
    public int Value { get; private set; }
    public int MinValue { get; private set; }
    public int MaxValue { get; private set; }

    public Health(int value, int minValue, int maxValue)
    {
        Value = value;
        MinValue = minValue;
        MaxValue = maxValue;
    }

    public void IncreaseValue(int increase)
    {
        if (Value + increase <= MaxValue)
            Value += increase;
        else
            Value = MaxValue;
    }

    public void DecreaseValue(int decrease)
    {
        if (Value - decrease >= MinValue)
            Value -= decrease;
        else
            Value = MinValue;
    }
}
