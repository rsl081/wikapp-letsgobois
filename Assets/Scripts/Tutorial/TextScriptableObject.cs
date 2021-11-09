using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextTuts")]
public class TextScriptableObject : ScriptableObject
{
    [TextArea(10,14)][SerializeField] string tutsText;
    public string GetTuts()
    {
        return tutsText;
    }
}
