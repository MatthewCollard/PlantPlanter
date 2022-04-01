using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BreakInfinity;

[Serializable]
public class DataCollections
{
    
    public BigDouble leaves;
    public BigDouble leavesClickValue;
    public BigDouble leavesPerSecond;
    public BigDouble clickUpgrade1Cost;
    public int clickUpgrade1Level;
    public BigDouble productionUpgrade1Cost;
    public int productionUpgrade1Level;
    public BigDouble clickUpgrade2Cost;
    public int clickUpgrade2Level;
    public BigDouble productionUpgrade2Cost;
    public BigDouble productionUpgrade2Power;
    public int productionUpgrade2Level;
    public BigDouble glucose;
    public BigDouble glucoseToGet;
    public BigDouble wateringCanCost;
    public BigDouble wateringCanPower;
    public int wateringCanLevel;
    public BigDouble fertilizerCost;
    public BigDouble fertilizerPower;
    public int fertilizerLevel;
    public BigDouble sprinklerCost;
    public BigDouble sprinklerPower;
    public int sprinklerLevel;
    public BigDouble glovesCost;
    public BigDouble glovesPower;
    public int glovesLevel;
    public double waterLevel;
    public BigDouble waterFactor;
    public double sunlightLevel;
    public BigDouble sunlightFactor;
    public int bugLevel;
    public BigDouble bugFactor;
    public BigDouble modifierFactor;
    public BigDouble bugChance;
    public int redPotionAmount;
    public int bluePotionAmount;
    public int greenPotionAmount;
    public int purplePotionAmount;
    public int orangePotionAmount;
    public int mysteryPotionAmount;
    public BigDouble redPotionCost;
    public BigDouble bluePotionCost;
    public BigDouble greenPotionCost;
    public BigDouble purplePotionCost;
    public BigDouble orangePotionCost;
    public BigDouble mysteryPotionCost;
    public BigDouble potionTimer;
    public BigDouble potionEffect;
    public double seasonAngle;
    public BigDouble seasonClickBonus;
    public int weedWhackerLevel;
    public BigDouble weedWhackerCost;
    public BigDouble weedWhackerPower;
    public int slugLevel;
    public BigDouble slugCost;
    public BigDouble slugPower;
    public int weedWhackerUpgradeLevel;
    public BigDouble weedWhackerUpgradeCost;
    public BigDouble weedWhackerUpgradePower;
    public int slugUpgradeLevel;
    public BigDouble slugUpgradeCost;
    public BigDouble slugUpgradePower;

    public DataCollections()
    {
        FullReset();
    }
    
    public void FullReset()
    {
        leaves=0;
        glucose=0;
        leavesClickValue=1;
        clickUpgrade1Cost=10;
        clickUpgrade2Cost=100;
        productionUpgrade1Cost=25;
        productionUpgrade2Cost=250;
        productionUpgrade2Power=10;
        wateringCanCost=10;
        fertilizerCost=10;
        glovesCost=100;
        sprinklerCost=250;
        wateringCanPower=1;
        fertilizerPower=1;
        glovesPower=10;
        sprinklerPower=10;
        clickUpgrade1Level=0;
        clickUpgrade2Level=0;
        productionUpgrade1Level=0;
        productionUpgrade2Level=0;
        wateringCanLevel=0;
        fertilizerLevel=0;
        glovesLevel=0;
        sprinklerLevel=0;
        waterLevel=100;
        sunlightLevel=100;
        bugLevel=0;
        redPotionAmount=0;
        bluePotionAmount=0;
        greenPotionAmount=0;
        purplePotionAmount=0;
        orangePotionAmount=0;
        mysteryPotionAmount=0;
        redPotionCost=0;
        bluePotionCost=0;
        greenPotionCost=0;
        purplePotionCost=0;
        orangePotionCost=0;
        mysteryPotionCost=0;
        potionEffect=1;
        potionTimer=0;
        seasonAngle=0;
        weedWhackerCost=1000;
        weedWhackerPower=100;
        weedWhackerLevel=0;
        weedWhackerUpgradeCost=1000;
        weedWhackerPower=100;
        weedWhackerLevel=0;
        slugCost=2500;
        slugPower=100;
        slugLevel=0;
        slugUpgradeCost=2500;
        slugUpgradePower=100;
        slugUpgradeLevel=0;
    }

}