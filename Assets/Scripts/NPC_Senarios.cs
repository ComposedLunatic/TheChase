// Copyright(C) 2020 Shawn Hodgson All Rights Reserved

using UnityEngine;

[CreateAssetMenu(fileName = "NPC_Senarios", menuName = "ScriptableObjects/NPC_Senarios", order = 2)]
public class NPC_Senarios : SenarioManager
{
    [SerializeField]
    private string[] _ExtraAttempt = null;
    [SerializeField]
    private string[] _End = null;

    public string[] ExtraAttempt
    {
        get {return _ExtraAttempt;}
    }

    public string[] End
    {
        get {return _End;}
    }
}
