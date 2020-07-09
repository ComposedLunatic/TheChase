// Copyright(C) 2020 Shawn Hodgson All Rights Reserved

using UnityEngine;

[CreateAssetMenu(fileName = "NPC_Stats", menuName = "ScriptableObjects/NPC_Stats", order = 3)]
public class NPC_Stats : ScriptableObject
{
    [SerializeField]
    private string _Name = null;
    // The amount courage needed to interact with player
    [SerializeField]
    private int _EncounterRate = 0;

    // Amount attracted to the player - determines end senario
    public int Attraction { get; private set; }     
    // # of times they interacted with the player
    public int Interactions { get; private set; }
    // Increased when player selects an interest
    public int Courage { get; private set; }      
    public bool Encountered = false;    

    public string Name
    {
        get { return _Name; }
    }

    public int EncounterRate
    {
        get { return _EncounterRate; }
        set { _EncounterRate = value; }
    }

    public void Init()
    {
        Attraction = 0;   
        Interactions = 0; 
        Courage = 0;    
        EncounterRate = 5;
        Encountered = false;
        if (_Name == "Skylar")
        {
            EncounterRate = 7;
        }  
        if (_Name == "Oakley")
        {
            EncounterRate = 7;
        }  

    }

    public void SuccessfulInteaction()
    {
        Attraction++; 
        if (_Name == "Skylar" || _Name == "Oakley")
        {
            EncounterRate--; 
        }
    }

    public void Increase()
    {
        Attraction += 2;
        Courage += 3;
        Interactions++;
    }

    public void Decrease()
    {
        Attraction--;
    }

    public void ResetCourage()
    {
        if (Encountered)
        { 
            Courage = 0; 
            Encountered = false;
        }
    }
}
