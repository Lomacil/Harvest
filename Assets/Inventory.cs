using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public class bag
    {
        int seedcnt = 1;
        int plantcnt = 1;
        int fruitcnt = 1;
        int toolcnt = 1;
        string curCategory;
        public int curItem;

        public int test;
        Dictionary<int, Items.seeds> seeds = new Dictionary<int, Items.seeds>();
        Dictionary<int, Items.plants> plants = new Dictionary<int, Items.plants>();
        Dictionary<int, Items.fruits> fruits = new Dictionary<int, Items.fruits>();
        Dictionary<int, Items.tools> tools = new Dictionary<int, Items.tools>();
        
        public void addToInventory(Items.seeds seed,int amount)
        {
            if (seeds.Count == 0)
            {
                seeds.Add(seedcnt, seed);
                seedcnt++;
            }
            else
            {
                foreach(KeyValuePair<int, Items.seeds> entry in seeds)
                {
                    if(entry.Value.getID()==seed.getID())
                    {
                        seeds[entry.Value.getID()].addAmount(amount);
                    }
                }
            }
        }
        public void addToInventory(Items.plants plant, int amount)
        {
            if (plants.Count == 0)
            {
                plants.Add(plantcnt, plant);
                plantcnt++;
            }
            else
            {
                foreach (KeyValuePair<int, Items.plants> entry in plants)
                {
                    if (entry.Value.getID() == plant.getID())
                    {
                        seeds[entry.Value.getID()].addAmount(amount);
                    }
                }
            }
        }
        public void addToInventory(Items.fruits fruit, int amount)
        {
            if (fruits.Count == 0)
            {
                fruits.Add(fruitcnt, fruit);
                fruitcnt++;
            }
            else
            {
                foreach (KeyValuePair<int, Items.fruits> entry in fruits)
                {
                    if (entry.Value.getID() == fruit.getID())
                    {
                        fruits[entry.Value.getID()].addAmount(amount);
                    }
                }
            }
        }
        public void addToInventory(Items.tools tool)
        {   
            tools.Add(toolcnt, tool);
            toolcnt++;    
        }
        public string getNextItemCategory()
        {
            switch (curCategory)
            {
                case "seeds":
                    test = plants.Count;
                    curCategory = "plants";
                    if (plants.Count == 0)
                        getNextItemCategory();
                    else
                    {
                        curItem = 0;
                        return "plants";
                    }
                    return "plants";
                case "plants":
                    curCategory = "fruits";
                    if (fruits.Count == 0)
                        getNextItemCategory();
                    else
                    {
                        curItem = 0;
                        return "fruits";
                    }
                    return "fruits";
                case "fruits":
                    curCategory = "tools";
                    if (tools.Count == 0)
                        getNextItemCategory();
                    else
                    {
                        curItem = 0;
                        return "tools";
                    }
                    return "tools";
                case "tools":
                    curCategory = "hand";
                    return "hand";
                case "hand":
                    curCategory = "seeds";
                    if (seeds.Count == 0)
                        getNextItemCategory();
                    else
                    {
                        curItem = 0;
                        return "hand";
                    }
                    return "seeds";
                default:
                    curCategory = "hand";
                    return "hand";
            }
        }
        public int getNextItem()
        {
            bool found = false;
            switch (curCategory)
            {
                case "seeds":
                    foreach (KeyValuePair<int,Items.seeds>entry in seeds )
                    { 
                        if(entry.Key>curItem&&!found)
                        {
                            found = true;
                            curItem = entry.Key;
                        }
                    }
                    return curItem;
                case "plants":
                    foreach (KeyValuePair<int, Items.plants> entry in plants)
                    {
                        if (entry.Key > curItem && !found)
                        {
                            found = true;
                            curItem = entry.Key;
                        }
                    }
                    return curItem;
                case "fruits":
                    foreach (KeyValuePair<int, Items.fruits> entry in fruits)
                    {
                        if (entry.Key > curItem && !found)
                        {
                            found = true;
                            curItem = entry.Key;
                        }
                    }
                    return curItem;
                case "tools":
                    foreach (KeyValuePair<int, Items.tools> entry in tools)
                    {
                        if (entry.Key > curItem && !found)
                        {
                            found = true;
                            curItem = entry.Key;
                        }
                    }
                    return curItem;
                default:
                    return curItem;
            }
        }
        public string getName(int ID)
        {
            string name = "hand";
            switch (curCategory)
            {
                case "seeds":
                    name = seeds[ID].getName();
                    return name;
                case "plants":
                    name = plants[ID].getName();
                    return name;
                case "fruits":
                    name = fruits[ID].getName();
                    return name;
                case "tools":
                    name = tools[ID].getName();
                    return name;
                default:

                    return name;
            }
        }
        public void setCurCategory(string cat)
        {
            curCategory = cat;
        }
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
