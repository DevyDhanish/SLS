using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Rank
{
    public string rank; // a,b,c,d,e yk 
    public int maxscore;
    public int minscore; // the amount of pts required to attain this rank (avg of all the stats)
}
