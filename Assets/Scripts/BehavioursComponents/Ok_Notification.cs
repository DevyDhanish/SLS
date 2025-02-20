using TMPro;
using UnityEngine;

public class Ok_Notification : MonoBehaviour, Notification
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

    public NotificationTypes.N_Types getType(){
        return NotificationTypes.N_Types.N_OK;
    }

    public void OnOkClick(){
        conceal();
    }
}
