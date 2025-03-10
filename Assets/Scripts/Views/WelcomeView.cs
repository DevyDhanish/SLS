using UnityEngine;

public class WelcomeView : MonoBehaviour, View
{
    public void onClickEnter()
    {
        NotificationSystem.instance.showNotification(
            NotificationSystem.instance.createNotification_typePROMPT(
                "What should I call you",
                "*Player name cannot be more than 7 letters",
                (GameObject g) => {
                    string playerName = g.GetComponent<PromptNotiBuilder>().getTextFromInputField();
                    
                    if(playerName.Length < 7 && !int.TryParse(playerName, out _))
                    {
                        PlayerSystem.instance.createNewPlayer(playerName);
                        UISystem.instance.changeUIbyName("Home");

                        return;
                    }

                    if(int.TryParse(playerName, out _))
                    {
                        NotificationSystem.instance.showNotification(
                        NotificationSystem.instance.createNotification_typeOK(
                            "Error",
                            "Your name cannot be a number man, you a slave or sum ?",
                            (GameObject g) => { return; }
                        )
                        );
                        return;
                    }

                    NotificationSystem.instance.showNotification(
                        NotificationSystem.instance.createNotification_typeOK(
                            "Error",
                            "Player name length cannot be more than 7 letters",
                            (GameObject g) => { return; }
                        )
                    );
                }
            )
        );
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
