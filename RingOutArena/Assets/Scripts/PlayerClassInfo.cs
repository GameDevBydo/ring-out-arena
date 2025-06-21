using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerClassInfo", menuName = "Scriptable Objects/PlayerClassInfo")]
public class PlayerClassInfo : ScriptableObject
{
    public string className;
    public float classPower;
    public float classDefense;

    public Image portraitImage;
}
