using System;
using System.Collections.Generic;

namespace EarthDefendGame
{
    public interface IMovable
    {
        void Move();
    }

    public interface ICurable
    {
        float MaxHealth { get; }
        float CurrentHealth { get; }
        void RestoreHealth(float amount);
    }

    public interface IDamageable
    {
        void TakeDamage(float damage);
        event Action DeathEvent;
    }
    
    public interface IShooting
    {
        void Shoot();
    }
    
    public interface IText
    {
        Queue<string> Phrases { get; }
        event Action PhrasesEndedEvent;
        string TryGetNextPhrase();
    }
}
