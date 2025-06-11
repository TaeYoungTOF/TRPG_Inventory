using UnityEngine;

public interface IDamagable
{
    float Atk { get; set; }

    float Def { get; set; }

    float Hp { get; set; }

    float Crit { get; set; }

    void TakeDamage(int damage);

    int CalculateDamage(IDamagable target);

    bool IsCriticalHit();
}
