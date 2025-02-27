using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PromptNotiBuilder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private GameObject textInput;
    [SerializeField] private GameObject OkButton;

    public void setTitle(string Title)
    {
        title.SetText(Title);   
    }

    public void setDescription(string  d)
    {
        description.SetText(d);
    }

    public string getTextFromInputField()
    {
        return textInput.GetComponent<TMP_InputField>().text;
    }

    public void setOkCallBack(NotificationSystem.NotificationObj._callback callback)
    {
        OkButton.GetComponent<Button>().onClick.AddListener(() => callback(this.gameObject));
    }
}
