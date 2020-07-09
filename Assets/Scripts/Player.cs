// Copyright(C) 2020 Shawn Hodgson All Rights Reserved

using UnityEngine;

public class Player : MonoBehaviour
{
    public int Action { get; private set; }

    // Player life stats 0-10
    public int Money { get; private set;}
    public int Studies { get; private set;}
    public int Hunger { get; private set;}
    public int Happiness { get; private set;}

    // Player attractive stats 0-10, They don't actually matter (like in real life... except Physique thats important)
    public int Glamour { get; private set;}
    public int Physique { get; private set;}
    public int Popularity { get; private set;}

    public void InitPlayer()
    {
        Action = -1;
        Money = 5;
        Studies = 5;
        Hunger = 5;
        Happiness = 5;
        Glamour = 5;
        Physique = 5;
        Popularity = 5;
    }

    public void NextAction(int newAction)
    {
        Action = newAction;
    }

    // Change amount so it isn't hard coded?
    public void UpdateMoney(int amount, bool add)
    {
        // Always add and subtract double when stat is not being increased, fast, easy and doesn't need an else
        Money += amount;
        if (Money > 10) { Money = 10; }

        if (!add)
        {
            Money -= (amount * 2);
        }
    }
    public void UpdateStudies(int amount, bool add)
    {
        Studies += amount;
        if (Studies > 10) { Studies = 10; }

        if (!add)
        {
            Studies -= (amount * 2);
        }
    }
    public void UpdateHunger(int amount, bool add)
    {
        Hunger += amount;
        if (Hunger > 10) { Hunger = 10; }

        if (!add)
        {
            Hunger -= (amount * 2);
        }
    }
    public void UpdateHappiness(int amount, bool add)
    {
        Happiness += amount;
        if (Happiness > 10) { Happiness = 10; }

        if (!add)
        {
            Happiness -= (amount * 2);
        }
    }
    public void UpdateGlamour(int amount, bool add)
    {
        Glamour += amount;
        if (Glamour > 10) { Glamour = 10; }

        if (!add)
        {
            Glamour -= (amount * 2);
        }
    }
    public void UpdatePhysique(int amount, bool add)
    {
        Physique += amount;
        if (Physique > 10) { Physique = 10; }

        if (!add)
        {
            Physique -= (amount * 2);
        }
    }
    public void UpdatePopularity(int amount, bool add)
    {
        Popularity += amount;
        if (Popularity > 10) { Popularity = 10; }

        if (!add)
        {
            Popularity -= (amount * 2);
        }
    }

    public bool CheckGameOver()
    {
        if (Money <= 0 || Studies <= 0 || Hunger <= 0 || Happiness <= 0)
        {
            return true;
        }
        return false;
    }

}
