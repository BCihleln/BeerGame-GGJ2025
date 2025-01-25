using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bottle", menuName = "Bottle")]
public class Bottles : ScriptableObject
{
    public List<float> thresholdAngle;
    public List<float> foamPercentage;
    public List<float> beerPercentage;
    public float speedFactor;
}
