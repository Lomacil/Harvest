using UnityEngine;
using System.Collections;

public class tileproperties : MonoBehaviour {

    public int texChange=0;

    public Itemlist items;

    public Material groundTex;
    public Material plowedTex;
    public Material seedTex;
    public Material plantTex;
    public Material fruitTex;

    Items.seeds seed = null;
    Items.plants plant = null;
    Items.fruits fruit = null;

    bool plowed;
    bool plowable;
    bool plantable;
    bool planted;
    bool growing;
    bool harvestable;
    
    int water;

    public int ID = 10;
    public string test = "1";

    public bool getPlowed()
    { return plowed; }
    public void setPlowed(GameObject tile)
    {
        plowed = true;
        plantable = true;
        var rend = tile.GetComponent<Renderer>();
        rend.material = plowedTex;
    }
    public bool getPlowable()
    { return plowable; }
    public bool getPlanted()
    { return planted; }
    public bool getPlantable()
    {
        return plantable;
    }
    public int get_seedID()
    { if (planted)
        {
            return seed.getID();
        }
        else { return 0; }
    }
    public int get_plantID()
    {
        if(growing)
        {
            return plant.getID();
        }
        else{ return 0; }
    }
    public int get_fruitID()
    {
        if(harvestable)
        {
            return fruit.getID();
        }
        else { return 0; }
    }

    public void setSeed(Items.seeds seedToSet)
    {
        seed = items.cloneSeed(seedToSet);
        var rend = gameObject.GetComponent<Renderer>();
        rend.material = seedTex;
    }
    public void setPlant(Items.plants plantToSet)
    {
        plant = items.clonePlant(plantToSet);
        var rend = gameObject.GetComponent<Renderer>();
        rend.material = plantTex;
        planted = true;
        seed = null;
    }
    public void setFruit(Items.fruits fruitToSet)
    {
        fruit = items.cloneFruit(fruitToSet);
    }
	// Use this for initialization
	void Start () {
        planted = false;
        plantable = false;

        plowedTex = Resources.Load("Materials/plowed") as Material;
        items = GameObject.Find("wrldctrl").GetComponent<Itemlist>();

        var rend = gameObject.GetComponent<Renderer>();
        rend.enabled = true;
        rend.material = plantTex;
        initPlant(1);
        plowable = true;
	}
    void initPlant(int ID)
    {
        setSeed(items.getSeed(ID));
        setPlant(items.getPlant(ID));
    }
    public void grow()
    {
        if(seed!=null)
        {
            setPlant(items.getPlant(seed.getCorPlant()));
        }
        else
        {
            if(plant!=null)
            {
                if(plant.getCurStage()<plant.getStages())
                    plant.incCurStage(1);
                else
                {
                    setFruit(items.getFruit(plant.getCorFruit()));
                }
            }
        }
    }
    // Update is called once per frame
    void Update () {
	    
	}
}
