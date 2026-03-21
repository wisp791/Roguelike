using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelUpHandler : MonoBehaviour
{
    private Dictionary<OptionType, List<LevelUpOptionsBase>>
        optionBagWeights = new Dictionary<OptionType, List<LevelUpOptionsBase>>();
    private List<LevelUpOptionsBase> options = new List<LevelUpOptionsBase>();

    void Start()
    {
        List<LevelUpOptionsBase> statBag = new List<LevelUpOptionsBase>();
        statBag.Add(new LevelUpOptionStat(1, StatType.MAXHP, 1f));
        statBag.Add(new LevelUpOptionStat(2, StatType.ATK, 0.4f));
        statBag.Add(new LevelUpOptionStat(2, StatType.SPD, 1f));
        optionBagWeights.Add(OptionType.Stat, statBag);

        List<WeaponData> weaponDatas = Resources.LoadAll("Data", typeof(WeaponData))
            .Cast<WeaponData>().ToList<WeaponData>();
        List<LevelUpOptionsBase> weaponBag = new List<LevelUpOptionsBase>();
        weaponBag.Add(new LevelUpOptionWeapon(1, weaponDatas[0]));
        weaponBag.Add(new LevelUpOptionWeapon(1, weaponDatas[1]));
        weaponBag.Add(new LevelUpOptionWeapon(1, weaponDatas[2]));
        weaponBag.Add(new LevelUpOptionWeapon(1, weaponDatas[3]));
        optionBagWeights.Add(OptionType.Weapon, weaponBag);
        Debug.Log(optionBagWeights[OptionType.Weapon].Count);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private List<LevelUpOptionsBase> CreateBag(OptionType optionType)
    {
        List<LevelUpOptionsBase> bag = new List<LevelUpOptionsBase>();
        foreach (LevelUpOptionsBase option in optionBagWeights[optionType])
        {
            for(int i = 0; i < option.weight; i++)
            {
                bag.Add(option);
            }
        }
        Debug.Log(bag.Count);
        return bag;
    }

    private List<LevelUpOptionsBase> ChooseOptionsStatsOnly(int amount)
    {
        options.Clear();
        List<LevelUpOptionsBase> bag = CreateBag(OptionType.Stat);
        for (int i = 0; i < amount; i++)
        {
            int choice = Random.Range(0, bag.Count);
            options.Add(bag[choice]);
            bag.RemoveAt(choice);
        }
        return options;
    }

    public List<LevelUpOptionsBase> GetOptions()
    {
        ChooseOptions();
        return options;
    }

    private void ChooseOptions()
    {
        options.Clear();
        options.Add(OptionSelection12());
        options.Add(OptionSelection12());
        options.Add(OptionSelection3());
        options.Add(OptionSelection4());
    }

    private LevelUpOptionsBase OptionSelection12()
    {
        List<LevelUpOptionsBase> bag = CreateBag(OptionType.Weapon);
        int choice = Random.Range(0, bag.Count);
        return bag[choice];
    }
    private LevelUpOptionsBase OptionSelection3()
    {
        return new LevelUpOptionStat(2, StatType.MAXHP, 1f);
    }
    private LevelUpOptionsBase OptionSelection4()
    {
        return new LevelUpOptionStat(2, StatType.MAXHP, 2f);
    }
}

