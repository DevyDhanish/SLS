using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankSlider : MonoBehaviour, View
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI rankText;

    void setup(Task t)
    {
        Rank nextRankValues = Rank.getNextRank(PlayerSystem.instance.currentPlayer.Rank);
        Debug.Log(nextRankValues.RankTitle);
        slider.maxValue = nextRankValues.RankThreshold;
        slider.minValue = 0;

        slider.value = PlayerSystem.instance.currentPlayer.playerStats.Score;

        rankText.SetText(
            SLSParameters.instance.rankSliderTitlePrefix + nextRankValues.RankTitle + SLSParameters.instance.rankSliderTitleSufix
            );
    }

    public void Disable()
    {
        //gameObject.SetActive(false);
    }

    // void Update()
    // {
    //     setup();
    // }

    public void Enable()
    {
        //gameObject.SetActive(true);

        slider = gameObject.GetComponentInChildren<Slider>();
        rankText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        
        setup(null);

        EventSystem.instance.OnTaskComplete += setup;
    }
}
