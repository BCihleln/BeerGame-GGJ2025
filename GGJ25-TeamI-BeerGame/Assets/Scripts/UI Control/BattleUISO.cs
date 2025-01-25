using UnityEngine;

[CreateAssetMenu(fileName = "BattleUISO", menuName = "Scriptable Objects/BattleUISO")]
public class BattleUISO : ScriptableObject
{
    public string[] phaseName;
    public Sprite[] beerPicture;
    public Sprite[] cupPicture;
    public string[] skillName;
    public Sprite[] skillPicture;
}
