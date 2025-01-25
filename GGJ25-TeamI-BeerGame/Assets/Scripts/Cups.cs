using UnityEngine;

[CreateAssetMenu(fileName = "New Cup", menuName = "Cup")]
public class Cups : ScriptableObject
{
    public Vector3 offsetL;
    public Vector3 offsetR;
    public float fluidWidth;
    public Sprite cupSprite;
}
