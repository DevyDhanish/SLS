using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rank : SavableObject<Rank.RankSavableObject>
{
    public string RankTitle {get; private set;}
    public int RankThreshold {get; private set;}

    public Rank(string title, int threshold)
    {
        RankTitle = title;
        RankThreshold = threshold;
    }

    [Serializable]
    public class RankSavableObject
    {
        public string rankTitle;
        public int rankThreshold;
    }

    public static Rank getRank(int score)
    {
        List<Rank> allRanks = getAllRanks();
        
        // Find the highest rank the player qualifies for
        return allRanks.LastOrDefault(r => score >= r.RankThreshold) ?? allRanks.ElementAt(0); // Default to "Un-Ranked"
    }

    public static List<Rank> getAllRanks()
    {
        return new List<Rank>
        {
            new Rank(
                "Un-Ranked",
                0
            ),
            new Rank(
                "F-Rank",
                100
            ),
            new Rank(
                "E-Rank",
                200
            ),
            new Rank(
                "D-Rank",
                300
            ),
        };
    }

    public RankSavableObject getSavableObject()
    {
        RankSavableObject r = new RankSavableObject();

        r.rankThreshold = RankThreshold;
        r.rankTitle = RankTitle;

        return r;
    }
}
