using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Itemlist : MonoBehaviour {
    public Items items;

    Dictionary<int, Items.seeds> seeds = new Dictionary<int, Items.seeds>();
    Dictionary<int, Items.plants> plants = new Dictionary<int, Items.plants>();
    Dictionary<int, Items.fruits> fruits = new Dictionary<int, Items.fruits>();    
	// Use this for initialization
	void Start () {
        callList();
	}
	void callList()
    {
        seeds.Add(1, new Items.seeds(1, "Grasseed", 1));
        plants.Add(1, new Items.plants(1, "Grass", 1, 1, 4, 16));
        fruits.Add(1, new Items.fruits(1, "Hay", 1));
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
    // Update is called once per frame
    void Update () {
	
	}
}
