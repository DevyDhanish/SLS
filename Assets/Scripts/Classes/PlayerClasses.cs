using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Player Classes")]
public class PlayerClasses : ScriptableObject
{
    public List<PlayerClass> playerclasses = new List<PlayerClass>();
}
