using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;
using static BreakInfinity.BigDouble;
using System;




public class PlantGame : MonoBehaviour
{
    public DataCollections data;

    //leaves upgrades/text
    public Text leavesText;
    public Text clickValueText;
    

    public Text leavesPerSecText;
    public Text clickUpgrade1Text;
    public Text productionUpgrade1Text;
    public Text productionUpgrade2Text;
    public Text clickUpgrade2Text;

    

    
    
    //glucose upgrade/text
    public Text glucoseText;
    public Text glucoseToGetText;

    
    

    public Text wateringCanText;
    public Text fertilizerText;
    public Text sprinklerText;
    public Text glovesText;


    public Image waterBar;
    

    public Text waterText1;
    public Text waterText2;

    public Image sunlightBar;
    

    public Text sunlightText1;
    public Text sunlightText2;


    public Image bugBar;
    

    public Text bugText1;
    public Text bugText2;

    public CanvasGroup shopControllerGroup;
    public CanvasGroup craftingControllerGroup;
    public CanvasGroup inventoryControllerGroup;

    //inventory section

    public Text redPotionText;
    public Text bluePotionText;
    public Text greenPotionText;
    public Text purplePotionText;
    public Text orangePotionText;
    public Text mysteryPotionText;
    public Text redInvText;
    public Text blueInvText;
    public Text greenInvText;
    public Text purpleInvText;
    public Text orangeInvText;
    public Text mysteryInvText;

    
    public Text potionText;

    //season

    public Image seasonWheel;
    
    [SerializeField] public Vector3 _rotation;
    public Vector3 vector;
    public Text seasonText;

    //3rd row upgrades
    
    public Text weedWhackerText;

    
    public Text slugText;

    
    public Text weedWhackerUpgradeText;

    
    public Text slugUpgradeText;
    public float saveTime;

    public GameObject settings;

    private const string dataFileName = "PlayerData";
    public void Start()
    {
        Application.targetFrameRate=60;
        CanvasGroupChanger(true,shopControllerGroup);
        CanvasGroupChanger(false,inventoryControllerGroup);
        CanvasGroupChanger(false,craftingControllerGroup);
        //Load();
        //data=new DataCollections();
        data = SaveSystem.SaveExists(dataFileName) ? SaveSystem.LoadData<DataCollections>(dataFileName): new DataCollections();
        if(data.fertilizerCost==0)
        {
            FullReset();
        }
    }

    public void CanvasGroupChanger(bool x,CanvasGroup target)
    {
        if(x)
        {
            target.alpha=1;
            target.interactable=true;
            target.blocksRaycasts=true;
            return;
        }

        target.alpha=0;
        target.interactable=false;
        target.blocksRaycasts=false;
    }

    //loads the save
    /*
    public void Load()
    {
        leaves= BigDouble.Parse(PlayerPrefs.GetString("leaves","0"));
        glucose= BigDouble.Parse(PlayerPrefs.GetString("glucose","0"));
        leavesClickValue= BigDouble.Parse(PlayerPrefs.GetString("leavesClickValue","1"));
        clickUpgrade1Cost= BigDouble.Parse(PlayerPrefs.GetString("clickUpgrade1Cost","10"));
        clickUpgrade2Cost= BigDouble.Parse(PlayerPrefs.GetString("clickUpgrade2Cost","100"));
        productionUpgrade1Cost= BigDouble.Parse(PlayerPrefs.GetString("productionUpgrade1Cost","25"));
        productionUpgrade2Cost= BigDouble.Parse(PlayerPrefs.GetString("productionUpgrade2Cost","250"));
        productionUpgrade2Power= BigDouble.Parse(PlayerPrefs.GetString("productionUpgrade2Power","5"));

        wateringCanCost= BigDouble.Parse(PlayerPrefs.GetString("wateringCanCost","10"));
        fertilizerCost= BigDouble.Parse(PlayerPrefs.GetString("fertilizerCost","25"));
        glovesCost= BigDouble.Parse(PlayerPrefs.GetString("glovesCost","100"));
        sprinklerCost= BigDouble.Parse(PlayerPrefs.GetString("sprinklerCost","250"));
        wateringCanPower= BigDouble.Parse(PlayerPrefs.GetString("wateringCanPower","1"));
        fertilizerPower= BigDouble.Parse(PlayerPrefs.GetString("fertilizerPower","1"));
        glovesPower= BigDouble.Parse(PlayerPrefs.GetString("glovesPower","5"));
        sprinklerPower= BigDouble.Parse(PlayerPrefs.GetString("sprinklerPower","5"));

        clickUpgrade1Level = PlayerPrefs.GetInt("clickUpgrade1Level",0);
        clickUpgrade2Level = PlayerPrefs.GetInt("clickUpgrade2Level",0);
        productionUpgrade1Level = PlayerPrefs.GetInt("productionUpgrade1Level",0);
        productionUpgrade2Level = PlayerPrefs.GetInt("productionUpgrade2Level",0);

        wateringCanLevel = PlayerPrefs.GetInt("wateringCanLevel",0);
        fertilizerLevel = PlayerPrefs.GetInt("fertilizerLevel",0);
        glovesLevel = PlayerPrefs.GetInt("glovesLevel",0);
        sprinklerLevel = PlayerPrefs.GetInt("sprinklerLevel",0);

        waterLevel=double.Parse(PlayerPrefs.GetString("waterLevel","100"));
        sunlightLevel=double.Parse(PlayerPrefs.GetString("sunlightLevel","100"));
        bugLevel=PlayerPrefs.GetInt("bugLevel",0);

        //load crafting/inventory info
        redPotionAmount = PlayerPrefs.GetInt("redPotionAmount",0);
        bluePotionAmount = PlayerPrefs.GetInt("bluePotionAmount",0);
        greenPotionAmount = PlayerPrefs.GetInt("greenPotionAmount",0);
        purplePotionAmount = PlayerPrefs.GetInt("purplePotionAmount",0);
        orangePotionAmount = PlayerPrefs.GetInt("orangePotionAmount",0);
        mysteryPotionAmount = PlayerPrefs.GetInt("mysteryPotionAmount",0);

        redPotionCost = BigDouble.Parse(PlayerPrefs.GetString("redPotionCost","100"));
        bluePotionCost = BigDouble.Parse(PlayerPrefs.GetString("bluePotionCost","10000"));
        greenPotionCost = BigDouble.Parse(PlayerPrefs.GetString("greenPotionCost","1000000"));
        purplePotionCost = BigDouble.Parse(PlayerPrefs.GetString("purplePotionCost","100000000"));
        orangePotionCost = BigDouble.Parse(PlayerPrefs.GetString("orangePotionCost","10000000000"));
        mysteryPotionCost = BigDouble.Parse(PlayerPrefs.GetString("mysteryPotionCost","1000000000000"));
        potionEffect=BigDouble.Parse(PlayerPrefs.GetString("potionEffect","1"));
        potionTimer=BigDouble.Parse(PlayerPrefs.GetString("potionTimer","0"));

        //season loads
        seasonAngle=double.Parse(PlayerPrefs.GetString("seasonAngle","0"));

        //3rd row upgrades loads

        weedWhackerCost=BigDouble.Parse(PlayerPrefs.GetString("weedWhackerCost","1000"));
        weedWhackerPower=BigDouble.Parse(PlayerPrefs.GetString("weedWhackerPower","25"));
        weedWhackerLevel=(PlayerPrefs.GetInt("weedWhackerLevel",0));

        weedWhackerUpgradeCost=BigDouble.Parse(PlayerPrefs.GetString("weedWhackerUpgradeCost","1000"));
        weedWhackerUpgradePower=BigDouble.Parse(PlayerPrefs.GetString("weedWhackerUpgradePower","25"));
        weedWhackerUpgradeLevel=(PlayerPrefs.GetInt("weedWhackerUpgradeLevel",0));

        slugCost=BigDouble.Parse(PlayerPrefs.GetString("slugCost","2500"));
        slugPower=BigDouble.Parse(PlayerPrefs.GetString("slugPower","25"));
        slugLevel=(PlayerPrefs.GetInt("slugLevel",0));

        slugUpgradeCost=BigDouble.Parse(PlayerPrefs.GetString("slugUpgradeCost","2500"));
        slugUpgradePower=BigDouble.Parse(PlayerPrefs.GetString("slugUpgradePower","25"));
        slugUpgradeLevel=(PlayerPrefs.GetInt("slugUpgradeLevel",0));



    }
    //saves the game
    public void Save()
    {
        PlayerPrefs.SetString("leaves",leaves.ToString());
        PlayerPrefs.SetString("leavesClickValue",leavesClickValue.ToString());
        PlayerPrefs.SetString("clickUpgrade1Cost",clickUpgrade1Cost.ToString());
        PlayerPrefs.SetString("clickUpgrade2Cost",clickUpgrade2Cost.ToString());
        PlayerPrefs.SetString("productionUpgrade1Cost",productionUpgrade1Cost.ToString());
        PlayerPrefs.SetString("productionUpgrade2Cost",productionUpgrade2Cost.ToString());
        PlayerPrefs.SetString("glucose",glucose.ToString());

        PlayerPrefs.SetInt("clickUpgrade1Level",clickUpgrade1Level);
        PlayerPrefs.SetInt("clickUpgrade2Level",clickUpgrade2Level);
        PlayerPrefs.SetInt("productionUpgrade1Level",productionUpgrade1Level);
        PlayerPrefs.SetInt("productionUpgrade2Level",productionUpgrade2Level);


        PlayerPrefs.SetString("wateringCanCost",wateringCanCost.ToString());
        PlayerPrefs.SetString("glovesCost",glovesCost.ToString());
        PlayerPrefs.SetString("fertilizerCost",fertilizerCost.ToString());
        PlayerPrefs.SetString("sprinklerCost",sprinklerCost.ToString());


        PlayerPrefs.SetInt("wateringCanLevel",wateringCanLevel);
        PlayerPrefs.SetInt("fertilizerLevel",fertilizerLevel);
        PlayerPrefs.SetInt("glovesLevel",glovesLevel);
        PlayerPrefs.SetInt("sprinklerLevel",sprinklerLevel);

        PlayerPrefs.SetString("waterLevel",waterLevel.ToString());
        PlayerPrefs.SetString("sunlightLevel",sunlightLevel.ToString());
        PlayerPrefs.SetInt("bugLevel",bugLevel);

        //set inventory amounts
        PlayerPrefs.SetInt("redPotionAmount",redPotionAmount);
        PlayerPrefs.SetInt("bluePotionAmount",bluePotionAmount);
        PlayerPrefs.SetInt("greenPotionAmount",greenPotionAmount);
        PlayerPrefs.SetInt("purplePotionAmount",purplePotionAmount);
        PlayerPrefs.SetInt("orangePotionAmount",orangePotionAmount);
        PlayerPrefs.SetInt("mysteryPotionAmount",mysteryPotionAmount);

        PlayerPrefs.SetString("redPotionCost",redPotionCost.ToString());
        PlayerPrefs.SetString("bluePotionCost",bluePotionCost.ToString());
        PlayerPrefs.SetString("greenPotionCost",greenPotionCost.ToString());
        PlayerPrefs.SetString("purplePotionCost",purplePotionCost.ToString());
        PlayerPrefs.SetString("orangePotionCost",orangePotionCost.ToString());
        PlayerPrefs.SetString("mysteryPotionCost",mysteryPotionCost.ToString());
        PlayerPrefs.SetString("potionEffect",potionEffect.ToString());
        PlayerPrefs.SetString("potionTimer",potionTimer.ToString());

        PlayerPrefs.SetString("seasonAngle",seasonAngle.ToString());

        //3rd row upgrade saves

        PlayerPrefs.SetString("weedWhackerCost",weedWhackerCost.ToString());
        PlayerPrefs.SetString("weedWhackerPower",weedWhackerPower.ToString());
        PlayerPrefs.SetInt("weedWhackerLevel",weedWhackerLevel);

        PlayerPrefs.SetString("weedWhackerUpgradeCost",weedWhackerUpgradeCost.ToString());
        PlayerPrefs.SetString("weedWhackerUpgradePower",weedWhackerUpgradePower.ToString());
        PlayerPrefs.SetInt("weedWhackerUpgradeLevel",weedWhackerUpgradeLevel);

        PlayerPrefs.SetString("slugCost",slugCost.ToString());
        PlayerPrefs.SetString("slugPower",slugPower.ToString());
        PlayerPrefs.SetInt("slugLevel",slugLevel);

        PlayerPrefs.SetString("slugUpgradeCost",slugUpgradeCost.ToString());
        PlayerPrefs.SetString("slugUpgradePower",slugUpgradePower.ToString());
        PlayerPrefs.SetInt("slugUpgradeLevel",slugUpgradeLevel);

        
    }
    */

    public void Update()
    {
        //determines how much glucose you get from selling the plant
        data.glucoseToGet=150*(Sqrt(data.leaves/1e7));
        glucoseToGetText.text="Sell Plant:\n+"+ Floor(data.glucoseToGet).ToString("F0") + "Glucose";

        //displays how much glucose the user has
        glucoseText.text="Glucose: "+NotationMethod(data.glucose,"F0");


        if(40<data.waterLevel&&data.waterLevel<60)
        {
            data.waterFactor=2;
        }
        else if(data.waterLevel<=40)
        {
            data.waterFactor=(1*(1-(0.4-data.waterLevel/100)));
        }
        else
        {
            data.waterFactor=(1*(1-(data.waterLevel/100-0.6)));
        }
        if(40<data.sunlightLevel&&data.sunlightLevel<60)
        {
            data.sunlightFactor=2;
        }
        else if(data.sunlightLevel<=40)
        {
            data.sunlightFactor=(1*(1-(0.4-data.sunlightLevel/100)));
        }
        else
        {
            data.sunlightFactor=(1*(1-(data.sunlightLevel/100-0.6)));
        }
        data.bugFactor=1-((double)data.bugLevel/20);

        data.modifierFactor=data.bugFactor*data.waterFactor*data.sunlightFactor;
        //calculates how many leaves are being created every second
        data.leavesPerSecond = (data.potionEffect)*(data.modifierFactor)*(data.productionUpgrade1Level*(1+data.fertilizerLevel)+data.productionUpgrade2Power*(1+data.sprinklerLevel)*data.productionUpgrade2Level+data.slugPower*data.slugLevel*(1+data.slugUpgradeLevel));


        //exponent text boxes   
        clickValueText.text = "Click\n+" + NotationMethod(data.leavesClickValue*data.modifierFactor*data.seasonClickBonus,"F1") +" leaves";
        leavesText.text = NotationMethodBigNum(data.leaves,"F0");
        leavesPerSecText.text= NotationMethod(data.leavesPerSecond,"F0");
        clickUpgrade1Text.text="Buy Watering Can\nCost: "+NotationMethod(data.clickUpgrade1Cost,"F0")+ " leaves\nPower: +"+(data.wateringCanLevel+1)+ " Click\nLevel: "+ NotationMethod(data.clickUpgrade1Level,"F0");
        clickUpgrade2Text.text="Buy Gloves\nCost: "+NotationMethod(data.clickUpgrade2Cost,"F0")+ " leaves\nPower: +"+(10*(1+data.glovesLevel))+ " Click\nLevel: "+ NotationMethod(data.clickUpgrade2Level,"F0");
        productionUpgrade1Text.text="Buy Fertilizer\nCost: "+NotationMethod(data.productionUpgrade1Cost,"F0")+ " leaves\nPower: +"+(1+data.fertilizerLevel)+" leaves/s\nLevel: "+ NotationMethod(data.productionUpgrade1Level,"F0");
        productionUpgrade2Text.text="Buy Sprinkler\nCost: "+NotationMethod(data.productionUpgrade2Cost,"F0")+ " leaves\nPower: +"+data.productionUpgrade2Power*(1+data.sprinklerLevel) +" leaves/s\nLevel: "+ NotationMethod(data.productionUpgrade2Level,"F0");

        //glucose upgrades text boxes

        wateringCanText.text="Watering Can Upgrade\nCost: "+data.wateringCanCost.ToString("F0")+" glucose\nIncreases the effectiveness of Watering Cans by +"+data.wateringCanPower +" click\nLevel: "+ data.wateringCanLevel;
        fertilizerText.text="Fertilizer Upgrade\nCost: "+data.fertilizerCost.ToString("F0")+" glucose\nIncreases the effectiveness of Fertilizer by +"+data.fertilizerPower +" leaves/s\nLevel: "+ data.fertilizerLevel;
        glovesText.text="Gloves Upgrade\nCost: "+data.glovesCost.ToString("F0")+" glucose\nIncreases the effectiveness of Gloves by +"+data.glovesPower +" click\nLevel: "+ data.glovesLevel;
        sprinklerText.text="Sprinkler Upgrade\nCost: "+data.sprinklerCost.ToString("F0")+" glucose\nIncreases the effectiveness of Sprinklers by +"+data.sprinklerPower +" leaves/s\nLevel: "+ data.sprinklerLevel;

        //3rd row upgrades text boxes
        weedWhackerText.text="Buy Weed Whacker\nCost: "+NotationMethod(data.weedWhackerCost,"F0")+" leaves\nPower: +"+data.weedWhackerPower*(1+data.weedWhackerUpgradeLevel)+" Click\nLevel: "+ NotationMethod(data.weedWhackerLevel,"F0");
        weedWhackerUpgradeText.text="Weed WhackerUpgrade\nCost: "+NotationMethod(data.weedWhackerUpgradeCost,"F0")+" glucose\nIncreases the effectiveness of Watering Cans by +"+data.weedWhackerUpgradePower+" Click\nLevel: "+ NotationMethod(data.weedWhackerUpgradeLevel,"F0");
        slugText.text="Buy Slugs\nCost: "+NotationMethod(data.slugCost,"F0")+" leaves\nPower: +"+data.slugPower*(1+data.slugUpgradeLevel)+" Leaves/s\nLevel: "+ NotationMethod(data.slugLevel,"F0");
        slugUpgradeText.text="Upgrade Slugs\nCost: "+NotationMethod(data.slugUpgradeCost,"F0")+" glucose\nIncreases the effectiveness of Slugs by +"+data.slugUpgradePower+" Leaves/s\nLevel: "+ NotationMethod(data.slugUpgradeLevel,"F0");


        //potions text boxes

        redPotionText.text="Red Potion\nCost: "+NotationMethod(data.redPotionCost,"F0")+" leaves\nEffect: 1.1x leaves/s for 1 minute\n"+"Amount owned: "+data.redPotionAmount;
        bluePotionText.text="Blue Potion\nCost: "+NotationMethod(data.bluePotionCost,"F0")+" leaves\nEffect: 1.5x leaves/s for 5 minutes\n"+"Amount owned: "+data.bluePotionAmount;
        greenPotionText.text="Green Potion\nCost: "+NotationMethod(data.greenPotionCost,"F0")+" leaves\nEffect: 2.0x leaves/s for 10 minutes\n"+"Amount owned: "+data.greenPotionAmount;
        purplePotionText.text="Purple Potion\nCost: "+NotationMethod(data.purplePotionCost,"F0")+" leaves\nEffect: 3.0x leaves/s for 15 minutes\n"+"Amount owned: "+data.purplePotionAmount;
        orangePotionText.text="Orange Potion\nCost: "+NotationMethod(data.orangePotionCost,"F0")+" leaves\nEffect: 5.0x leaves/s for 30 minutes\n"+"Amount owned: "+data.orangePotionAmount;
        mysteryPotionText.text="Mystery Potion\nCost: "+NotationMethod(data.mysteryPotionCost,"F0")+" leaves\nEffect: 10.0x leaves/s for 60 minutes\n"+"Amount owned: "+data.mysteryPotionAmount;

        redInvText.text="Use Red Potion\nAmount: "+data.redPotionAmount;
        blueInvText.text="Use Blue Potion\nAmount: "+data.bluePotionAmount;
        greenInvText.text="Use Green Potion\nAmount: "+data.greenPotionAmount;
        purpleInvText.text="Use Purple Potion\nAmount: "+data.purplePotionAmount;
        orangeInvText.text="Use Orange Potion\nAmount: "+data.orangePotionAmount;
        mysteryInvText.text="Use Mystery Potion\nAmount: "+data.mysteryPotionAmount;

        data.leaves += data.leavesPerSecond * Time.deltaTime;
        if(data.waterLevel>0)
        {
            data.waterLevel -= 1*Time.deltaTime;
        }
        if(data.waterLevel/100<0.01)
        {
            waterBar.fillAmount=0;
        }
        else if(data.waterLevel/100>10)
        {
            waterBar.fillAmount=1;
        }
        else
        {
            waterBar.fillAmount=(float)data.waterLevel/100;
        }
        waterText1.text=" Water:";
        waterText2.text=System.Math.Ceiling(data.waterLevel*2).ToString()+"/200 ";


        if(data.sunlightLevel>0)
        {
            data.sunlightLevel -= 1*Time.deltaTime;
        }
        if(data.sunlightLevel/100<0.01)
        {
            sunlightBar.fillAmount=0;
        }
        else if(data.waterLevel/100>10)
        {
            sunlightBar.fillAmount=1;
        }
        else
        {
            sunlightBar.fillAmount=(float)data.sunlightLevel/100;
        }
        sunlightText1.text=" Sunlight:";
        sunlightText2.text=System.Math.Ceiling(data.sunlightLevel*2).ToString()+"/200 ";

        
        data.bugChance=UnityEngine.Random.Range(0,10000);
        if(data.bugChance<5&&data.bugLevel<5)
        {
           data.bugLevel++;
        }
        bugBar.fillAmount=(float)data.bugLevel/5;
        bugText1.text=" Bugs:";
        bugText2.text=data.bugLevel.ToString()+"/5 ";

        if(data.potionTimer>1)
        {
            data.potionTimer-=Time.deltaTime;
        }
        else if(1>data.potionTimer&&data.potionTimer>0)
        {
            data.potionTimer=0;
            data.potionEffect=1.0;
        }
        potionText.text="Potion Time: "+Ceiling(data.potionTimer)+"\nPotion Effect: "+data.potionEffect+"x leaves/s";

        //season calcs
        if(359>data.seasonAngle&&data.seasonAngle>=0)
        {
            data.seasonAngle+=Time.deltaTime;
        }
        if(data.seasonAngle>359)
        {
            data.seasonAngle=0;
        }

        vector=new Vector3((float)0.0,(float)0.0,(float)data.seasonAngle);
        seasonWheel.transform.eulerAngles=vector;
        
        string seasonString="";
        if(0<=data.seasonAngle&&data.seasonAngle<90)
        {
            data.seasonClickBonus=1.1;
            seasonString="Spring";
        }
        else if(data.seasonAngle<180)
        {
            data.seasonClickBonus=1.25;
            seasonString="Summer";
        }
        else if(data.seasonAngle<270)
        {
            data.seasonClickBonus=0.9;
            seasonString="Fall";
        }
        else
        {
            data.seasonClickBonus=0.75;
            seasonString="Winter";
        }
        seasonText.text="Season: "+seasonString+"\n"+data.seasonClickBonus+"x modifier to clicks";
        if(saveTime<60)
        {
            saveTime+=Time.deltaTime*(1/Time.timeScale);
        }
        else
        {
            saveData();
            saveTime=0;
        }
    }

    public void saveData()
    {
        SaveSystem.SaveData<DataCollections>(data,"PlayerData");
    }

    public string NotationMethod(BigDouble cost, string y)
    {
        if(cost >= 100000)
        {
            var exponent = Floor(Log10(Abs(cost)));
            var mantissa = cost/ Pow(10,exponent);
            return mantissa.ToString("F2")+"e"+exponent;
        }
        return cost.ToString(y);
    }

    public string NotationMethod(double cost, string y)
    {
        if(cost >= 100000)
        {
            var exponent = System.Math.Floor(System.Math.Log10(System.Math.Abs(cost)));
            var mantissa = cost/ System.Math.Pow(10,exponent);
            return mantissa.ToString("F2")+"e"+exponent;
        }
        return cost.ToString(y);
    }

    public string NotationMethodBigNum(double cost, string y)
    {
        if(cost >= 100000000000)
        {
            var exponent = System.Math.Floor(System.Math.Log10(System.Math.Abs(cost)));
            var mantissa = cost/ System.Math.Pow(10,exponent);
            return mantissa.ToString("F2")+"e"+exponent;
        }
        return cost.ToString(y);
    }

    public string NotationMethodBigNum(BigDouble cost, string y)
    {
        if(cost >= 100000000000)
        {
            var exponent = Floor(Log10(Abs(cost)));
            var mantissa = cost/ Pow(10,exponent);
            return mantissa.ToString("F2")+"e"+exponent;
        }
        return cost.ToString(y);
    }
        public string NotationMethod(float cost, string y)
    {
        if(cost >= 100000)
        {
            var exponent = Mathf.Floor(Mathf.Log10(Mathf.Abs(cost)));
            var mantissa = cost/ Mathf.Pow(10,exponent);
            return mantissa.ToString("F2")+"e"+exponent;
        }
        return cost.ToString(y);
    }




    //sell plant
    public void sellPlant()
    {
        if (data.leaves>1000)
        {
            data.leaves= 0;
            data.leavesClickValue= 1;
            data.clickUpgrade1Cost= 10;
            data.clickUpgrade2Cost= 100;
            data.productionUpgrade1Cost= 25;
            data.productionUpgrade2Cost= 250;
            data.productionUpgrade2Power= 5;

            data.clickUpgrade1Level = 0;
            data.clickUpgrade2Level = 0;
            data.productionUpgrade1Level = 0;
            data.productionUpgrade2Level = 0;

            data.glucose+=data.glucoseToGet;
            data.redPotionAmount=0;
            data.bluePotionAmount=0;
            data.greenPotionAmount=0;
            data.purplePotionAmount=0;
            data.orangePotionAmount=0;
            data.mysteryPotionAmount=0;
            data.redPotionCost=100;
            data.bluePotionCost=10000;
            data.greenPotionCost=1000000;
            data.purplePotionCost=100000000;
            data.orangePotionCost=10000000000;
            data.mysteryPotionCost=1000000000000;
            data.potionEffect=1;
            data.potionTimer=0;
            //reset 3rd row upgrade prices/level/etc
            data.weedWhackerLevel=0;
            data.weedWhackerCost=1000;
            data.weedWhackerUpgradeCost=1000;
            data.weedWhackerUpgradeLevel=0;
            data.slugLevel=0;
            data.slugCost=2500;
            data.slugUpgradeLevel=0;
            data.slugUpgradeCost=2500;
        }
    }



    // Buttons
    public void Click()
    {
        data.leaves+=data.leavesClickValue*(data.modifierFactor)*(data.seasonClickBonus);
    }

    public void BuyUpgrade(string upgradeID)
    {
        switch (upgradeID)
        {
            case "C1":
                if(data.leaves>=data.clickUpgrade1Cost)
                {
                    data.clickUpgrade1Level++;
                    data.leaves -= data.clickUpgrade1Cost;
                    data.clickUpgrade1Cost *=1.07;
                    data.leavesClickValue+= data.wateringCanLevel+1;
                }
                break;
            case "C2":
                if(data.leaves>=data.clickUpgrade2Cost)
                {
                    data.clickUpgrade2Level++;
                    data.leaves -= data.clickUpgrade2Cost;
                    data.clickUpgrade2Cost *=1.09;
                    data.leavesClickValue += 5*(1+data.glovesLevel);
                }
                break;

            case "P1":
                if(data.leaves>=data.productionUpgrade1Cost)
                {
                    data.productionUpgrade1Level++;
                    data.leaves -= data.productionUpgrade1Cost;
                    data.productionUpgrade1Cost *=1.07;

                }
                break;
            case "P2":
                if(data.leaves>=data.productionUpgrade2Cost)
                {
                    data.productionUpgrade2Level++;
                    data.leaves -= data.productionUpgrade2Cost;
                    data.productionUpgrade2Cost *=1.09;
            
                }
                break;
            case "BWC":
                if(data.glucose>=data.wateringCanCost)
                {
                    data.wateringCanLevel++;
                    data.glucose -= data.wateringCanCost;
                    data.wateringCanCost *=1.07;
                    data.leavesClickValue+=data.clickUpgrade1Level;
            
                }
                break;
            case "BF":
                if(data.glucose>=data.fertilizerCost)
                {
                    data.fertilizerLevel++;
                    data.glucose -= data.fertilizerCost;
                    data.fertilizerCost *=1.07;
                }
                break;
            case "BG":
                if(data.glucose>=data.glovesCost)
                {
                    data.glovesLevel++;
                    data.glucose -= data.glovesCost;
                    data.glovesCost *=1.07;
                    data.leavesClickValue+=data.clickUpgrade2Level;
                }
                break;
            case "BS":
                if(data.glucose>=data.sprinklerCost)
                {
                    data.sprinklerLevel++;
                    data.glucose -= data.sprinklerCost;
                    data.sprinklerCost *=1.07; 
                }
                break;

            case "BWW":
                if(data.leaves>=data.weedWhackerCost)
                {
                    data.weedWhackerLevel++;
                    data.leaves-=data.weedWhackerCost;
                    data.weedWhackerCost*=1.07;
                    data.leavesClickValue+=data.weedWhackerPower*(1+data.weedWhackerUpgradeLevel);
                }
                break;
            case "BSL":
                if(data.leaves>=data.slugCost)
                {
                    data.slugLevel++;
                    data.leaves-=data.slugCost;
                    data.slugCost*=1.07;
                }
                break;
            case "BWWU":
                if(data.glucose>=data.weedWhackerUpgradeCost)
                {
                    data.weedWhackerUpgradeLevel++;
                    data.glucose-=data.weedWhackerUpgradeCost;
                    data.weedWhackerUpgradeCost*=1.07;
                    data.leavesClickValue+=data.weedWhackerLevel;
                }
                break;
            case "BSLU":
                if(data.glucose>=data.slugUpgradeCost)
                {
                    data.slugUpgradeLevel++;
                    data.glucose-=data.slugUpgradeCost;
                    data.slugUpgradeCost*=1.07;
                }
                break;
        }
    }

    public void WaterPlants()
    {
        if(data.waterLevel<=95)
        {
            data.waterLevel+=5;
        }
        else
        {
            data.waterLevel=100;
        }
    }

    public void ProvideSunlight()
    {
        if(data.sunlightLevel<=95)
        {
            data.sunlightLevel+=5;
        }
        else
        {
            data.sunlightLevel=100;
        }
    }

    public void SquishBug()
    {
        if(data.bugLevel>0)
        {
            data.bugLevel--;
        }
    }

    public void ChangeScreens(string canvasID)
    {
        switch (canvasID)
        {
            case "MC":
            {
                CanvasGroupChanger(false, shopControllerGroup);
                CanvasGroupChanger(false, inventoryControllerGroup);
                CanvasGroupChanger(false, craftingControllerGroup);
                break;
            }
            case "SC":
            {
                CanvasGroupChanger(true, shopControllerGroup);
                CanvasGroupChanger(false, inventoryControllerGroup);
                CanvasGroupChanger(false, craftingControllerGroup);
                break;
            }
            case "IC":
            {
                CanvasGroupChanger(false, shopControllerGroup);
                CanvasGroupChanger(true, inventoryControllerGroup);
                CanvasGroupChanger(false, craftingControllerGroup);
                break;
            }
            case "CC":
            {
                CanvasGroupChanger(false, shopControllerGroup);
                CanvasGroupChanger(false, inventoryControllerGroup);
                CanvasGroupChanger(true, craftingControllerGroup);
                break;
            }

        }
    }

    public void CraftItem(string potionID)
    {
        switch(potionID)
        {
            case "RP":
            {
                if(data.leaves>=data.redPotionCost)
                {
                    data.redPotionAmount++;
                    data.leaves-=data.redPotionCost;
                    data.redPotionCost*=1.1;
                }
                break;
            }
            case "BP":
            {
                if(data.leaves>=data.bluePotionCost)
                {
                    data.bluePotionAmount++;
                    data.leaves-=data.bluePotionCost;
                    data.bluePotionCost*=1.1;
                }
                break;
            }
            case "GP":
            {
                if(data.leaves>=data.greenPotionCost)
                {
                    data.greenPotionAmount++;
                    data.leaves-=data.greenPotionCost;
                    data.greenPotionCost*=1.1;
                }
                break;
            }
            case "PP":
            {
                if(data.leaves>=data.purplePotionCost)
                {
                    data.purplePotionAmount++;
                    data.leaves-=data.purplePotionCost;
                    data.purplePotionCost*=1.1;
                }
                break;
            }
            case "OP":
            {
                if(data.leaves>=data.orangePotionCost)
                {
                    data.orangePotionAmount++;
                    data.leaves-=data.orangePotionCost;
                    data.orangePotionCost*=1.1;
                }
                break;
            }
            case "MP":
            {
                if(data.leaves>=data.mysteryPotionCost)
                {
                    data.mysteryPotionAmount++;
                    data.leaves-=data.mysteryPotionCost;
                    data.mysteryPotionCost*=1.1;
                }
                break;
            }
        }
    }

    public void usePotion(string potionIDs)
    {
        switch(potionIDs)
        {
            case "RP":
            {
                if(data.redPotionAmount>0)
                {
                    data.redPotionAmount-=1;
                    if(data.potionEffect==1.1)
                    {
                        data.potionTimer+=60;
                    }
                    else
                    {
                        data.potionEffect=1.1;
                        data.potionTimer=60;
                    }
                }
                break;
            }
            case "BP":
            {
                if(data.bluePotionAmount>0)
                {
                    data.bluePotionAmount-=1;
                    if(data.potionEffect==1.5)
                    {
                        data.potionTimer+=300;
                    }
                    else
                    {
                        data.potionEffect=1.5;
                        data.potionTimer=300;
                    }
                }
                break;
            }
            case "GP":
            {
                if(data.greenPotionAmount>0)
                {
                    data.greenPotionAmount-=1;
                    if(data.potionEffect==2.0)
                    {
                        data.potionTimer+=600;
                    }
                    else
                    {
                        data.potionTimer=600;
                        data.potionEffect=2.0;
                    }
                }
                break;
            }
            case "PP":
            {
                if(data.purplePotionAmount>0)
                {
                    data.purplePotionAmount-=1;
                    if(data.potionEffect==3.0)
                    {
                        data.potionTimer+=900;
                    }
                    else
                    {
                        data.potionEffect=3.0;
                        data.potionTimer=900;
                    }
                }
                break;
            }
            case "OP":
            {
                if(data.orangePotionAmount>0)
                {
                    data.orangePotionAmount-=1;
                    if(data.potionEffect==5.0)
                    {
                        data.potionTimer+=1800;
                    }
                    else
                    {
                        data.potionTimer=1800;
                        data.potionEffect=5.0;
                    }
                }
                break;
            }
            case "MP":
            {
                if(data.mysteryPotionAmount>0)
                {
                    data.mysteryPotionAmount-=1;
                    if(data.potionEffect==10.0)
                    {
                        data.potionTimer+=3600;
                    }
                    else
                    {
                        data.potionTimer=3600;
                        data.potionEffect=10.0;
                    }
                }
                break;
            }
        }
    }
    public void GoToSettings()
    {
        settings.gameObject.SetActive(true);
    }
    public void GoBackFromSettings()
    {
        settings.gameObject.SetActive(false);
    }

    public void FullReset()
    {
        data= new DataCollections();
    }
}
