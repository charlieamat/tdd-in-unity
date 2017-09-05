using System;

public class Player
{
    public int CurrentHealth { get; private set; }
    public int MaxiumumHealth { get; private set; }

    public Player(int currentHealth, int maximumHealth = 12)
    {
        if (currentHealth < 0) throw new ArgumentOutOfRangeException("currentHealth");
        if (currentHealth > maximumHealth) throw new ArgumentOutOfRangeException("currentHealth");
        CurrentHealth = currentHealth;
        MaxiumumHealth = maximumHealth;
    }

    public void Heal(int amount)
    {
        CurrentHealth = Math.Min(CurrentHealth + amount, MaxiumumHealth);
    }

    public void Damage(int amount)
    {
        CurrentHealth = Math.Max(CurrentHealth - amount, 0);
    }
}