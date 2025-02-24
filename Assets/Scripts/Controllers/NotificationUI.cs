using UnityEngine;

public class NotificationUI : MonoBehaviour, Controllers
{
    public GameObject OK_NOTI_PREFAB;

    public void InitController()
    {
        // don't got anything to do
    }

    public GameObject showNotification(NotificationSystem.NotificationObj notiObj)
    {
        GameObject i_notObj = Instantiate(OK_NOTI_PREFAB);

        i_notObj.GetComponent<OKNotiBuilder>().setDescription(notiObj._description);

        i_notObj.GetComponent<OKNotiBuilder>().setOkCallBack((GameObject g) => notiObj.okCallBack(g));
        i_notObj.GetComponent<OKNotiBuilder>().setOkCallBack((GameObject g) => notiObj.defaultCallback(g));

        i_notObj.GetComponent<OKNotiBuilder>().setTitle(notiObj._title);

        i_notObj.transform.SetParent(gameObject.transform);

        return i_notObj;
    }

    public void removeNotification(GameObject o)
    {
        Destroy(o);
    }
}
