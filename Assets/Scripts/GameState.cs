// Copyright(C) 2020 Shawn Hodgson All Rights Reserved

using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObjects/GameState", order = 1)]
public class GameState : ScriptableObject
{ 
    // TODO: Naming conventions on proporties.
    public string State { get; private set; }
    public string Day { get; private set; }
    public string Time { get; private set; }

    private string[] _WeekDays = {"Sunday", "Monday", "Tuesday", "Wednsday", "Thursday", "Friday","Saturday", "End"};
    private int _CurDay = 0;
    private string[] _DayTimes = {"Morning", "Afternoon", "Evening"};
    private int _CurTime = 0;

    public void InitState()
    {
        _CurDay = 0;
        _CurTime = 0;
        Day = _WeekDays[_CurDay];
        Time = _DayTimes[_CurTime];
        State = "Select";
    }

    public void UpdateState()
    {
        State = "Select";
        _CurTime++;
        if(_CurTime >= 3)
        {
            _CurTime = 0;
            _CurDay++;
        }
        Day = _WeekDays[_CurDay];
        Time = _DayTimes[_CurTime];
    }

    public void NewState(string newState)
    {
        State = newState;
    }
}
