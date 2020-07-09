// Copyright(C) 2020 Shawn Hodgson All Rights Reserved

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    #region Variables
    
    [SerializeField]
    private Slider _MoneyUI = null;
    [SerializeField]
    private Slider _StudyUI = null;
    [SerializeField]
    private Slider _HungerUI = null;
    [SerializeField]
    private Slider _HappinessUI = null;
    [SerializeField]
    private GameObject _DialogueBox = null;
    [SerializeField]
    private GameObject _ActionButtons = null;
    [SerializeField]
    private GameObject _DenyButton = null;

    [SerializeField]
    private NPC_Stats _SkylarStats = null;
    [SerializeField]
    private NPC_Stats _OakleyStats = null;
    [SerializeField]
    private NPC_Stats _HopeStats = null;

    [SerializeField]
    private Player _Player = null;

    [SerializeField]
    private TextMeshProUGUI _NameBox = null;
    [SerializeField]
    private TextMeshProUGUI _DialogueText = null;
    [SerializeField]
    private TextMeshProUGUI _DayBox = null;
    [SerializeField]
    private TextMeshProUGUI _TimeBox = null;

    private SpriteManager _Sprite;

    public int Decision { get; private set; }
    public int SenLength { get; private set; }
    
    private int _SenSection = 0;
    private string _NewSprite = "";

    #endregion

    private void Awake()
    {
        _Sprite = GetComponent<SpriteManager>();
        _NewSprite = "Neutral";
    }

    public void UpdateName(string name)
    {
        _NameBox.text = name;
        _Sprite.ShowSprite(name, _NewSprite);
    }

    public void UpdateDialogue(NPC_Senarios curSenario, int setSenLength)
    {
        SenLength = setSenLength;
        // Grab the senario to play, easier than doing more "if"s
        string[] playSen = GetSenario(curSenario, _Player.Action);
        // End with displaying stat changes
        if (Decision >= (SenLength - 1))
        {
            _SenSection = playSen.Length - 1;
            _Sprite.HideAll();
        }
        _DialogueText.text = playSen[_SenSection];
    }
    
    public string[] GetSenario(NPC_Senarios curSenario, int playerAction)
    {
        string[] senToPlay;
        switch (playerAction)
        {
            case 1:
                senToPlay = curSenario.StudySen;
                break;
            case 2:
                senToPlay = curSenario.WorkSen;
                break;
            case 3:
                senToPlay = curSenario.EatSen;
                break;
            case 4:
                senToPlay = curSenario.GameSen;
                break;
            case 5:
                senToPlay = curSenario.ShoppingSen;
                break;
            case 6:
                senToPlay = curSenario.GymSen;
                break;
            case 7:
                senToPlay = curSenario.PartySen;
                break;
            // Anything other than player actions should be the "End"
            default:
                senToPlay = curSenario.End;
                break;
        }
        return senToPlay;
    }

    public void UpdateUI(GameState state)
    {
        _MoneyUI.value = _Player.Money;
        _StudyUI.value = _Player.Studies;
        _HungerUI.value = _Player.Hunger;
        _HappinessUI.value = _Player.Happiness;
        _DayBox.text = state.Day;
        _TimeBox.text = state.Time;
    }

    public void DenyButton()
    {
        if (_Player.Action != 8)
        {
            _NewSprite = "Sad";
        }
        else if (_NameBox.text == _SkylarStats.Name || _NameBox.text == _OakleyStats.Name)
        { 
            _NewSprite = "Psycho";
        }
        _SenSection = 2;
        Decision++;
        _DenyButton.SetActive(false);
    }

    public void OKButton()
    {
        if (_Player.Action != 8)
        {
            _NewSprite = "Happy";
        }
        else if (_NameBox.text == _SkylarStats.Name || _NameBox.text == _OakleyStats.Name)
        { 
            _NewSprite = "Psycho";
        }
        _SenSection = 1;
        Decision++;
        if (_NameBox.text == _SkylarStats.Name && _SenSection < 1) 
        { 
            _SkylarStats.SuccessfulInteaction(); 
        }
        else if (_NameBox.text == _OakleyStats.Name && _SenSection < 1) 
        { 
            _OakleyStats.SuccessfulInteaction(); 
        }
        else if (_NameBox.text == _HopeStats.Name && _SenSection < 1) 
        { 
            _HopeStats.SuccessfulInteaction(); 
        }
    }

    public void ShowDialogue(bool NPC_Sen)
    {
        _DialogueBox.SetActive(true);
        _DenyButton.SetActive(false);
        if(NPC_Sen) { _DenyButton.SetActive(true); }
        
        _ActionButtons.SetActive(false);
    }

    public void HideDialogue()
    {
        _NewSprite = "Neutral";
        _SenSection = 0;
        Decision = 0;
        _Sprite.HideAll();
        _DenyButton.SetActive(false);
        _DialogueBox.SetActive(false);
        _ActionButtons.SetActive(true);
    }

}
