using System;
using UnityEngine;

public class Stats : SavableObject<Stats.StatsSavableObject>
{
    public enum StatsType
    {
        STATS_STAMINA,
        STATS_STRENGTH,
    }

    public int Strength {get; private set;}
    public int Stamina {get; private set;}
    public int Score {get; private set;}

    public Stats(int strenght, int stamina, int score)
    {
        Strength = strenght;
        Stamina = stamina;
        Score = score;
    }


    [Serializable]
    public class StatsSavableObject
    {
        public int strength;
        public int stamina;
        public int score;
    }

    public static void updateStats(Stats instance, StatsType type, int value)
    {
        switch(type)
        {
            case StatsType.STATS_STAMINA:
                instance.increaseStamina(value);
                break;
            case StatsType.STATS_STRENGTH:
                instance.increaseStrength(value);
                break;
            default:
                break;
        }

        instance.Score = (instance.Stamina + instance.Strength) / 2;
    }

    private void increaseStrength(int value){
        Strength += value;
    }

    private void increaseStamina(int value){
        Stamina += value;
    }

    public StatsSavableObject getSavableObject()
    {
        StatsSavableObject s = new StatsSavableObject();

        s.score = Score;
        s.stamina = Stamina;
        s.strength = Strength;

        return s;
    }
}
