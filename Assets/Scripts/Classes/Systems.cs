using System.Collections.Generic;
using UnityEngine;

public class Systems : MonoBehaviour
{
    public List<GameObject> SystemsInstances = new List<GameObject>();

    public List<GameObject> ControllersInstances = new List<GameObject>();

    public virtual void Init(){}

    void Awake()
    {
    }

    public void InitAllSystems()
    {
        foreach(GameObject s in SystemsInstances )
        {
            s.GetComponent<Systems>().Init();
        }
    }


    public void InitAllControllers()
    {
        foreach(GameObject g in ControllersInstances)
        {
            g.GetComponent<Controllers>().InitController();
        }
    }
}
