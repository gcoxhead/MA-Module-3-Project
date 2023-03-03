using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")]

public class PlayerDataSo : ScriptableObject
{
    public int health;
    public string name;
    public int credits;
    public string creditText;
  
}
