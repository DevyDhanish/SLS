using UnityEngine;

public class NotificationUI : MonoBehaviour, Controllers
{
    public GameObject OK_NOTI_PREFAB;
    public GameObject PROMPT_NOTI_PREFAB;

    public void InitController()
    {
        // don't got anything to do
    }

    private GameObject showOkNotification(NotificationSystem.NotificationObj notiObj)
    {
        GameObject i_notObj = Instantiate(OK_NOTI_PREFAB);

        i_notObj.GetComponent<OKNotiBuilder>().setTitle(notiObj._title);
        i_notObj.GetComponent<OKNotiBuilder>().setDescription(notiObj._description);

        i_notObj.GetComponent<OKNotiBuilder>().setOkCallBack((GameObject g) => notiObj.okCallBack(g));
        i_notObj.GetComponent<OKNotiBuilder>().setOkCallBack((GameObject g) => notiObj.defaultCallback(g));


        i_notObj.transform.SetParent(gameObject.transform);

        return i_notObj;
    }

    private GameObject showPromptNotification(NotificationSystem.NotificationObj notiObj)
    {
        GameObject p_notObj = Instantiate(PROMPT_NOTI_PREFAB);

        p_notObj.GetComponent<PromptNotiBuilder>().setTitle(notiObj._title);
        p_notObj.GetComponent<PromptNotiBuilder>().setDescription(notiObj._description);

        p_notObj.GetComponent<PromptNotiBuilder>().setOkCallBack((GameObject g) => notiObj.okCallBack(g));
        p_notObj.GetComponent<PromptNotiBuilder>().setOkCallBack((GameObject g) => notiObj.defaultCallback(g));

        p_notObj.transform.SetParent(gameObject.transform);

        return p_notObj;
    }
    
    public GameObject showNotification(NotificationSystem.NotificationObj notiObj)
    {
        if(notiObj._type == NotificationSystem.NotiType.NOTI_OK)
        {
            return showOkNotification(notiObj);
        }

        if(notiObj._type == NotificationSystem.NotiType.NOTI_PROMPT)
        {
            return showPromptNotification(notiObj);
        }

        return null;
    }

    public void removeNotification(GameObject o)
    {
        Destroy(o);
    }
}
