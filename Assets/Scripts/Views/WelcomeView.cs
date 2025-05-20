using UnityEngine;

public class WelcomeView : MonoBehaviour, View
{

    public void askGender()
    {
        NotificationSystem.instance.showNotification(
        NotificationSystem.instance.createNotification_typePROMPT(
            "What is your Gender?",
            "Male : M, Female : F",
            (GameObject g) =>
            {
                //string playerAge = g.GetComponent<PromptNotiBuilder>().getTextFromInputField();

                //int ageInInt;
                //if (!int.TryParse(playerAge, out ageInInt))
                //{
                //    NotificationSystem.instance.showNotification(
                //        NotificationSystem.instance.createNotification_typeOK(
                //            "Error",
                //            "Enter a number not words",
                //            (GameObject g) => { return; }
                //        )
                //    );
                //    return;
                //}
            }
            )
        );
    }
    public void askAge()
    {
        NotificationSystem.instance.showNotification(
            NotificationSystem.instance.createNotification_typePROMPT(
                "What is your age?",
                "",
                (GameObject g) => {
                    string playerAge = g.GetComponent<PromptNotiBuilder>().getTextFromInputField();

                    int ageInInt;
                    if (!int.TryParse(playerAge, out ageInInt))
                    {
                        NotificationSystem.instance.showNotification(
                            NotificationSystem.instance.createNotification_typeOK(
                                "Error",
                                "Enter a number not words",
                                (GameObject g) => { return; }
                            )
                        );
                        return;
                    }

                    if (ageInInt <= 0)
                    {
                        NotificationSystem.instance.showNotification(
                            NotificationSystem.instance.createNotification_typeOK(
                                "Error",
                                "Bruh you 0 years old?",
                                (GameObject g) => { return; }
                            )
                        );
                        return;
                    }

                    PlayerSystem.instance.currentPlayer.setAge(ageInInt);
                }
            )
        );
    }

    public void askHeight()
    {
        NotificationSystem.instance.showNotification(
            NotificationSystem.instance.createNotification_typePROMPT(
                "What is your Height (cm)?",
                "",
                (GameObject g) => {
                    string playerAge = g.GetComponent<PromptNotiBuilder>().getTextFromInputField();

                    int ageInInt;
                    if(!int.TryParse(playerAge, out ageInInt))
                    {
                        NotificationSystem.instance.showNotification(
                            NotificationSystem.instance.createNotification_typeOK(
                                "Error",
                                "Enter a number not words",
                                (GameObject g) => { return; }
                            )
                        );

                        if(ageInInt <= 0)
                        {
                            NotificationSystem.instance.showNotification(
                                NotificationSystem.instance.createNotification_typeOK(
                                    "Error",
                                    "Cmon man",
                                    (GameObject g) => { return; }
                                )
                            );
                        }

                        PlayerSystem.instance.currentPlayer.setHeight(ageInInt);
                    }
                }
            )
        );
    }

    public void askWeight()
    {
        NotificationSystem.instance.showNotification(
            NotificationSystem.instance.createNotification_typePROMPT(
                "What is your weight?",
                "",
                (GameObject g) => {
                    string playerAge = g.GetComponent<PromptNotiBuilder>().getTextFromInputField();

                    int ageInInt;
                    if(!int.TryParse(playerAge, out ageInInt))
                    {
                        NotificationSystem.instance.showNotification(
                            NotificationSystem.instance.createNotification_typeOK(
                                "Error",
                                "Enter a number not words",
                                (GameObject g) => { return; }
                            )
                        );

                        if(ageInInt <= 0)
                        {
                            NotificationSystem.instance.showNotification(
                                NotificationSystem.instance.createNotification_typeOK(
                                    "Error",
                                    "bruh",
                                    (GameObject g) => { return; }
                                )
                            );
                        }

                        PlayerSystem.instance.currentPlayer.setWeight(ageInInt);
                    }
                }
            )
        );
    }

    public void onClickEnter()
    {
        NotificationSystem.instance.showNotification(
            NotificationSystem.instance.createNotification_typePROMPT(
                "What should I call you",
                "*Player name cannot be more than 7 letters",
                (GameObject g) => {
                    string playerName = g.GetComponent<PromptNotiBuilder>().getTextFromInputField();

                    if (playerName.Length < 7 && !int.TryParse(playerName, out _))
                    {
                        PlayerSystem.instance.createNewPlayer(playerName);

                        askAge();
                        askHeight();
                        askGender();
                        askWeight();

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
