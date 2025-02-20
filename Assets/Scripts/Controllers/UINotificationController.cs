using System;
using UnityEngine;

public class UINotificationController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EventSystem.instance.OnPlayerRankUp += playerRankedUpNotification;
    }

    private void playerRankedUpNotification(Player player, Rank rank){
        NotificationSystem.instance.createNotification(
            NotificationTypes.N_Types.N_OK,
            String.Format("You have attained a new rank {0}", rank.rank)
        );
    }
}
