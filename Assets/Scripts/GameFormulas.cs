using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

// Creo la classe statica GameFormulas
// Da integrare resistenze e debolezze 
// Calcolo del danno critico e Hit
// OCCHIO ai TYPO!!!!
public static class GameFormulas
{
    // Da aggiungere il combattimento a mani nude..
    // Era meglio pensarci prima.. 😅​
    // 
    public static bool HasElementAdvantage(ELEMENT attackElement, Hero defender)
    // Se attackElement è true -> defender avrà una debolezza
    {
        if (defender == null) return false;
        else if (attackElement == defender.Weakness) return true;
        else return false;
    }
    // Se attackElement è true -> defender avrà una resistenza
    public static bool HasElementDisadvantage(ELEMENT attackElement, Hero defender)
    {
        if (defender == null) return false;
        else if (attackElement == defender.Resistance) return true;
        else return false;
    }
    // Definisco la logica per gestire resistenze e debolezze
    // x1.5 se ha vantaggio(debolezza), x0.5 se ha svantaggio(resistenza), x1 se normal
    // Da prevedere i numeri con la virgola!!
    public static float EvaluateElementalModifier(ELEMENT attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender)) { return 1.5f; }
        else if (HasElementDisadvantage(attackElement, defender)) { return 0.5f; }
        else { return 1f; }
    }
    // Creo la funzione che determina se è Hit o Miss
    // Calcolo la % di colpire rapportando aim a eva
    public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = Mathf.Clamp(attacker.aim - defender.eva, 5, 95);
        int roll = Random.Range(0, 100);
        if (roll >= hitChance)
        {
            Debug.Log("MISS");
            return false;
        }
        else
        {
            Debug.Log("HIT");
        }
return true;
    }
    public static bool IsCrit(int critValue)
    {
        int roll = Random.Range(0, 100);
        if (roll < critValue)
        {
            Debug.Log("CRIT");
            return true;
        }
        return false;
    }
    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        if (attacker == null || defender == null) return 0;
        Weapon atkWeapon = attacker.Weapon;
        Stats atkStats = attacker.BaseStats;
        Stats defStats = defender.BaseStats;

        // Somma delle statistiche base e dei bonus arma
        Stats atkBonus = atkWeapon != null ? atkWeapon.StatsBonus : new Stats();
        Stats defBonus = defender.Weapon != null ? defender.Weapon.StatsBonus : new Stats();

        atkStats = Stats.Sum(atkStats, atkBonus);
        defStats = Stats.Sum(defStats, defBonus);

        // Se l'arma è magica, difesa = res, altrimenti def
        int defenceSelected;
        if (atkWeapon != null && atkWeapon.dmgType == Weapon.DAMAGE_TYPE.MAGICAL)
        {
            defenceSelected = defStats.res;
        }
        else
            defenceSelected = defStats.def;

        // Calcolo danno base
        int damage = atkStats.atk - defenceSelected;

        // Applico modificatore elementale
        ELEMENT atkElem = atkWeapon != null ? atkWeapon.ElementalDmg : ELEMENT.NONE;
        damage = Mathf.RoundToInt(damage * EvaluateElementalModifier(atkElem, defender));

        // Controllo critico
        if (IsCrit(atkStats.crt))
            damage *= 2;

        // Restituisco almeno 0
        return Mathf.Max(0, damage);
    }
}