using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "New Recipe", order = 0)]
public class Recipe : ScriptableObject
{
    public enum Kitchen
    {
        Italian,
        Eastern,
        Mexican,
        Dutch,
        JamieOliver,
        AllerHande,
        Easy
    }

    public string name;
    public Kitchen kitchen;
    public string[] ingredients;
}
