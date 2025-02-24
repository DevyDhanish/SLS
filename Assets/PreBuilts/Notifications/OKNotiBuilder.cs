using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OKNotiBuilder : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public GameObject Button;

    public void setTitle(string Title)
    {
        title.SetText(Title);   
    }

    public void setDescription(string  d)
    {
        description.SetText(d);
    }

    public void setOkCallBack(NotificationSystem.NotificationObj._callback callback)
    {
        Button.GetComponent<Button>().onClick.AddListener(() => callback(this.gameObject));
    }
}
