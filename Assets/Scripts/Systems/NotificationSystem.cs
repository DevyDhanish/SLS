using UnityEngine;

public class NotificationSystem : Systems
{
    public NotificationSystem instance;

    public override void Init()
    {
        if(instance == null && instance != this)
        {
            Destroy(gameObject);
        }
    }
}
