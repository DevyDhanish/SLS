using TMPro;
using UnityEngine;

public class ProfileView : MonoBehaviour, View
{
    private Canvas thisCanvas;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerStamina;
    [SerializeField] private TextMeshProUGUI playerStrength;
    [SerializeField] private TextMeshProUGUI playerRank;

    public void OnClick()
    {
        UISystem.instance.goBack();
    }

    // public void incStam(){
    //     TaskResult tr = new TaskResult();
    //     tr.Type = TaskType.tasktype.STAMINA;
    //     tr.result = 1;
    //     EventSystem.instance.FireTaskCompleteEvent(tr);
    // }

    // public void incStre(){
    //     TaskResult tr = new TaskResult();
    //     tr.Type = TaskType.tasktype.STRENGTH;
    //     tr.result = 1;
    //     EventSystem.instance.FireTaskCompleteEvent(tr);
    // }

    public void refresh(){
        Disable();
        Enable();
    }

    void Start(){
        thisCanvas = gameObject.GetComponent<Canvas>();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
        playerName.SetText(Player.instance.Name);
        playerStamina.SetText("Stamina : " + Player.instance.playerStats.Stamina.ToString() + " Pts ");
        playerStrength.SetText("Strength : " + Player.instance.playerStats.Strength.ToString() + " Pts ");

        if(Player.instance.Rank != null)
            playerRank.SetText(Player.instance.Rank.rank);
    }
}
