using UnityEngine;

[CreateAssetMenu(fileName = "SkillSO", menuName = "Scriptable Objects/SkillSO")]
public class SkillSO : ScriptableObject
{
    public string[] skillNames;
    public Sprite[] skillPictures;
    public string[] skillScribe;
}
