using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;
using LitJson;
public class RankItem
{
    public string nickname;
    public string score;
    public string rank;
}

public  class DataManager : MonoBehaviour
{
    public static DataManager dataManager { get; set; }

    public int attack { get; private set; }
    public int chance { get; private set; }
    public int spawnTime { get; private set; }
    public int maxMating { get; private set; }
    public int incubator { get; private set; }
    public float attackRate { get; private set; }
    public int criticalChance { get; private set; }
    public int criticalAttack { get; private set; }
    public int slimePower { get; private set; }
    public int eggPotential { get; private set; }
    public int eggBag { get; private set; }
    public int slimeBag { get; private set; }
    public int curChance { get; private set; }
    public int curMating { get; private set; }
    public DateTime endTime { get; private set; }
    public int totalMating { get; private set; }
    public int totalCatch { get; private set; }
    public int totalBorn { get; private set; }

    public float slimeAveragePower { get; private set; }
    public int slimeSumPower { get; private set; }
    public int slimeMaxPower { get; private set; }

    public int money { get; private set; }
    public int jem { get; private set; }
    public int spendMoney { get; private set; }
    public int spendJem { get; private set; }

    public int slimeNum0 { get; private set; }
    public int slimeNum1 { get; private set; }
    public int slimeNum2 { get; private set; }
    public int slimeNum3 { get; private set; }
    public int slimeNum4 { get; private set; }
    public int slimeNum5 { get; private set; }
    public int slimeNum6 { get; private set; }
    public int slimeNum7 { get; private set; }
    public int slimeNum8 { get; private set; }
    public int slimeNum9 { get; private set; }
    public int slimeTotalNum { get; private set; }
    public List<string> slimeList0 = new List<string>();
    public List<string> slimeList1 = new List<string>();
    public List<string> slimeList2 = new List<string>();
    public List<string> slimeList3 = new List<string>();
    public List<string> slimeList4 = new List<string>();
    public List<string> slimeList5 = new List<string>();
    public List<string> slimeList6 = new List<string>();
    public List<string> slimeList7 = new List<string>();
    public List<string> slimeList8 = new List<string>();
    public List<string> slimeList9 = new List<string>();
    public List<string> slimeCode = new List<string>();
    
    public int eggNum0 { get; private set; }
    public int eggNum1 { get; private set; }
    public int eggNum2 { get; private set; }
    public int eggNum3 { get; private set; }
    public int eggNum4 { get; private set; }
    public int eggNum5 { get; private set; }
    public int eggNum6 { get; private set; }
    public int eggNum7 { get; private set; }
    public int eggNum8 { get; private set; }
    public int eggNum9 { get; private set; }
    public int eggTotalNum { get; private set; }
    public List<string> eggList0 = new List<string>();
    public List<string> eggList1 = new List<string>();
    public List<string> eggList2 = new List<string>();
    public List<string> eggList3 = new List<string>();
    public List<string> eggList4 = new List<string>();
    public List<string> eggList5 = new List<string>();
    public List<string> eggList6 = new List<string>();
    public List<string> eggList7 = new List<string>();
    public List<string> eggList8 = new List<string>();
    public List<string> eggList9 = new List<string>();
    public List<string> eggCode = new List<string>();

    public int daily_catch { get; private set; }
    public int daily_born { get; private set; }
    public int daily_spendMoney { get; private set; }
    public int daily_spendJem { get; private set; }
    public int daily_earnMoney { get; private set; }
    public int daily_catch2 { get; private set; }
    public int daily_mate { get; private set; }
    public int daily_ad { get; private set; }
    public int daily_complete { get; private set; }
    public int daily_complete_reward { get; private set; }
    public int daily_complete_catch { get; private set; }
    public int daily_complete_mate { get; private set; }
    public int daily_complete_born { get; private set; }
    public int daily_complete_spendMoney { get; private set; }
    public int daily_complete_earnMoney { get; private set; }
    public int daily_complete_catch2 { get; private set; }
    public int daily_complete_spendJem { get; private set; }
    public int daily_complete_ad { get; private set; }

    public int weekly_catch { get; private set; }
    public int weekly_born { get; private set; }
    public int weekly_spendMoney { get; private set; }
    public int weekly_spendJem { get; private set; }
    public int weekly_earnMoney { get; private set; }
    public int weekly_catch2 { get; private set; }
    public int weekly_mate { get; private set; }
    public int weekly_ad { get; private set; }
    public int weekly_complete { get; private set; }
    public int weekly_complete_reward { get; private set; }
    public int weekly_complete_catch { get; private set; }
    public int weekly_complete_mate { get; private set; }
    public int weekly_complete_born { get; private set; }
    public int weekly_complete_spendMoney { get; private set; }
    public int weekly_complete_earnMoney { get; private set; }
    public int weekly_complete_catch2 { get; private set; }
    public int weekly_complete_spendJem { get; private set; }
    public int weekly_complete_ad { get; private set; }

    public int achieve_catch { get; private set; }
    public int achieve_mating { get; private set; }
    public int achieve_born { get; private set; }
    public float achieve_avgPower { get; private set; }
    public int achieve_spendMoney { get; private set; }
    public int achieve_sumPower { get; private set; }
    public int achieve_spendJem { get; private set; }
    public int achieve_maxPower { get; private set; }
    public int achieve_complete_reward { get; private set; }
    public int achieve_complete{ get; private set; }

    public string sumRankingUUID = "df5ede70-356c-11ed-a4ab-692726fe8314";
    public string avgRankingUUID = "0cac28b0-356d-11ed-a4ab-692726fe8314";
    public string maxRankingUUID = "f6d0e9e0-356c-11ed-a4ab-692726fe8314";
    public string userNickname;

    public List<RankItem> sumRank = new List<RankItem>();
    public List<RankItem> avgRank = new List<RankItem>();
    public List<RankItem> maxRank = new List<RankItem>();
    Param param = new Param();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (dataManager == null)
            dataManager = this;
        else if (dataManager != this)
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        userNickname = Backend.UserNickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDataFromBro(string type)
    {
        var bro = Backend.GameData.GetMyData(type, new Where());
        if (!bro.IsSuccess())
        {
            if (bro.GetStatusCode() == "403")
                InitData(type);
            else
            {
                Debug.Log(bro.ToString());
                return;
            }
        }
        JsonData gameDataListJson = bro.FlattenRows();
        if(gameDataListJson.Count <= 0)
        {
            InitData(type);
            return;
        }

        GetGameInfo(type, gameDataListJson[0]);
    }

    public void InitData(string type)
    {
        Where wehere = new Where();
        Backend.GameData.Insert(type, param);
        GetDataFromBro(type);
    }

    public void GetGameInfo(string type, JsonData returnData)
    {
        switch (type)
        {
            case "PlayerInfo":
                attack = Int32.Parse(returnData["attack"].ToString());
                chance = Int32.Parse(returnData["chance"].ToString());
                spawnTime = Int32.Parse(returnData["spawnTime"].ToString());
                maxMating = Int32.Parse(returnData["maxMating"].ToString());
                incubator = Int32.Parse(returnData["incubator"].ToString());
                attackRate = float.Parse(returnData["attackRate"].ToString());
                criticalChance = Int32.Parse(returnData["criticalChance"].ToString());
                criticalAttack = Int32.Parse(returnData["criticalAttack"].ToString());
                slimePower = Int32.Parse(returnData["slimePower"].ToString());
                eggPotential = Int32.Parse(returnData["eggPotential"].ToString());
                eggBag = Int32.Parse(returnData["eggBag"].ToString());
                slimeBag = Int32.Parse(returnData["slimeBag"].ToString());
                curChance = Int32.Parse(returnData["curChance"].ToString());
                curMating = Int32.Parse(returnData["curMating"].ToString());
                endTime = DateTime.Parse(returnData["loginDate"].ToString()).Date;
                totalMating = Int32.Parse(returnData["totalMating"].ToString());
                totalCatch = Int32.Parse(returnData["totalCatch"].ToString());
                totalBorn = Int32.Parse(returnData["totalBorn"].ToString());
                
                break;
            case "SlimeList":
                slimeNum0 = Int32.Parse(returnData["slimeListNum0"].ToString());
                slimeNum1 = Int32.Parse(returnData["slimeListNum1"].ToString());
                slimeNum2 = Int32.Parse(returnData["slimeListNum2"].ToString());
                slimeNum3 = Int32.Parse(returnData["slimeListNum3"].ToString());
                slimeNum4 = Int32.Parse(returnData["slimeListNum4"].ToString());
                slimeNum5 = Int32.Parse(returnData["slimeListNum5"].ToString());
                slimeNum6 = Int32.Parse(returnData["slimeListNum6"].ToString());
                slimeNum7 = Int32.Parse(returnData["slimeListNum7"].ToString());
                slimeNum8 = Int32.Parse(returnData["slimeListNum8"].ToString());
                slimeNum9 = Int32.Parse(returnData["slimeListNum9"].ToString());
                for (int i = 0; i < slimeNum0; i++)
                    slimeList0.Add(returnData["slimeList0"][i].ToString());
                for (int i = 0; i < slimeNum1; i++)
                    slimeList1.Add(returnData["slimeList1"][i].ToString());
                for (int i = 0; i < slimeNum2; i++)
                    slimeList2.Add(returnData["slimeList2"][i].ToString());
                for (int i = 0; i < slimeNum3; i++)
                    slimeList3.Add(returnData["slimeList3"][i].ToString());
                for (int i = 0; i < slimeNum4; i++)
                    slimeList4.Add(returnData["slimeList4"][i].ToString());
                for (int i = 0; i < slimeNum5; i++)
                    slimeList5.Add(returnData["slimeList5"][i].ToString());
                for (int i = 0; i < slimeNum6; i++)
                    slimeList6.Add(returnData["slimeList6"][i].ToString());
                for (int i = 0; i < slimeNum7; i++)
                    slimeList7.Add(returnData["slimeList7"][i].ToString());
                for (int i = 0; i < slimeNum8; i++)
                    slimeList8.Add(returnData["slimeList8"][i].ToString());
                for (int i = 0; i < slimeNum9; i++)
                    slimeList9.Add(returnData["slimeList9"][i].ToString());
                if (slimeNum0 > 0)
                    slimeCode.AddRange(slimeList0);
                if (slimeNum1 > 0)
                    slimeCode.AddRange(slimeList1);
                if (slimeNum2 > 0)
                    slimeCode.AddRange(slimeList2);
                if (slimeNum3 > 0)
                    slimeCode.AddRange(slimeList3);
                if (slimeNum4 > 0)
                    slimeCode.AddRange(slimeList4);
                if (slimeNum5 > 0)
                    slimeCode.AddRange(slimeList5);
                if (slimeNum6 > 0)
                    slimeCode.AddRange(slimeList6);
                if (slimeNum7 > 0)
                    slimeCode.AddRange(slimeList7);
                if (slimeNum8 > 0)
                    slimeCode.AddRange(slimeList8);
                if (slimeNum9 > 0)
                    slimeCode.AddRange(slimeList9);

                break;

            case "EggList":
                eggNum0 = Int32.Parse(returnData["eggListNum0"].ToString());
                eggNum1 = Int32.Parse(returnData["eggListNum1"].ToString());
                eggNum2 = Int32.Parse(returnData["eggListNum2"].ToString());
                eggNum3 = Int32.Parse(returnData["eggListNum3"].ToString());
                eggNum4 = Int32.Parse(returnData["eggListNum4"].ToString());
                eggNum5 = Int32.Parse(returnData["eggListNum5"].ToString());
                eggNum6 = Int32.Parse(returnData["eggListNum6"].ToString());
                eggNum7 = Int32.Parse(returnData["eggListNum7"].ToString());
                eggNum8 = Int32.Parse(returnData["eggListNum8"].ToString());
                eggNum9 = Int32.Parse(returnData["eggListNum9"].ToString());
                for (int i = 0; i < eggNum0; i++)
                    eggList0.Add(returnData["eggList0"][i].ToString());
                for (int i = 0; i < eggNum1; i++)
                    eggList1.Add(returnData["eggList1"][i].ToString());
                for (int i = 0; i < eggNum2; i++)
                    eggList2.Add(returnData["eggList2"][i].ToString());
                for (int i = 0; i < eggNum3; i++)
                    eggList3.Add(returnData["eggList3"][i].ToString());
                for (int i = 0; i < eggNum4; i++)
                    eggList4.Add(returnData["eggList4"][i].ToString());
                for (int i = 0; i < eggNum5; i++)
                    eggList5.Add(returnData["eggList5"][i].ToString());
                for (int i = 0; i < eggNum6; i++)
                    eggList6.Add(returnData["eggList6"][i].ToString());
                for (int i = 0; i < eggNum7; i++)
                    eggList7.Add(returnData["eggList7"][i].ToString());
                for (int i = 0; i < eggNum8; i++)
                    eggList8.Add(returnData["eggList8"][i].ToString());
                for (int i = 0; i < eggNum9; i++)
                    eggList9.Add(returnData["eggList9"][i].ToString());

                if (eggNum0 > 0)
                    eggCode.AddRange(eggList0);
                if (eggNum1 > 0)
                    eggCode.AddRange(eggList1);
                if (eggNum2 > 0)
                    eggCode.AddRange(eggList2);
                if (eggNum3 > 0)
                    eggCode.AddRange(eggList3);
                if (eggNum4 > 0)
                    eggCode.AddRange(eggList4);
                if (eggNum5 > 0)
                    eggCode.AddRange(eggList5);
                if (eggNum6 > 0)
                    eggCode.AddRange(eggList6);
                if (eggNum7 > 0)
                    eggCode.AddRange(eggList7);
                if (eggNum8 > 0)
                    eggCode.AddRange(eggList8);
                if (eggNum9 > 0)
                    eggCode.AddRange(eggList9);

                break;

            case "PlayerCurrency":
                money = Int32.Parse(returnData["money"].ToString());
                jem = Int32.Parse(returnData["jem"].ToString());
                spendMoney = Int32.Parse(returnData["spendMoney"].ToString());
                spendJem = Int32.Parse(returnData["spendJem"].ToString());
                break;

            case "DailyQuest":
                daily_catch = Int32.Parse(returnData["catchSlime"].ToString());
                daily_born = Int32.Parse(returnData["bornTime"].ToString());
                daily_spendMoney = Int32.Parse(returnData["spendMoney"].ToString());
                daily_spendJem = Int32.Parse(returnData["spendJem"].ToString());
                daily_earnMoney = Int32.Parse(returnData["earnMoney"].ToString());
                daily_catch2 = Int32.Parse(returnData["catchSlime2"].ToString());
                daily_mate = Int32.Parse(returnData["matingTime"].ToString());
                daily_ad = Int32.Parse(returnData["watchAd"].ToString());
                daily_complete = Int32.Parse(returnData["complete"].ToString());
                daily_complete_reward = Int32.Parse(returnData["rewardComplete"].ToString());
                daily_complete_catch = Int32.Parse(returnData["catchComplete"].ToString());
                daily_complete_mate = Int32.Parse(returnData["matingComplete"].ToString());
                daily_complete_born = Int32.Parse(returnData["bornComplete"].ToString());
                daily_complete_spendMoney = Int32.Parse(returnData["spendComplete"].ToString());
                daily_complete_earnMoney = Int32.Parse(returnData["moneyComplete"].ToString());
                daily_complete_catch2 = Int32.Parse(returnData["catchComplete2"].ToString());
                daily_complete_spendJem = Int32.Parse(returnData["jemComplete"].ToString());
                daily_complete_ad = Int32.Parse(returnData["watchAdComplete"].ToString());
                break;
            case "WeeklyQuest":
                weekly_catch = Int32.Parse(returnData["catchSlime"].ToString());
                weekly_born = Int32.Parse(returnData["bornTime"].ToString());
                weekly_spendMoney = Int32.Parse(returnData["spendMoney"].ToString());
                weekly_spendJem = Int32.Parse(returnData["spendJem"].ToString());
                weekly_earnMoney = Int32.Parse(returnData["earnMoney"].ToString());
                weekly_catch2 = Int32.Parse(returnData["catchSlime2"].ToString());
                weekly_mate = Int32.Parse(returnData["matingTime"].ToString());
                weekly_ad = Int32.Parse(returnData["watchAd"].ToString());
                weekly_complete = Int32.Parse(returnData["complete"].ToString());
                weekly_complete_reward = Int32.Parse(returnData["rewardComplete"].ToString());
                weekly_complete_catch = Int32.Parse(returnData["catchComplete"].ToString());
                weekly_complete_mate = Int32.Parse(returnData["matingComplete"].ToString());
                weekly_complete_born = Int32.Parse(returnData["bornComplete"].ToString());
                weekly_complete_spendMoney = Int32.Parse(returnData["spendComplete"].ToString());
                weekly_complete_earnMoney = Int32.Parse(returnData["moneyComplete"].ToString());
                weekly_complete_catch2 = Int32.Parse(returnData["catchComplete2"].ToString());
                weekly_complete_spendJem = Int32.Parse(returnData["jemComplete"].ToString());
                weekly_complete_ad = Int32.Parse(returnData["watchAdComplete"].ToString());
                break;
            case "Achievement":
                achieve_maxPower = Int32.Parse(returnData["slimeMaxPower"].ToString());
                achieve_sumPower = Int32.Parse(returnData["slimeSumPower"].ToString());
                achieve_avgPower = float.Parse(returnData["slimeAveragePower"].ToString());
                achieve_catch = Int32.Parse(returnData["catchSlime"].ToString());
                achieve_mating = Int32.Parse(returnData["matingTime"].ToString());
                achieve_born = Int32.Parse(returnData["bornTime"].ToString());
                achieve_complete = Int32.Parse(returnData["complete"].ToString());
                achieve_spendJem = Int32.Parse(returnData["spendJem"].ToString());
                achieve_spendMoney = Int32.Parse(returnData["spendMoney"].ToString());
                achieve_complete_reward = Int32.Parse(returnData["rewardComplete"].ToString());
                break;
            case "SlimeRanking":
                slimeSumPower = Int32.Parse(returnData["slimeSumPower"].ToString());
                slimeMaxPower = Int32.Parse(returnData["slimeMaxPower"].ToString());
                slimeAveragePower = float.Parse(returnData["slimeAveragePower"].ToString());
                break;
        }
    }

    public void GetRank()
    {
        BackendReturnObject bro = Backend.URank.User.GetRankList(sumRankingUUID, 20);
        if (bro.IsSuccess())
        { 
            JsonData rankListJson = bro.GetFlattenJSON();
            for (int i = 0; i < rankListJson["rows"].Count; i++)
            {
                RankItem rankItem = new RankItem();

                rankItem.nickname = rankListJson["rows"][i]["nickname"].ToString();
                rankItem.score = rankListJson["rows"][i]["score"].ToString();
                rankItem.rank = rankListJson["rows"][i]["rank"].ToString();
                sumRank.Add(rankItem);
            }
        }
        bro = Backend.URank.User.GetRankList(avgRankingUUID, 20);
        if (bro.IsSuccess())
        {
            JsonData rankListJson = bro.GetFlattenJSON();
            for (int i = 0; i < rankListJson["rows"].Count; i++)
            {
                RankItem rankItem = new RankItem();

                rankItem.nickname = rankListJson["rows"][i]["nickname"].ToString();
                rankItem.score = rankListJson["rows"][i]["score"].ToString();
                rankItem.rank = rankListJson["rows"][i]["rank"].ToString();
                avgRank.Add(rankItem);
            }
        }
        bro = Backend.URank.User.GetRankList(maxRankingUUID, 20);
        if (bro.IsSuccess())
        {
            JsonData rankListJson = bro.GetFlattenJSON();
            for (int i = 0; i < rankListJson["rows"].Count; i++)
            {
                RankItem rankItem = new RankItem();

                rankItem.nickname = rankListJson["rows"][i]["nickname"].ToString();
                rankItem.score = rankListJson["rows"][i]["score"].ToString();
                rankItem.rank = rankListJson["rows"][i]["rank"].ToString();
                maxRank.Add(rankItem);
            }
        }

    }

    public void IncreaseData(string type)
    {
        switch (type)
        {
            case "attack":
                attack += 1;
                param.Add(type, attack);
                break;
            case "incubator":
                incubator += 1;
                param.Add(type, incubator);
                break;
            case "totalBorn":
                totalBorn += 1;
                param.Add(type, totalBorn);
                break;
            case "maxMating":
                maxMating += 1;
                param.Add(type, maxMating);
                break;
            case "curMating":
                curMating += 1;
                param.Add(type, curMating);
                break;
            case "criticalChance":
                criticalChance += 1;
                param.Add(type, criticalChance);
                break;
            case "eggPotential":
                eggPotential += 1;
                param.Add(type, eggPotential);
                break;
            case "slimePower":
                slimePower += 1;
                param.Add(type, slimePower);
                break;
            case "chance":
                chance += 1;
                param.Add(type, chance);
                break;
            case "curChance":
                curChance += 1;
                param.Add(type, curChance);
                break;
            case "totalCatch":
                totalCatch += 1;
                param.Add(type, totalCatch);
                break;
            case "totalMating":
                totalMating += 1;
                param.Add(type, totalMating);
                break;

        }
    }
    
    public void IncreaseData(string type, int num)
    {
        switch (type)
        {
            case "spendJem":
                spendJem += num;
                param.Add(type, spendJem);
                break;
            case "money":
                money += num;
                param.Add(type, money);
                break;
            case "jem":
                jem += num;
                param.Add(type, jem);
                break;
            case "eggBag":
                eggBag += num;
                param.Add(type, eggBag);
                break;
            case "slimeBag":
                slimeBag += num;
                param.Add(type, slimeBag);
                break;
            case "criticalAttack":
                criticalAttack += num;
                param.Add(type, criticalAttack);
                break;
            case "spendMoney":
                spendMoney += num;
                param.Add(type, spendMoney);
                break;
        }
    }

    public void IncreaseDailyData(string type)
    {
        switch (type)
        {
            case "catchSlime":
                daily_catch += 1;
                param.Add(type, daily_catch);
                break;
            case "catchSlime2":
                daily_catch2 += 1;
                param.Add(type, daily_catch2);
                break;
            case "bornTime":
                daily_born += 1;
                param.Add(type, daily_born);
                break;
            case "matingTime":
                daily_mate += 1;
                param.Add(type, daily_mate);
                break;
            case "reward":
                daily_complete_reward += 1;
                param.Add("rewardComplete", daily_complete_reward);
                break;
            case "watchAd":
                daily_ad += 1;
                param.Add(type, daily_ad);
                break;
        }
    }

    public void IncreaseDailyData(string type, int num)
    {
        switch (type)
        {
            case "spendMoney":
                daily_spendMoney += num;
                param.Add(type, daily_spendMoney);
                break;
            case "spendJem":
                daily_spendJem += num;
                param.Add(type, daily_spendJem);
                break;
            case "earnMoney":
                daily_earnMoney += num;
                param.Add(type, daily_earnMoney);
                break;
        }
    }

    public void IncreaseDailyData(string com, string type)
    {
        daily_complete += 1;
        param.Add("complete", daily_complete);
        switch (type)
        {
            case "catchSlime":
                daily_complete_catch += 1;
                param.Add("catchComplete", daily_complete_catch);
                break;
            case "catchSlime2":
                daily_complete_catch2 += 1;
                param.Add("catchComplete2", daily_complete_catch2);
                break;
            case "bornTime":
                daily_complete_born += 1;
                param.Add("bornComplete", daily_complete_born);
                break;
            case "matingTime":
                daily_complete_mate += 1;
                param.Add("matingComplete", daily_complete_mate);
                break;
            case "watchAd":
                daily_complete_ad += 1;
                param.Add("watchAdComplete", daily_complete_ad);
                break;
            case "spendMoney":
                daily_complete_spendMoney += 1;
                param.Add("spendComplete", daily_complete_spendMoney);
                break;
            case "spendJem":
                daily_complete_spendJem += 1;
                param.Add("jemComplete", daily_complete_spendJem);
                break;
            case "earnMoney":
                daily_complete_earnMoney += 1;
                param.Add("moneyComplete", daily_complete_earnMoney);
                break;
        }
    }

    public void IncreaseWeeklyData(string type)
    {
        switch (type)
        {
            case "catchSlime":
                weekly_catch += 1;
                param.Add(type, weekly_catch);
                break;
            case "catchSlime2":
                weekly_catch2 += 1;
                param.Add(type, weekly_catch2);
                break;
            case "bornTime":
                weekly_born += 1;
                param.Add(type, weekly_born);
                break;
            case "matingTime":
                weekly_mate += 1;
                param.Add(type, weekly_mate);
                break;
            case "reward":
                weekly_complete_reward += 1;
                param.Add("rewardComplete", weekly_complete_reward);
                break;
            case "watchAd":
                weekly_ad += 1;
                param.Add(type, weekly_ad);
                break;
        }
    }

    public void IncreaseWeeklyData(string type,int num)
    {
        switch (type)
        {
            case "spendMoney":
                weekly_spendMoney += num;
                param.Add(type, weekly_spendMoney);
                break;
            case "spendJem":
                weekly_spendJem += num;
                param.Add(type, weekly_spendJem);
                break;
            case "earnMoney":
                weekly_earnMoney += num;
                param.Add(type, weekly_earnMoney);
                break;
        }
    }

    public void IncreaseWeeklyData(string com, string type)
    {
        weekly_complete += 1;
        param.Add("complete", weekly_complete);
        switch (type)
        {
            case "catchSlime":
                weekly_complete_catch += 1;
                param.Add("catchComplete", weekly_complete_catch);
                break;
            case "catchSlime2":
                weekly_complete_catch2 += 1;
                param.Add("catchComplete2", weekly_complete_catch2);
                break;
            case "bornTime":
                weekly_complete_born += 1;
                param.Add("bornComplete", weekly_complete_born);
                break;
            case "matingTime":
                weekly_complete_mate += 1;
                param.Add("matingComplete", weekly_complete_mate);
                break;
            case "watchAd":
                weekly_complete_ad += 1;
                param.Add("watchAdComplete", weekly_complete_ad);
                break;
            case "spendMoney":
                weekly_complete_spendMoney += 1;
                param.Add("spendComplete", weekly_complete_spendMoney);
                break;
            case "spendJem":
                weekly_complete_spendJem += 1;
                param.Add("jemComplete", weekly_complete_spendJem);
                break;
            case "earnMoney":
                weekly_complete_earnMoney += 1;
                param.Add("moneyComplete", weekly_complete_earnMoney);
                break;
        }
    }

    public void IncreaseAchieveData(string type)
    {
        switch (type)
        {
            case "catchSlime":
                achieve_catch *= 2;
                param.Add(type, achieve_catch);
                achieve_complete += 1;
                param.Add("complete", achieve_complete);
                break;
            case "avgPower":
                achieve_avgPower += 10;
                param.Add("slimeAveragePower", achieve_avgPower);
                achieve_complete += 1;
                param.Add("complete", achieve_complete);
                break;
            case "bornTime":
                achieve_born *= 2;
                param.Add(type, achieve_born);
                achieve_complete += 1;
                param.Add("complete", achieve_complete);
                break;
            case "matingTime":
                achieve_mating *= 2;
                param.Add(type, achieve_mating);
                achieve_complete += 1;
                param.Add("complete", achieve_complete);
                break;
            case "sumPower":
                achieve_sumPower *= 2;
                param.Add("slimeSumPower", achieve_sumPower);
                achieve_complete += 1;
                param.Add("complete", achieve_complete);
                break;
            case "spendMoney":
                achieve_spendMoney *= 2;
                param.Add(type, achieve_spendMoney);
                achieve_complete += 1;
                param.Add("complete", achieve_complete);
                break;
            case "spendJem":
                achieve_spendJem *= 2;
                param.Add(type, achieve_spendJem);
                achieve_complete += 1;
                param.Add("complete", achieve_complete);
                break;
            case "maxPower":
                achieve_maxPower += 10;
                param.Add("slimeMaxPower", achieve_maxPower);
                achieve_complete += 1;
                param.Add("complete", achieve_complete);
                break;
            case "reward":
                achieve_complete_reward += 5;
                param.Add("rewardComplete", achieve_complete_reward);
                break;
        }
    }

    public void DecreaseData(string type)
    {
        switch (type)
        {
            case "curChance":
                curChance -= 1;
                param.Add(type, curChance);
                break;
            case "curMating":
                curMating -= 1;
                param.Add(type, curMating);
                break;
        }
    }

    public void DecreaseData(string type, int num)
    {
        switch (type)
        {
            case "jem":
                jem -= num;
                param.Add(type, jem);
                break;
            case "money":
                money -= num;
                param.Add(type, money);
                break;
            case "attackRate":
                attackRate -= 0.1f;
                param.Add(type, attackRate);
                break;
            case "spawnTime":
                spawnTime -= num;
                param.Add(type, spawnTime);
                break;
        }
    }

    public void AddSlimeCode(int num, string code)
    {
        string listNum = "slimeListNum" + num.ToString();
        string listName = "slimeList" + num.ToString();
        switch (num)
        {

            case 0:
                if (slimeNum0 == 0)
                    slimeList0 = new List<string>();
                slimeNum0 += 1;
                slimeList0.Add(code);
                slimeCode.Add(code);
                param.Add(listName, slimeList0);
                param.Add(listNum, slimeNum0);
                break;
            case 1:
                if (slimeNum1 == 0)
                    slimeList1 = new List<string>();
                slimeNum1 += 1;
                slimeList1.Add(code);
                slimeCode.Add(code);
                param.Add(listName, slimeList1);
                param.Add(listNum, slimeNum1);
                break;
            case 2:
                if (slimeNum2 == 0)
                    slimeList2 = new List<string>();
                slimeNum2 += 1;
                slimeList2.Add(code);
                slimeCode.Add(code);
                param.Add(listName, slimeList2);
                param.Add(listNum, slimeNum2);
                break;
            case 3:
                if (slimeNum3 == 0)
                    slimeList3 = new List<string>();
                slimeNum3 += 1;
                slimeList3.Add(code);
                slimeCode.Add(code);
                param.Add(listName, slimeList3);
                param.Add(listNum, slimeNum3);
                break;
            case 4:
                if (slimeNum4 == 0)
                    slimeList4 = new List<string>();
                slimeNum4 += 1;
                slimeList4.Add(code);
                slimeCode.Add(code);
                param.Add(listName, slimeList4);
                param.Add(listNum, slimeNum4);
                break;
            case 5:
                if (slimeNum5 == 0)
                    slimeList5 = new List<string>();
                slimeNum5 += 1;
                slimeList5.Add(code);
                slimeCode.Add(code);
                param.Add(listName, slimeList5);
                param.Add(listNum, slimeNum5);
                break;
            case 6:
                if (slimeNum6 == 0)
                    slimeList6 = new List<string>();
                slimeNum6 += 1;
                slimeList6.Add(code);
                slimeCode.Add(code);
                param.Add(listName, slimeList6);
                param.Add(listNum, slimeNum6);
                break;
            case 7:
                if (slimeNum7 == 0)
                    slimeList7 = new List<string>();
                slimeNum7 += 1;
                slimeList7.Add(code);
                slimeCode.Add(code);
                param.Add(listName, slimeList7);
                param.Add(listNum, slimeNum7);
                break;
            case 8:
                if (slimeNum8 == 0)
                    slimeList8 = new List<string>();
                slimeNum8 += 1;
                slimeList8.Add(code);
                slimeCode.Add(code);
                param.Add(listName, slimeList8);
                param.Add(listNum, slimeNum8);
                break;
            case 9:
                if (slimeNum9 == 0)
                    slimeList9 = new List<string>();
                slimeNum9 += 1;
                slimeList9.Add(code);
                slimeCode.Add(code);
                param.Add(listName, slimeList9);
                param.Add(listNum, slimeNum9);
                break;
        }
    }

    public void RemoveSlimeCode(int num, string code)
    {
        string listNum = "slimeListNum" + num.ToString();
        string listName = "slimeList" + num.ToString();
        switch (num)
        {

            case 0:
                slimeNum0 -= 1;
                slimeList0.Remove(code);
                slimeCode.Remove(code);
                param.Add(listName, slimeList0);
                param.Add(listNum, slimeNum0);
                break;
            case 1:
                slimeNum1 -= 1;
                slimeList1.Remove(code);
                slimeCode.Remove(code);
                param.Add(listName, slimeList1);
                param.Add(listNum, slimeNum1);
                break;
            case 2:
                slimeNum2 -= 1;
                slimeList2.Remove(code);
                slimeCode.Remove(code);
                param.Add(listName, slimeList2);
                param.Add(listNum, slimeNum2);
                break;
            case 3:
                slimeNum3 -= 1;
                slimeList3.Remove(code);
                slimeCode.Remove(code);
                param.Add(listName, slimeList3);
                param.Add(listNum, slimeNum3);
                break;
            case 4:
                slimeNum4 -= 1;
                slimeList4.Remove(code);
                slimeCode.Remove(code);
                param.Add(listName, slimeList4);
                param.Add(listNum, slimeNum4);
                break;
            case 5:
                slimeNum5 -= 1;
                slimeList5.Remove(code);
                slimeCode.Remove(code);
                param.Add(listName, slimeList5);
                param.Add(listNum, slimeNum5);
                break;
            case 6:
                slimeNum6 -= 1;
                slimeList6.Remove(code);
                slimeCode.Remove(code);
                param.Add(listName, slimeList6);
                param.Add(listNum, slimeNum6);
                break;
            case 7:
                slimeNum7 -= 1;
                slimeList7.Remove(code);
                slimeCode.Remove(code);
                param.Add(listName, slimeList7);
                param.Add(listNum, slimeNum7);
                break;
            case 8:
                slimeNum8 -= 1;
                slimeList8.Remove(code);
                slimeCode.Remove(code);
                param.Add(listName, slimeList8);
                param.Add(listNum, slimeNum8);
                break;
            case 9:
                slimeNum9 -= 1;
                slimeList9.Remove(code);
                slimeCode.Remove(code);
                param.Add(listName, slimeList9);
                param.Add(listNum, slimeNum9);
                break;
        }
    }

    public void AddEggCode(int num, string code)
    {
        string listNum = "eggListNum" + num.ToString();
        string listName = "eggList" + num.ToString();
        switch (num)
        {

            case 0:
                if (eggNum0 == 0)
                    eggList0 = new List<string>();
                eggNum0 += 1;
                eggList0.Add(code);
                eggCode.Add(code);
                param.Add(listName, eggList0);
                param.Add(listNum, eggNum0);
                break;
            case 1:
                if (eggNum1 == 0)
                    eggList1 = new List<string>();
                eggNum1 += 1;
                eggList1.Add(code);
                eggCode.Add(code);
                param.Add(listName, eggList1);
                param.Add(listNum, eggNum1);
                break;
            case 2:
                if (eggNum2 == 0)
                    eggList2 = new List<string>();
                eggNum2 += 1;
                eggList2.Add(code);
                eggCode.Add(code);
                param.Add(listName, eggList2);
                param.Add(listNum, eggNum2);
                break;
            case 3:
                if (eggNum3 == 0)
                    eggList3 = new List<string>();
                eggNum3 += 1;
                eggList3.Add(code);
                eggCode.Add(code);
                param.Add(listName, eggList3);
                param.Add(listNum, eggNum3);
                break;
            case 4:
                if (eggNum4 == 0)
                    eggList4 = new List<string>();
                eggNum4 += 1;
                eggList4.Add(code);
                eggCode.Add(code);
                param.Add(listName, eggList4);
                param.Add(listNum, eggNum4);
                break;
            case 5:
                if (eggNum5 == 0)
                    eggList5 = new List<string>();
                eggNum5 += 1;
                eggList5.Add(code);
                eggCode.Add(code);
                param.Add(listName, eggList5);
                param.Add(listNum, eggNum5);
                break;
            case 6:
                if (eggNum6 == 0)
                    eggList6 = new List<string>();
                eggNum6 += 1;
                eggList6.Add(code);
                eggCode.Add(code);
                param.Add(listName, eggList6);
                param.Add(listNum, eggNum6);
                break;
            case 7:
                if (eggNum7 == 0)
                    eggList7 = new List<string>();
                eggNum7 += 1;
                eggList7.Add(code);
                eggCode.Add(code);
                param.Add(listName, eggList7);
                param.Add(listNum, eggNum7);
                break;
            case 8:
                if (eggNum8 == 0)
                    eggList8 = new List<string>();
                eggNum8 += 1;
                eggList8.Add(code);
                eggCode.Add(code);
                param.Add(listName, eggList8);
                param.Add(listNum, eggNum8);
                break;
            case 9:
                if (eggNum9 == 0)
                    eggList9 = new List<string>();
                eggNum9 += 1;
                eggList9.Add(code);
                eggCode.Add(code);
                param.Add(listName, eggList9);
                param.Add(listNum, eggNum9);
                break;
        }
    }

    public void RemoveEggCode(int num, string code)
    {
        string listNum = "eggListNum" + num.ToString();
        string listName = "eggList" + num.ToString();
        switch (num)
        {

            case 0:
                eggNum0 -= 1;
                eggList0.Remove(code);
                eggCode.Remove(code);
                param.Add(listName, eggList0);
                param.Add(listNum, eggNum0);
                break;
            case 1:
                eggNum1 -= 1;
                eggList1.Remove(code);
                eggCode.Remove(code);
                param.Add(listName, eggList1);
                param.Add(listNum, eggNum1);
                break;
            case 2:
                eggNum2 -= 1;
                eggList2.Remove(code);
                eggCode.Remove(code);
                param.Add(listName, eggList2);
                param.Add(listNum, eggNum2);
                break;
            case 3:
                eggNum3 -= 1;
                eggList3.Remove(code);
                eggCode.Remove(code);
                param.Add(listName, eggList3);
                param.Add(listNum, eggNum3);
                break;
            case 4:
                eggNum4 -= 1;
                eggList4.Remove(code);
                eggCode.Remove(code);
                param.Add(listName, eggList4);
                param.Add(listNum, eggNum4);
                break;
            case 5:
                eggNum5 -= 1;
                eggList5.Remove(code);
                eggCode.Remove(code);
                param.Add(listName, eggList5);
                param.Add(listNum, eggNum5);
                break;
            case 6:
                eggNum6 -= 1;
                eggList6.Remove(code);
                eggCode.Remove(code);
                param.Add(listName, eggList6);
                param.Add(listNum, eggNum6);
                break;
            case 7:
                eggNum7 -= 1;
                eggList7.Remove(code);
                eggCode.Remove(code);
                param.Add(listName, eggList7);
                param.Add(listNum, eggNum7);
                break;
            case 8:
                eggNum8 -= 1;
                eggList8.Remove(code);
                eggCode.Remove(code);
                param.Add(listName, eggList8);
                param.Add(listNum, eggNum8);
                break;
            case 9:
                eggNum9 -= 1;
                eggList9.Remove(code);
                eggCode.Remove(code);
                param.Add(listName, eggList9);
                param.Add(listNum, eggNum9);
                break;
        }
    }

    public void ReplaceEggCode(int num,string prevCode ,string code)
    {
        switch (num)
        {
            case 0:
                eggList0.Remove(prevCode);
                eggList0.Add(code);
                eggCode.Remove(prevCode);
                eggCode.Add(code);
                break;
            case 1:
                eggList1.Remove(prevCode);
                eggList1.Add(code);
                eggCode.Remove(prevCode);
                eggCode.Add(code);
                break;
            case 2:
                eggList2.Remove(prevCode);
                eggList2.Add(code);
                eggCode.Remove(prevCode);
                eggCode.Add(code);
                break;
            case 3:
                eggList3.Remove(prevCode);
                eggList3.Add(code);
                eggCode.Remove(prevCode);
                eggCode.Add(code);
                break;
            case 4:
                eggList4.Remove(prevCode);
                eggList4.Add(code);
                eggCode.Remove(prevCode);
                eggCode.Add(code);
                break;
            case 5:
                eggList5.Remove(prevCode);
                eggList5.Add(code);
                eggCode.Remove(prevCode);
                eggCode.Add(code);
                break;
            case 6:
                eggList6.Remove(prevCode);
                eggList6.Add(code);
                eggCode.Remove(prevCode);
                eggCode.Add(code);
                break;
            case 7:
                eggList7.Remove(prevCode);
                eggList7.Add(code);
                eggCode.Remove(prevCode);
                eggCode.Add(code);
                break;
            case 8:
                eggList8.Remove(prevCode);
                eggList8.Add(code);
                eggCode.Remove(prevCode);
                eggCode.Add(code);
                break;
            case 9:
                eggList9.Remove(prevCode);
                eggList9.Add(code);
                eggCode.Remove(prevCode);
                eggCode.Add(code);
                break;
        }
    }

    public void SetRankingPower(int sum, int max, float avg)
    {
        string rowInDate = string.Empty;
        var bro = Backend.GameData.Get("SlimeRanking", new Where());
        if (bro.IsSuccess())
        {
            if (bro.FlattenRows().Count > 0)
            {
                rowInDate = bro.FlattenRows()[0]["inDate"].ToString();
            }
            else
            {
                var bro2 = Backend.GameData.Insert("SlimeRanking", param);
                if (bro2.IsSuccess())
                    rowInDate = bro2.GetInDate();
                else
                {
                    Debug.Log("랭킹 갱신 실패");
                    return;
                }
            }
        }
        if(rowInDate == string.Empty)
        {
            Debug.Log("랭킹 갱신 실패");
            return;
        }
        
        slimeAveragePower = avg;
        slimeMaxPower = max;
        slimeSumPower = sum;
        param.Add("slimeSumPower", slimeSumPower);
        param.Add("userNickName", Backend.UserNickName);
        Debug.Log(Backend.URank.User.UpdateUserScore(sumRankingUUID, "SlimeRanking",rowInDate, param));
        param.Clear();

        param.Add("slimeMaxPower", slimeMaxPower);
        param.Add("userNickName", Backend.UserNickName);
        Backend.URank.User.UpdateUserScore(maxRankingUUID, "SlimeRanking", rowInDate, param);
        param.Clear();

        param.Add("slimeAveragePower", slimeAveragePower);
        param.Add("userNickName", Backend.UserNickName);
        Backend.URank.User.UpdateUserScore(avgRankingUUID, "SlimeRanking", rowInDate, param);
        param.Clear();

    }

    public void ResetDateChance()
    {
        Debug.Log("일간 초기화");
        Where where = new Where();
        Backend.GameData.Delete("DailyQuest", where);
        Backend.GameData.Insert("DailyQuest", param);
        if(DateManager.dateManager.now.DayOfWeek == DayOfWeek.Monday)
        {
            Backend.GameData.Delete("WeeklyQuest", where);
            Backend.GameData.Insert("WeeklyQuest", param);
            Debug.Log("주간 초기화");
        }
        GetDataFromBro("DailyQuest");
        GetDataFromBro("WeeklyQuest");

        curChance = chance;
        curMating = maxMating;
        param.Add("curChance", curChance);
        param.Add("curMating", curMating);
        
    }

    public void UpdateDate()
    {
        dataManager.endTime = DateManager.dateManager.now.Date;
        param.Add("loginDate", endTime);
    }

    public void SubmitData()
    {
        Where where = new Where();
        Backend.GameData.Update("PlayerInfo", where, param);
        param.Clear();
    }

    public void SubmitData(string type)
    {
        Where where = new Where();
        Backend.GameData.Update(type, where, param);
        param.Clear();
    }


}
