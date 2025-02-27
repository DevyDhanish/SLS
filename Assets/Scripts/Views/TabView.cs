using UnityEngine;

public class TabView : MonoBehaviour
{
    public void goHome()
    {
        UISystem.instance.changeUIbyName("Home");
    }

    public void goTs()
    {
        UISystem.instance.changeUIbyName("Task");
    }

    public void goProfile()
    {
        UISystem.instance.changeUIbyName("Profile");
    }
}
