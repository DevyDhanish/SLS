using System.Collections.Generic;
using UnityEngine;

public class ResourceSystem : Systems
{
    public static ResourceSystem instance;

    [SerializeField] private List<Sprite> AllSprites = new List<Sprite>();

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

    public Sprite getSpriteByName(string spriteName)
    {
        foreach(Sprite s in AllSprites)
        {
            if(s.name == spriteName)
            {
                return s;
            }
        }

        return null;
    }
}
