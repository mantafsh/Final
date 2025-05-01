using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    //base stat
    //public int professionalism = 2;
    //public int charisma = 3;

    public Dictionary<string, int> stats = new Dictionary<string, int>();
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //base stats
        stats["professionalism"] = 2;
        
    }

    public int GetStat(string statName)
    {
        if (stats.ContainsKey(statName))
        {
            return stats[statName];
        }

        return 0;

    }

    public void IncreaseStat(string _statName, int amount)
    {
        //if the stat key does  note xist then create it and set to 0
        if (!stats.ContainsKey(_statName))
        {
            stats[_statName] = 0;
        }

        stats[_statName] += amount;

        Debug.Log($"Increased {_statName} by {amount}. New Value {stats[_statName]}");
    }
}
