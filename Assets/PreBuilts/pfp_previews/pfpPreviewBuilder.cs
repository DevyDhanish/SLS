using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class pfpPreviewBuilder : MonoBehaviour
{
    public TextMeshProUGUI title;
    public GameObject fgImage;

    public void setTitle(string Title)
    {
        title.SetText(Title);   
    }

    public void setImage(Sprite image)
    {
        fgImage.GetComponent<Image>().sprite = image;
    }
}