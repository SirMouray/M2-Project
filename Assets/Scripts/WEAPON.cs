using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]

//
// Creo la classe Weapon
//

public class Weapon
{
    //
    // Creo un enum con i valori PHYSICAL e MAGICAL
    //
    public enum DAMAGE_TYPE
    {
        PHYSICAL,
        MAGICAL
    }

    //
    // Creo le variabili private string, Damage_TYPE, ELEMENT, Stats
    //
    [SerializeField] private string weaponName;
    [SerializeField] private DAMAGE_TYPE damageType;
    [SerializeField] private ELEMENT elementalDmg;
    [SerializeField] private Stats statsBonus;

    // Creo un costruttore che assegni i valori
    public Weapon(string weaponName, DAMAGE_TYPE damageType, ELEMENT elementalDmg, Stats statsBonus)
    {
        this.weaponName = weaponName;
        this.damageType = damageType;
        this.elementalDmg = elementalDmg;
        this.statsBonus = statsBonus;
    }
    public string WeaponName
    {
        get => weaponName;
        set => weaponName = value;
    }

    public DAMAGE_TYPE dmgType
    {
        get => damageType;
        set => damageType = value;
    }

    public ELEMENT ElementalDmg
    {
        get => elementalDmg;
        set => elementalDmg = value;
    }

    public Stats StatsBonus
    {
        get => statsBonus;
        set => statsBonus = value;
    }
}
public class WEAPON : MonoBehaviour
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