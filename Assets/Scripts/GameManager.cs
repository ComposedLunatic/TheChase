// Copyright(C) 2020 Shawn Hodgson All Rights Reserved

using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private GameState _GameState = null;

    [SerializeField]
    private NPC_Senarios _NormalSenario = null;
    [SerializeField]
    private NPC_Senarios _SkylarSenario = null;
    [SerializeField]
    private NPC_Senarios _OakleySenario = null;
    [SerializeField]
    private NPC_Senarios _HopeSenario = null;

    [SerializeField]
    private NPC_Stats _SkylarStats = null;
    [SerializeField]
    private NPC_Stats _OakleyStats = null;
    [SerializeField]
    private NPC_Stats _HopeStats = null;

    [SerializeField]
    private UI_Manager _UI = null;

    private Player _Player;

    #endregion

    private void Awake()
    {
        _Player = gameObject.GetComponent<Player>(); 
        // Init stats, make sure all values are at there default
        _GameState.InitState();
        _SkylarStats.Init();
        _OakleyStats.Init();
        _HopeStats.Init();
        _Player.InitPlayer();
        _UI.UpdateUI(_GameState);
    }

    void Update()
    {
        // Can probably change this so it's more event based rather on update
        while ( _GameState.State != "End" )
        {
            if (_GameState.State == "Select")
            {
                // Player selects action -> return int
                while (_Player.Action < 0) { return; }
                // Change NPC stats based on player action
                ModifyStats(_Player.Action);
                _GameState.NewState("Senario");
            }
            if (_GameState.State == "Senario")
            {
                // Determine senario
                DetermineEncounter();
                // Play senario
                while (_UI.Decision < _UI.SenLength) { return; }
                _GameState.NewState("UpdateUI");
            }
            if (_GameState.State == "UpdateUI")
            {
                // Update Game State
                _Player.NextAction(-1);
                CheckEncountered();
                EndOfDay();
                _UI.HideDialogue();
                _UI.UpdateUI(_GameState);
            }
        }
        _Player.NextAction(8);
        _UI.ShowDialogue(true);
        DetermineEnd();
    }

    void DetermineEncounter()
    {
        _UI.ShowDialogue(true);
        // Check Hope first to help encounter them more
        if (_HopeStats.Courage >= _HopeStats.EncounterRate)
        {
            _UI.UpdateName(_HopeStats.Name);
            _UI.UpdateDialogue(_HopeSenario, 3);
            _HopeStats.Encountered = true;
        }
        else if (_SkylarStats.Courage >= _SkylarStats.EncounterRate)
        {
            _UI.UpdateName(_SkylarStats.Name);
            _UI.UpdateDialogue(_SkylarSenario, 3);
            _SkylarStats.Encountered = true;
        }
        else if (_OakleyStats.Courage >= _OakleyStats.EncounterRate)
        {
            _UI.UpdateName(_OakleyStats.Name);
            _UI.UpdateDialogue(_OakleySenario, 3);
            _OakleyStats.Encountered = true;
        }
        else
        {
            _UI.ShowDialogue(false);
            _UI.UpdateName("");
            _UI.UpdateDialogue(_NormalSenario, 2);
        }
    }

    void DetermineEnd()
    {
        // Check if the player Game Overed first, this way other Ends don't play on accident
        if (_Player.CheckGameOver())
        {
            _UI.ShowDialogue(false);
            _UI.UpdateName("");
            _UI.UpdateDialogue(_NormalSenario, 2);
        }
        else if (_HopeStats.Attraction > _OakleyStats.Attraction && _HopeStats.Attraction > _SkylarStats.Attraction)
        {
            _UI.UpdateName(_HopeStats.Name);
            _UI.UpdateDialogue(_HopeSenario, 3);
        }
        else if (_SkylarStats.Attraction > _HopeStats.Attraction && _SkylarStats.Attraction > _OakleyStats.Attraction)
        {
            _UI.UpdateName(_SkylarStats.Name);
            _UI.UpdateDialogue(_SkylarSenario, 3);
        }
        else if (_OakleyStats.Attraction > _HopeStats.Attraction && _OakleyStats.Attraction > _SkylarStats.Attraction)
        {
            _UI.UpdateName(_OakleyStats.Name);
            _UI.UpdateDialogue(_OakleySenario, 3);
        }
    }

    void CheckEncountered()
    {
        _HopeStats.ResetCourage();
        _SkylarStats.ResetCourage();
        _OakleyStats.ResetCourage();
    }

    void ModifyStats(int Action)
    {
        switch (Action)
        {
            // Study
            case 1:
                _OakleyStats.Increase();
                _HopeStats.Increase();
                _Player.UpdateStudies(3, true);
                _Player.UpdateHunger(2, false);
                break;
            // Work
            case 2:
                _SkylarStats.Increase();
                _HopeStats.Increase();
                _Player.UpdateMoney(3, true);
                _Player.UpdateHappiness(2, false);
                break;
            // Go to Eat
            case 3:
                _OakleyStats.Increase();
                _SkylarStats.Increase();
                _Player.UpdateHunger(3, true);
                _Player.UpdateMoney(2, false);
                break;
            // Play Games
            case 4:
                _HopeStats.Increase();
                _SkylarStats.Increase();
                _OakleyStats.Decrease();
                _Player.UpdateHappiness(3, true);
                _Player.UpdateStudies(2, false);
                break;
            // Go Shopping
            case 5:
                _SkylarStats.Increase();
                _Player.UpdateGlamour(2, true);
                _Player.UpdateMoney(3, false);
                break;
            // Go to the Gym
            case 6:
                _OakleyStats.Increase();
                _SkylarStats.Increase();
                _Player.UpdatePhysique(2, true);
                _Player.UpdateHunger(3, false);
                break;
            // Go Party
            case 7:
                _OakleyStats.Increase();
                _SkylarStats.Decrease();
                _Player.UpdatePopularity(2, true);
                _Player.UpdateStudies(3, false);
                break;

            default:
                break;
        }
    }

    void EndOfDay()
    {
        if (_Player.CheckGameOver() || _GameState.Day == "End")
        {
            _GameState.NewState("End");
            return;            
        }
        _GameState.UpdateState();
    }
}
