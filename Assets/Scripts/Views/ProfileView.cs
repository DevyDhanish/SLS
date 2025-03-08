using TMPro;
using UnityEngine;

public class ProfileView : MonoBehaviour, View
{
    private Canvas thisCanvas;
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerStamina;
    [SerializeField] private TextMeshProUGUI playerStrength;
    [SerializeField] private TextMeshProUGUI playerScore;
    [SerializeField] private TextMeshProUGUI playerRank;

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

        Player player = PlayerSystem.instance.currentPlayer;

        playerName.SetText(player.Name);
        playerStamina.SetText("Stamina : " + player.playerStats.Stamina.ToString() + " Pts ");
        playerStrength.SetText("Strength : " + player.playerStats.Strength.ToString() + " Pts ");

        if(player.Rank != null)
            playerRank.SetText(player.Rank.RankTitle);
    }
}
