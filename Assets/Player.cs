using System;

public class Player
{
    public int CurrentHealth { get; private set; }
    public int MaxiumumHealth { get; private set; }

    public event EventHandler<HealedEventArgs> Healed;
    public event EventHandler<DamagedEventArgs> Damaged;

    public Player(int currentHealth, int maximumHealth = 12)
    {
        if (currentHealth < 0) throw new ArgumentOutOfRangeException("currentHealth");
        if (currentHealth > maximumHealth) throw new ArgumentOutOfRangeException("currentHealth");
        CurrentHealth = currentHealth;
        MaxiumumHealth = maximumHealth;
    }

    public void Heal(int amount)
    {
        var newHealth = Math.Min(CurrentHealth + amount, MaxiumumHealth);
        if (Healed != null)
            Healed(this, new HealedEventArgs(newHealth - CurrentHealth));
        CurrentHealth = newHealth;
    }

    public void Damage(int amount)
    {
        var newHealth = Math.Max(CurrentHealth - amount, 0);
        if (Damaged != null)
            Damaged(this, new DamagedEventArgs(CurrentHealth - newHealth));
        CurrentHealth = newHealth;
    }

    public class HealedEventArgs : EventArgs
    {
        public HealedEventArgs(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; private set; }
    }

    public class DamagedEventArgs : EventArgs
    {
        public DamagedEventArgs(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; private set; }
    }
}