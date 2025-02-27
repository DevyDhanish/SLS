using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rank
{
    public string rankTitle {get; private set;}
    public int rankThreshold {get; private set;}

    public Rank(string title, int threshold)
    {
        rankTitle = title;
        rankThreshold = threshold;
    }

    public static Rank getRank(int score)
    {
        List<Rank> allRanks = getAllRanks();
        
        // Find the highest rank the player qualifies for
        return allRanks.LastOrDefault(r => score >= r.rankThreshold) ?? allRanks.ElementAt(0); // Default to "Un-Ranked"
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
}
