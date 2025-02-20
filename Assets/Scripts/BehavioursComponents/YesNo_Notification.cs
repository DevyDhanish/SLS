using UnityEngine;
using TMPro;

public class YesNo_Notification : MonoBehaviour, Notification
{
    [SerializeField] private TextMeshProUGUI msgBox;

    public void conceal()
    {
        gameObject.SetActive(false);
    }

    public void display(string msg)
    {
        msgBox.SetText(msg);
        gameObject.SetActive(true);
    }

    public NotificationTypes.N_Types getType()
    {
        return NotificationTypes.N_Types.N_YESNO;
    }

    public void onClickYes(){
        conceal();
    }

    public void onClickNo(){
        conceal();
    }
}
