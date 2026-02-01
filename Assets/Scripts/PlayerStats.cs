using System;

[Serializable]
public class PlayerData
{
    public Status status;
    public Currency currency;
    public FoodItem[] food_inventory;
    public AccessoryItem[] accessory_inventory;
    public DateStamp datestamp;
}

[Serializable]
public class Status
{
    public int hunger;
    public int thirst;
}

[Serializable]
public class Currency
{
    public int coins;
    public int banks;
}

[Serializable]
public class FoodItem
{
    public string item;
    public int amount;
}

[Serializable]
public class AccessoryItem
{
    public int item_id;
}

[Serializable]
public class DateStamp
{
    public int logged_off;
    public int logged_on;
}