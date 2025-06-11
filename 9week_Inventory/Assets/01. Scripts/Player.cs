using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    [Header("Player Info")]
    [SerializeField] private string playerName;
    public string PlayerName
    {
        get => playerName;
        set => playerName = value;
    }
    [SerializeField] private int playerLevel;
    public int PlayerLevel
    {
        get => playerLevel;
        set => playerLevel = value;
    }
    [SerializeField] private string playerDescription;
    public string PlayerDescription
    {
        get => playerDescription;
        set => playerDescription = value;
    }
    [SerializeField] private int playerGold;
    public int PlayerGold
    {
        get => playerGold;
        set => playerGold = value;
    }

    [Header("Player Stats")]
    [SerializeField] private float atk;
    public float Atk
    {
        get => atk;
        set => atk = value;
    }
    [SerializeField] private float def;
    public float Def
    {
        get => def;
        set => def = value;
    }
    [SerializeField] private float hp;
    public float Hp
    {
        get => hp;
        set => hp = value;
    }
    [SerializeField] private float crit;
    public float Crit
    {
        get => crit;
        set => crit = value;
    }

    private void Awake()
    {
        GameManager.Instance.player = this;
    }

    public void TakeDamage(int damage)
    {
        return;
    }

    public int CalculateDamage(IDamagable target)
    {
        float rawDamage = Mathf.Max(0, Atk - target.Def);
        if (IsCriticalHit())
        {
            rawDamage *= 1.5f;
        }
        return (int)rawDamage;
    }

    public bool IsCriticalHit()
    {
        return Random.value < Crit;
    }

    public void Equip(ItemData item)
    {
        atk += item.atkValue;
        def += item.defValue;
        hp += item.hpValue;
        crit += item.critValue;
    }

    public void UnEquip(ItemData item)
    {
        atk -= item.atkValue;
        def -= item.defValue;
        hp -= item.hpValue;
        crit -= item.critValue;
    }
}
