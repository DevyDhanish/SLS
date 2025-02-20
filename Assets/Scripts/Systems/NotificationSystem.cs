using System.Collections.Generic;
using UnityEngine;

public class NotificationSystem : Systems
{
    // private NotificationSystem() {}

    public static NotificationSystem instance;

    [SerializeField] private List<GameObject> AllNotificationTypes;

    // public static void Init(){
    //     if(instance == null)
    //     {
    //         instance = new NotificationSystem();
    //     }
    // }

    public override void Init(){

        if (instance != this && instance != null) Destroy(gameObject);

        instance = this;

        foreach(GameObject n in AllNotificationTypes)
        {
            Notification noti = n.GetComponent<Notification>();
            noti.conceal();
        }
    }

    public void createNotification(NotificationTypes.N_Types type, string msg){

        foreach(GameObject n in AllNotificationTypes)
        {
            Notification noti = n.GetComponent<Notification>();

            if(noti.getType() == type)
            {
                noti.display(msg);
                return;
            }
        }

    }
}
