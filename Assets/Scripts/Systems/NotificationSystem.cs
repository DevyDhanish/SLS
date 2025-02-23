using UnityEngine;

public class NotificationSystem : Systems
{
    public static NotificationSystem instance;
    public GameObject NotificationUIController;
    private NotificationUI notificationUI;

    public override void Init()
    {
        if(instance == null && instance != this)
        {
            Destroy(gameObject);
        }

        instance = this;
        notificationUI = NotificationUIController.GetComponent<NotificationUI>(); 
    }

    void Start()
    {
        
    }

    public enum NotiType{
        NOTI_OK,
        NOTI_YESNO,
    }

    public class NotificationObj
    {
        public string _title;
        public string _description;

        public NotiType _type;

        public delegate void _callback();

        public _callback okCallBack;
        public _callback yesCallBack;
        public _callback noCallBack;

        public delegate void _defaultCallBack(GameObject g);
        public _defaultCallBack defaultCallback;
    }

    // default call backs
    private void defaultCloseCallBack(GameObject g)
    {
        notificationUI.removeNotification(g);
    }

    // create a notification obj
    public NotificationObj createNotification_typeOK(string title, string description, NotificationObj._callback okCallBack)
    {
        var n = new NotificationObj
        {
            _title = title,
            _description = description,
            okCallBack = okCallBack,
            _type = NotiType.NOTI_OK,
            defaultCallback = defaultCloseCallBack
        };

        return n;
    }

    public void showNotification(NotificationObj obj)
    {
        notificationUI.showNotification(obj);
    }
}
