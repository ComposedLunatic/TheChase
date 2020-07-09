// Copyright(C) 2020 Shawn Hodgson All Rights Reserved

using UnityEngine;

[CreateAssetMenu(fileName = "SenarioManager", menuName = "ScriptableObjects/SenarioManager", order = 2)]
public class SenarioManager : ScriptableObject
{
    // Write senarios for each NPC
    [SerializeField] 
    private string[] _Study = null;
    [SerializeField] 
    private string[] _Work = null;
    [SerializeField] 
    private string[] _Eat = null;
    [SerializeField] 
    private string[] _Game = null;
    [SerializeField] 
    private string[] _Shopping = null;
    [SerializeField] 
    private string[] _Party = null;
    [SerializeField] 
    private string[] _Gym = null;

    public string[] StudySen
    {
        get { return _Study; }
    }

    public string[] WorkSen
    {
        get { return _Work; }
    }

    public string[] EatSen
    {
        get { return _Eat; }
    }

    public string[] GameSen
    {
        get { return _Game; }
    }

    public string[] ShoppingSen
    {
        get { return _Shopping; }
    }

    public string[] PartySen
    {
        get { return _Party; }
    }

    public string[] GymSen
    {
        get { return _Gym; }
    }
}

