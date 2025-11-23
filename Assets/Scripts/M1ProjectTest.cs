using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class M1ProjectTest : MonoBehaviour
{
    public Hero a; // assegnato dall'Inspector
    public Hero b; // assegnato dall'Inspector

    void Update()
    {
        // Se uno dei due è eliminato, non fare nulla
        if (a == null || b == null || !a.IsAlive() || !b.IsAlive())
            return;

        // Determina chi attacca per primo in base alla velocità (spd base + arma)
        Hero first, second;
        if (GetTotalSpeed(a) >= GetTotalSpeed(b))
        {
            first = a;
            second = b;
        }
        else
        {
            first = b;
            second = a;
        }

        // Primo attacco
        if (PerformAttack(first, second))
        {
            // Se il secondo non è sopravvissuto, esci
            return;
        }

        // Secondo attacco (solo se è ancora vivo)
        PerformAttack(second, first);
    }

    // Calcola la velocità totale di un eroe (base + arma)
    private int GetTotalSpeed(Hero hero)
    {
        int weaponSpeed = hero.Weapon != null ? hero.Weapon.StatsBonus.spd : 0;
        return hero.BaseStats.spd + weaponSpeed;
    }

    // Gestisce un singolo attacco, restituisce true se il difensore è stato eliminato
    private bool PerformAttack(Hero attacker, Hero defender)
    {
        Debug.Log($"{attacker.Name} attacca {defender.Name}");

        if (!GameFormulas.HasHit(attacker.BaseStats, defender.BaseStats))
            return false; // attacco fallito

        // Controllo resistenza/debolezza
        ELEMENT atkElem = attacker.Weapon != null ? attacker.Weapon.ElementalDmg : ELEMENT.NONE;
        if (GameFormulas.HasElementAdvantage(atkElem, defender))
            Debug.Log("WEAKNESS");
        else if (GameFormulas.HasElementDisadvantage(atkElem, defender))
            Debug.Log("RESIST");

        // Calcola danno
        int damage = GameFormulas.CalculateDamage(attacker, defender);
        Debug.Log($"Danno inflitto: {damage}");

        // Infligge danno
        defender.TakeDamage(damage);

        // Controlla se il difensore è morto
        if (!defender.IsAlive())
        {
            Debug.Log($"{attacker.Name} ha vinto!");
            return true;
        }

        return false;
    }
}
