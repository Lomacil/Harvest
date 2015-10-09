using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public class bag
    {
        public Itemlist list = GameObject.Find("wrldctrl").GetComponent<Itemlist>();
        int seedcnt = 1;
        int plantcnt = 1;
        int fruitcnt = 1;
        int toolcnt = 1;
        
        string curCategory ="";
        public int curItem =0;

        
        Dictionary<int, Items.seeds> seeds = new Dictionary<int, Items.seeds>();
        Dictionary<int, Items.plants> plants = new Dictionary<int, Items.plants>();
        Dictionary<int, Items.fruits> fruits = new Dictionary<int, Items.fruits>();
        Dictionary<int, Items.tools> tools = new Dictionary<int, Items.tools>();

        public string getCurCategory()
        {
            return curCategory;
        }
        public void addToInventory(Items.seeds seed,int amount)
        {
            Items.seeds s = null;
            bool found = false;
            if (seeds.Count == 0)
            {
                seeds.Add(seedcnt, list.cloneSeed(seed));
                seeds[seedcnt].addAmount(amount);
                seedcnt++;
            }
            else
            {
                foreach (KeyValuePair<int, Items.seeds> entry in seeds)
                {
                    if (entry.Value.getID() == seed.getID() && found == false)
                    {
                        s = entry.Value;
                        found = true;
                    }
                }
                if (found)
                {
                    s.addAmount(amount);
                }
                else
                {
                    seeds.Add(seedcnt, list.cloneSeed(seed));
                    seeds[seedcnt].addAmount(amount);
                    seedcnt++;
                }
            }
        }
        public void addToInventory(Items.plants plant, int amount)
        {
            Items.plants p = null;
            bool found = false;
            if (plants.Count == 0)
            {
                plants.Add(plantcnt, list.clonePlant(plant));
                plants[plantcnt].addAmount(amount);
                plantcnt++;
            }
            else
            {
                foreach (KeyValuePair<int, Items.plants> entry in plants)
                {
                    if (entry.Value.getID() == plant.getID()&&!found)
                    {
                        p = entry.Value;
                        found = true;
                    }
                }
                if(found)
                    p.addAmount(amount);
                else
                {
                    plants.Add(plantcnt, list.clonePlant(plant));
                    plants[plantcnt].addAmount(amount);
                    plantcnt++;
                }
            }
        }
        public void addToInventory(Items.fruits fruit, int amount)
        {
            bool found = false;
            if (fruits.Count == 0)
            {
                fruits.Add(fruitcnt, fruit);
                fruitcnt++;
            }
            else
            {
                foreach (KeyValuePair<int, Items.fruits> entry in fruits)
                {
                    if (entry.Value.getID() == fruit.getID()&&!found)
                    {
                        fruits[entry.Value.getID()].addAmount(amount);
                    }
                    else
                    {
                        fruits.Add(fruitcnt, list.cloneFruit(fruit));
                        fruitcnt++;
                    }
                }
            }
        }
        public void addToInventory(Items.tools tool)
        {   
            tools.Add(toolcnt, list.cloneTool(tool));
            toolcnt++;    
        }
        public string getNextItemCategory()
        {
            bool found = false;
            while (found == false)
            {
                switch (curCategory)
                {
                    case "seeds":
                        curCategory = "plants";
                        if (plants.Count > 0)
                            found = true;
                        break;
                    case "plants":
                        curCategory = "fruits";
                        if (fruits.Count > 0)
                            found = true;
                        break;
                    case "fruits":
                        curCategory = "tools";
                        if (tools.Count > 0)
                            found = true;
                        break;
                    case "tools":
                        curCategory = "hand";
                        found = true;
                        break;
                    case "hand":
                        curCategory = "seeds";
                        if (seeds.Count > 0)
                            found = true;
                        break;
                    default:
                        curCategory = "hand";
                        found = true;
                        return "hand";
                }
            }
            return curCategory;
        }
        public int getNextItem()
        {
            bool found = false;
            int cnt = 1;
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
                    while (!found)
                    {
                        if(seeds.ContainsKey(cnt))
                        {
                            found = true;
                            curItem = cnt;
                        }
                        else
                        {
                            cnt++;
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
                    while (!found)
                    {
                        if (plants.ContainsKey(cnt))
                        {
                            found = true;
                            curItem = cnt;
                        }
                        else
                        {
                            cnt++;
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
                    while (!found)
                    {
                        if (fruits.ContainsKey(cnt))
                        {
                            found = true;
                            curItem = cnt;
                        }
                        else
                        {
                            cnt++;
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
                    while (!found)
                    {
                        if (tools.ContainsKey(cnt))
                        {
                            found = true;
                            curItem = cnt;
                        }
                        else
                        {
                            cnt++;
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
        public Items.tools getSelectedTool() //returns null if not a tool
        {
            if(curCategory=="tools")
            {
                return tools[curItem];
            }
            else
            {
                return null;
            }
        }
        
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
