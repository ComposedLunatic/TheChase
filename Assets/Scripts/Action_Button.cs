// Copyright(C) 2020 Shawn Hodgson All Rights Reserved

using UnityEngine;

public class Action_Button : MonoBehaviour
{
    [SerializeField]
    private int _ActionToDo = 0;
    [SerializeField]
    private GameObject _Player = null;  

    private Player _PlayerUI;

    private void Awake()
    {
        _PlayerUI = _Player.GetComponent<Player>();
    }

    public void OnButtonPressed()
    {
        _PlayerUI.NextAction(_ActionToDo);
    }
}
