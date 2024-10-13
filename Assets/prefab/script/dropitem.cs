using UnityEngine;
using UnityEngine.UI;


public class dropitem : MonoBehaviour
{
    public SpriteRenderer ItemImage;

    public static float ChanceTreasure = 10.0f, ChanceJewel = 15.0f, ChanceHeal = 10.0f;
    public Sprite Restore, Treasure, Jewel;

    public enum ItemType
    {
        STAMINA_RESTORE,
        SCORE_TREASURE,
        SCORE_JEWEL,
    }

    ItemType _type;
    float _randomValue;

    public ItemType Type { get => _type; set => _type = value; }

    public void Initialize(float randomValue)
    {
        _randomValue = randomValue;
    }

    public static bool CanSpawn(float randomValue)
    {
        Debug.Log($"v {randomValue} h {ChanceHeal} j {ChanceJewel}");
        if (randomValue <= 0 + ChanceHeal) // heal
        {
            return true;
        }
        else if (randomValue > ChanceHeal 
        && randomValue <= ChanceHeal + ChanceJewel) // jewel
        {
            return true;
        }
        else if (randomValue > ChanceHeal + ChanceJewel 
        && randomValue <= ChanceHeal + ChanceJewel + ChanceTreasure) // treasure
        {
            return true;
        }
        return false;
    }

    void Awake()
    {
        if (_randomValue <= 0 + ChanceHeal) // heal
        {
            Type = ItemType.STAMINA_RESTORE;
        }
        else if (_randomValue > ChanceHeal 
        && _randomValue <= ChanceHeal + ChanceJewel) // jewel
        {
            Type = ItemType.SCORE_TREASURE;
        }
        else if (_randomValue > ChanceHeal + ChanceJewel 
        && _randomValue <= ChanceHeal + ChanceJewel + ChanceTreasure) // treasure
        {
            Type = ItemType.SCORE_JEWEL;
        }

        switch(Type)
        {
            case ItemType.STAMINA_RESTORE:
            ItemImage.sprite = Restore;
            break;

            case ItemType.SCORE_TREASURE:
            ItemImage.sprite = Treasure;
            break;

            case ItemType.SCORE_JEWEL:
            ItemImage.sprite = Jewel;
            break;
        }
    }
}
