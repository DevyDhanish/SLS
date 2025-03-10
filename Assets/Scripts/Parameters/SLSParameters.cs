using System.ComponentModel;
using UnityEngine;

public class SLSParameters : Systems
{
    public static SLSParameters instance;

    [SerializeField] public int rewardOnTaskComplete;
    [SerializeField] public string rankSliderTitleSufix;
    [SerializeField] public string rankSliderTitlePrefix;

    public override void Init()
    {
        if(instance != this && instance != null)
        {
            Destroy(instance);
        } 

        else
        {
            instance = this;
        }
    }


    public int getRewardOnTaskComplete()
    {
        return rewardOnTaskComplete;
    }
}
