using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogues
{

    public string name;
    [TextArea(3, 10)]
    public string[] sentences;

}