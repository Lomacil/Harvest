using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Itemlist : MonoBehaviour {
    public Items items;

    Dictionary<int, Items.seeds> seeds = new Dictionary<int, Items.seeds>();
    Dictionary<int, Items.plants> plants = new Dictionary<int, Items.plants>();
    Dictionary<int, Items.fruits> fruits = new Dictionary<int, Items.fruits>();
    Dictionary<int, Items.tools> tools = new Dictionary<int, Items.tools>();   
	// Use this for initialization
	void Start () {
        
        callList();
	}

	void callList()
    {
        
        seeds.Add(1, new Items.seeds(1, "Grassamen", 1));
        seeds.Add(2, new Items.seeds(2, "Kartoffeln", 2));
        seeds.Add(3, new Items.seeds(3, "Möhrensetzlinge", 3));
        seeds.Add(4, new Items.seeds(4, "Zwiebeln", 4));
        seeds.Add(5, new Items.seeds(5, "Salatsetzlinge", 5));
        seeds.Add(6, new Items.seeds(6, "Roggenkörner", 6));
        seeds.Add(7, new Items.seeds(7, "Weizenkörner", 7));
        //seeds.Add(1, new Items.seeds(8, "", 8));
        plants.Add(1, new Items.plants(1, "Gras", 1, 1, 4, 16));
        plants.Add(2, new Items.plants(2, "Kartoffeln", 2, 2, 4, 16));
        plants.Add(3, new Items.plants(3, "Möhren", 3, 3, 4, 16));
        plants.Add(4, new Items.plants(4, "Zwiebeln", 4, 4, 4, 16));
        plants.Add(5, new Items.plants(5, "Salat", 5, 5, 4, 16));
        plants.Add(6, new Items.plants(6, "Roggen", 6, 6, 4, 16));
        plants.Add(7, new Items.plants(7, "Weizen", 7, 7, 4, 16));
        //plants.Add(8, new Items.plants(8, "", 8, 8, 4, 16));
        fruits.Add(1, new Items.fruits(1, "Heu", 1));
        fruits.Add(2, new Items.fruits(2, "Kartoffeln", 2));
        fruits.Add(3, new Items.fruits(3, "Möhren", 3));
        fruits.Add(4, new Items.fruits(4, "Zwiebeln", 4));
        fruits.Add(5, new Items.fruits(5, "Salat", 5));
        fruits.Add(6, new Items.fruits(6, "Roggen", 6));
        fruits.Add(7, new Items.fruits(7, "Weizen", 7));
        //fruits.Add(8, new Items.fruits(8, "", 8));
        tools.Add(1, new Items.tools(1, "Todesaxt des Zerschaufelns des Todes", 100,2,0,1.5f,0,0,0.5f));
        tools.Add(2, new Items.tools(2, "Todesaxt des Zerhackens des Todes", 100,0.5f,0.5f,1,3,0.5f,1));
        tools.Add(3, new Items.tools(3, "Todesaxt des Zerhämmerns des Todes", 100,0,1,0,0,0,4));
    }
    public Items.seeds getSeed(int ID)
    {
        return seeds[ID];
    }
    public Items.seeds cloneSeed(Items.seeds s)
    {
        Items.seeds ret = new Items.seeds(s.getID(), s.getName(), s.getCorPlant());
        return ret; 
    }
    public Items.plants getPlant(int ID)
    {
        return plants[ID];
    }
    public Items.plants clonePlant(Items.plants p)
    {
        Items.plants ret = new Items.plants(p.getID(),p.getName(),p.getCorSeed(),p.getCorFruit(),p.getStages(),p.getGrowTime());
        return ret;
    }
    public Items.fruits getFruit(int ID)
    {
        return fruits[ID];
    }
    public Items.fruits cloneFruit(Items.fruits f)
    {
        Items.fruits ret = new Items.fruits(f.getID(), f.getName(), f.getCorPlant());
        return ret;
    }
    public Items.tools getTool(int ID)
    {
        return tools[ID];
    }
    public Items.tools cloneTool(Items.tools t)
    {
        Items.tools ret = new Items.tools(t.getID(), t.getName(), t.getDur(),t.getPlowBonus(),t.getMiningBonus(),t.getHarvestBonus(),t.getWoodcutBonus(),t.getSawingBonus(),t.getHammeringBonus());
        return ret;
    }
    
    // Update is called once per frame
    void Update () {
	
	}
}
