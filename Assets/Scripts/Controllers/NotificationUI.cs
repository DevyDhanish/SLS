using UnityEngine;

public class NotificationUI : MonoBehaviour
{
    public GameObject OK_NOTI_PREFAB;

    public GameObject showNotification(NotificationSystem.NotificationObj notiObj)
    {
        GameObject i_notObj = Instantiate(OK_NOTI_PREFAB);

        i_notObj.GetComponent<OKNotiBuilder>().setDescription(notiObj._description);

        i_notObj.GetComponent<OKNotiBuilder>().setOkCallBack(notiObj.okCallBack);
        i_notObj.GetComponent<OKNotiBuilder>().setOkCallBack(() => notiObj.defaultCallback(i_notObj.gameObject));

        i_notObj.GetComponent<OKNotiBuilder>().setTitle(notiObj._title);

        i_notObj.transform.SetParent(gameObject.transform);

        return i_notObj;
    }

    public void removeNotification(GameObject o)
    {
        Destroy(o);
    }
}
