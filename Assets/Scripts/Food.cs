using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Food")]
public class Food : ScriptableObject
{
    public Color color = Color.black;
    public int points = 1;
    public GameObject prefab;
}
