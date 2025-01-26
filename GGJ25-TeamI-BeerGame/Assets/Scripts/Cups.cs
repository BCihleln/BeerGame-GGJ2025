using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cup", menuName = "Cup")]
public class Cups : ScriptableObject
{
    public Vector3 offsetL;
    public Vector3 offsetR;
    public Sprite cupSprite;
    public Sprite foamSprite;
    public List<Sprite> fluidSprite;
    public float maxHeight;
    public float fluidHeight;
    public float bubbleHeight;
    public float maxVolume;
    public float fillLine;
    public Sprite fillSprite;
}
