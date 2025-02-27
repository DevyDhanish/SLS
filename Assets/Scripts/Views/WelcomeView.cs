using UnityEngine;

public class WelcomeView : MonoBehaviour, View
{
    public void onClickEnter()
    {
        NotificationSystem.instance.showNotification(
            NotificationSystem.instance.createNotification_typePROMPT(
                "What should I call you",
                "Enter you name",
                (GameObject g) => {
                    string playerName = g.GetComponent<PromptNotiBuilder>().getTextFromInputField();
                    PlayerSystem.instance.createNewPlayer(playerName);
                }
            )
        );

        UISystem.instance.changeUIbyName("Home");
    }

    public void Disable()
    {
        //throw new System.NotImplementedException();
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        //throw new System.NotImplementedException();
        gameObject.SetActive(true);
    }
}
