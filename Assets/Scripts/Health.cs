using UnityEngine;

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

    public void Heal(int healValue)
    {
        Value = Mathf.Clamp(Value + healValue, MinValue, MaxValue);
    }

    public void Damage(int damageValue)
    {
        Value = Mathf.Clamp(Value - damageValue, MinValue, MaxValue);
    }
}
