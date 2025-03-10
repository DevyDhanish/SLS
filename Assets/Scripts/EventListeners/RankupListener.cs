using System;
using UnityEngine;

public class RankupListener : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventSystem.instance.OnPlayerRankUp += playerRankedUp;
    }


    void playerRankedUp(Player p, Rank r)
    {
        NotificationSystem.instance.showNotification(
            NotificationSystem.instance.createNotification_typeOK(
                "RANK UP!",
                String.Format("{0} has ascended to {1} Rank", p.Name, r.RankTitle),
                (GameObject g) => {
                    // do anything you want when player clicks ok
                    return;
                }
            )
        );
    }
}
