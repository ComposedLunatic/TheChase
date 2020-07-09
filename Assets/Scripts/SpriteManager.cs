// Copyright(C) 2020 Shawn Hodgson All Rights Reserved

using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _SkylarSpriteList = null;      // Main GO + 5 Sprites in array    |   Sprite arrays go in the order of:
                                                        //                                 |   0 = Main GO
    [SerializeField]                                    //                                 |   1 = Happy
    private GameObject[] _OakleySpriteList = null;      // Main GO + 5 Sprites in array    |   2 = Neutral
                                                        //                                 |   3 = Sad
    [SerializeField]                                    //                                 |   4 = Angry
    private GameObject[] _HopeSpriteList = null;        // Main GO + 3 Sprites in array    |   5 = Psycho

    public void HideAll()
    {
        foreach (var sprite in _SkylarSpriteList)
        {
            sprite.SetActive(false);
        }
        foreach (var sprite in _OakleySpriteList)
        {
            sprite.SetActive(false);
        }
        foreach (var sprite in _HopeSpriteList)
        {
            sprite.SetActive(false);
        }
    }

    public void ShowSprite(string name, string emotion)
    {
        // The 0th index for the arrays are the main sprite gameobject
        if (name == "Skylar") 
        { 
            _OakleySpriteList[0].SetActive(false);
            _HopeSpriteList[0].SetActive(false);
            _SkylarSpriteList[0].SetActive(true); 
            SkylarFace(emotion);
        }
        if (name == "Oakley") 
        { 
            _SkylarSpriteList[0].SetActive(false); 
            _HopeSpriteList[0].SetActive(false);
            _OakleySpriteList[0].SetActive(true);
            OakleyFace(emotion);
        }
        if (name == "Hope") 
        { 
            _SkylarSpriteList[0].SetActive(false); 
            _OakleySpriteList[0].SetActive(false);
            _HopeSpriteList[0].SetActive(true);
            HopeFace(emotion);
        }
    }

    public void SkylarFace(string Face)
    {
        switch(Face)
        {
            case "Happy":
                _SkylarSpriteList[1].SetActive(true); 
                _SkylarSpriteList[2].SetActive(false); 
                _SkylarSpriteList[3].SetActive(false); 
                break;

            case "Neutral":
                _SkylarSpriteList[1].SetActive(false); 
                _SkylarSpriteList[2].SetActive(true); 
                _SkylarSpriteList[3].SetActive(false); 
                break;

            case "Sad":
                _SkylarSpriteList[1].SetActive(false); 
                _SkylarSpriteList[2].SetActive(false); 
                _SkylarSpriteList[3].SetActive(true); 
                break;
            case "Psycho":
                _SkylarSpriteList[1].SetActive(false); 
                _SkylarSpriteList[2].SetActive(false); 
                _SkylarSpriteList[3].SetActive(false); 
                _SkylarSpriteList[5].SetActive(true); 
                break;
            default:
                break;
        }
    }

    public void OakleyFace(string Face)
    {
        switch(Face)
        {
            case "Happy":
                _OakleySpriteList[1].SetActive(true);
                _OakleySpriteList[2].SetActive(false);
                _OakleySpriteList[3].SetActive(false);
                break;

            case "Neutral":
                _OakleySpriteList[1].SetActive(false);
                _OakleySpriteList[2].SetActive(true);
                _OakleySpriteList[3].SetActive(false);
                break;

            case "Sad":
                _OakleySpriteList[1].SetActive(false);
                _OakleySpriteList[2].SetActive(false);
                _OakleySpriteList[3].SetActive(true);
                break;
            case "Psycho":
                _OakleySpriteList[1].SetActive(false); 
                _OakleySpriteList[2].SetActive(false); 
                _OakleySpriteList[3].SetActive(false); 
                _OakleySpriteList[5].SetActive(true); 
                break;
            default:
                break;
        }
    }

    public void HopeFace(string Face)
    {
        switch(Face)
        {
            case "Happy":
                _HopeSpriteList[1].SetActive(true);
                _HopeSpriteList[2].SetActive(false);
                _HopeSpriteList[3].SetActive(false);
                break;

            case "Neutral":
                _HopeSpriteList[1].SetActive(false);
                _HopeSpriteList[2].SetActive(true);
                _HopeSpriteList[3].SetActive(false);
                break;

            case "Sad":
                _HopeSpriteList[1].SetActive(false);
                _HopeSpriteList[2].SetActive(false);
                _HopeSpriteList[3].SetActive(true);
                break;

            default:
                break;
        }
    }
}
