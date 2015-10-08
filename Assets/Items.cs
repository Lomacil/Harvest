using UnityEngine;
using System.Collections;

public class Items : MonoBehaviour {


    public class seeds : Items
    {
        int seedID;
        string seedName;
        int corPlantID;
        int amount = 1;
        public seeds(int ID,string name,int plantID)
        {
            seedID = ID;
            seedName = name;
            corPlantID = plantID;
        }
        public int getID()
        {
            return seedID;
        }
        public string getName()
        {
            return seedName;
        }
        public int getCorPlant()
        {
            return corPlantID;
        }
        public int getAmount()
        {
            return amount;
        }
        public void addAmount(int nr)
        {
            amount = amount + nr;
        }
    }

    public class plants
    {
        int plantID;
        string plantName;
        int corSeedID;
        int corFruitID;
        int growingStages;
        int hoursToGrow;
        int amount = 1;
        int currentStage = 0;
        Texture firstStageTex;
        Texture otherStagesTex;
        Texture finalStageTex;
        Texture wildGrowthTex;

        public plants(int ID, string name, int SeedID, int FruitID, int stages, int growingTime)
        {
            plantID = ID;
            plantName = name;
            corSeedID = SeedID;
            corFruitID = FruitID;
            growingStages = stages;
            hoursToGrow = growingTime;
        }
        public int getID()
        {
            return plantID;
        }
        public string getName()
        {
            return plantName;
        }
        public int getCorSeed()
        {
            return corSeedID;
        }
        public int getCorFruit()
        {
            return corFruitID;
        }
        public int getStages()
        {
            return growingStages;
        }
        public int getGrowTime()
        {
            return hoursToGrow;
        }
        public void addAmount(int nr)
        {
            amount = amount + nr;
        }
        public int getAmount()
        {
            return amount;
        }
        public int getCurStage()
        {
            return currentStage;
        }
        public void incCurStage(int amount)
        {
            currentStage += amount;
        }
    }
    
    public class fruits
    {
        int fruitID;
        string fruitName;
        int corPlantID;
        int amount;

        public fruits(int ID, string name,int plantID)
        {
            fruitID = ID;
            fruitName = name;
            corPlantID = plantID;
        }
        public int getID()
        {
            return fruitID;
        }
        public void addAmount(int nr)
        {
            amount = amount + nr;
        }
        public int getAmount()
        {
            return amount;
        }
        public string getName()
        {
            return fruitName;
        }
        public int getCorPlant()
        {
            return corPlantID;
        }
    }
    public class tools
    {
        int toolID;
        float durability;
        string toolName;
        float plowBonus = 0;
        float miningBonus = 0;
        float harvestBonus = 0;
        float woodcutingBonus = 0;

        public tools(int ID, string name, float dura)
        {
            toolID = ID;
            toolName = name;
            durability = dura;

        }
        public void setBoni(float plow, float harvest, float mining, float woodcut)
        {
            plowBonus = plow;
            harvestBonus = harvest;
            miningBonus = mining;
            woodcutingBonus = woodcut;
        }
        public int getID()
        {
            return toolID;
        }
        public string getName()
        {
            return toolName;
        }
    }

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
