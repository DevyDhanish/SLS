using System.Collections.Generic;
using UnityEngine;

// change ui views
// control backing
public class UISystem : Systems
{
    public static UISystem instance;

    private Stack<View> UIs = new Stack<View>();
    public List<GameObject> AllUIs = new List<GameObject>();

    private View currentView;

    public override void Init(){
        if(instance != this && instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }


        foreach (GameObject uis in AllUIs){
            uis.GetComponent<View>().Disable();
        }
    }

    public void changeUIbyName(string name){
        foreach (GameObject uis in AllUIs){
            if(uis.name == name)
            {
                changeUI(uis.GetComponent<View>());
            }
        }
    }

    public void changeUI(View newUI)
    {
        if(currentView != null)
            currentView.Disable();

        currentView = newUI;

        currentView.Enable();
        UIs.Push(currentView);
    }

    public void goBack(){
        currentView = UIs.Pop();
        currentView.Disable();

        currentView = UIs.Peek();
        currentView.Enable();
    }

    public View getCurrentView(){
        return currentView;
    }
}
