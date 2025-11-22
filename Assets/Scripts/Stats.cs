using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Statistiche : MonoBehaviour
{
    public Statistiche()
    {
    }

}
//
// Dichiaro la struct per le statistiche
//
public struct Stats 
{
    //
    // Dichiaro le variabiabili pubbliche delle statistiche
    //

    public int atk;
    public int def;
    public int res;
    public int spd;
    public int crt;
    public int aim;
    public int eva;

    //
    // Creo un costruttore che assegna i valori alle variabili
    // 

    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
    {
        this.atk = atk;
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = aim;
        this.eva = eva;
    }
    //
    // Creo la funzione statica Sum 
    // Sommo il valore di Stats a al valore di Stats b
    // 
    public static Stats Sum(Stats a, Stats b)
    {
        return new Stats
       (
        a.atk + b.atk,
        a.def + b.def,
        a.res + b.res,
        a.spd + b.spd,
        a.crt + b.crt,
        a.aim + b.aim,
        a.eva + b.eva
       );
    }
}