using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
// Crei la classe Hero Serializabile per poterla vedere in inspector
public class Hero
{
    [SerializeField] private string _PgName;
    [SerializeField] private int _hp;
    [SerializeField] private Stats _baseStats;
    [SerializeField] private ELEMENT _resistance;
    [SerializeField] private ELEMENT _weakness;
    [SerializeField] private Weapon _weapon;

    // Creo il costruttore per assegnare tutti i valori
    public Hero(string name, int hp, Stats baseStats, ELEMENT resistance, ELEMENT weakness, Weapon weapon)
    {
        this._PgName = name;
        this._hp = hp;
        this._baseStats = baseStats;
        this._resistance = resistance;
        this._weakness = weakness;
        this._weapon = weapon;
    }
    public string Name
    { get => _PgName; private set => _PgName = value; }

    public int Hp
    { get => _hp; set => _hp = value; }

    public Stats BaseStats
    { get => _baseStats; set => _baseStats = value; }

    public ELEMENT Resistance
    { get => _resistance; set => _resistance = value; }

    public ELEMENT Weakness
    { get => _weakness; set => _weakness = value; }


    public Weapon Weapon
    { get => _weapon; set => _weapon = value; }

    // Dichiaro il valori di Hp con SetHp()
    public void AddHp(int amount)
    { SetHp(Hp + amount); }
    // Nuovo valore di Hp
    private void SetHp(int value) { _hp = value; }

    // Sottraggo il valore di damege al valore di AddHp
    public void TakeDamage(int damage) { AddHp(-damage); }

    // Determinare se Hero IsAlive e True o False
    public bool IsAlive() { return _hp > 0; }

}

public class MyHero
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}