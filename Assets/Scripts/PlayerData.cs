using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public float[] position;

    public PlayerData(Transform player)
    {
        position = new float[3];
        
    }
}
