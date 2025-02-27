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
                "Congratulations",
                String.Format("{0} has ranked up to {1}", p.Name, r.rankTitle),
                (GameObject g) => {
                    // do anything you want when player clicks ok
                    Debug.Log(p.Name);
                }
            )
        );
    }
}
