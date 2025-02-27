// using System;
// using System.Collections.Generic;
// using UnityEngine;

// public class RankSystem : Systems
// {
//     public static RankSystem instance;

//     private List<Rank> ranks = new List<Rank>();

//     public override void Init(){

//         if(instance != this && instance != null)
//         {
//             Destroy(gameObject);
//             return;
//         }

//         instance = this;


//             Rank[] allRanks = {
//                 new Rank{
//                     rank = "SSS",
//                     maxscore = 9999999,
//                     minscore = 800
//                 },
//                 new Rank{
//                     rank = "SS",
//                     maxscore = 800,
//                     minscore = 700
//                 },
//                 new Rank{
//                     rank = "S",
//                     maxscore = 700,
//                     minscore = 600
//                 },
//                 new Rank{
//                     rank = "A",
//                     maxscore = 600,
//                     minscore = 500
//                 },
//                 new Rank{
//                     rank = "B",
//                     maxscore = 500,
//                     minscore = 400
//                 },
//                 new Rank{
//                     rank = "C",
//                     maxscore = 400,
//                     minscore = 300
//                 },
//                 new Rank{
//                     rank = "D",
//                     maxscore = 300,
//                     minscore = 200
//                 },
//                 new Rank{
//                     rank = "E",
//                     maxscore = 200,
//                     minscore = 100
//                 },
//                 new Rank{
//                     rank = "F",
//                     maxscore = 100,
//                     minscore = 0
//                 }
//             };

//         instance.ranks.AddRange(allRanks);

//         EventSystem.instance.OnUpdatePlayerRank += instance.updateRanks;
//     }

//     private Rank getValidRank(int score)
//     {
//         foreach(Rank r in ranks)
//         {
//             if(score > r.minscore && score <= r.maxscore)
//             {
//                 return r;
//             }
//         }

//         return null;
//     }

//     // this can be used to assign ranks as well
//     public void updateRanks(Player player)
//     {
//         Rank validRank = getValidRank(player.Score);

//         if(player.Rank != validRank){
//             //EventSystem.instance.FirePlayerRankedUpEvent(Player.instance, validRank);
//         }
//     }
// }
