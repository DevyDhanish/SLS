using UnityEngine;

public class SLSParameters : Systems
{
    public static SLSParameters instance;

    [SerializeField] private int rewardOnTaskComplete;

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
