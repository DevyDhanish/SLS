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

    public static Rank getNextRank(Rank currentRank)
    {
        List<Rank> allRanks = getAllRanks();

        // Find the index of the current rank
        int currentIndex = allRanks.FindIndex(0, allRanks.Count, (Rank r) => {
            if(r.RankThreshold == currentRank.RankThreshold && r.RankTitle == currentRank.RankTitle) return true;
            else return false;
        });

        // If rank is found and there's a next rank, return it. Otherwise, return the current rank.
        if((currentIndex + 1) >= allRanks.Count) return currentRank;

        return allRanks[currentIndex + 1];
    }

    public static List<Rank> getAllRanks()
    {
        return new List<Rank>
        {
            new Rank("NR", 0),
            new Rank("F", 100),
            new Rank("E", 200),
            new Rank("D", 300),
            new Rank("C", 400),
            new Rank("B", 500),
            new Rank("A", 600),
            new Rank("S", 700),
            new Rank("SS", 800),
            new Rank("SSS", 900)
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
