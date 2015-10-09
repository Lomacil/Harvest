using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actionctrl : MonoBehaviour {

    public worldgenerator world;
    public Inventory inv;
    public Itemlist list;
    public Items selectedItem;
    public Inventory.bag bag;
    public GUIoverlay overlay;
    public string curCategory;
    public Items.tools curTool;
    public int curItem;
    bool progress;
    // Use this for initialization
    void Start () {
        world = GameObject.Find("wrldctrl").GetComponent<worldgenerator>();
        inv = GameObject.Find("wrldctrl").GetComponent<Inventory>();
        list = GameObject.Find("wrldctrl").GetComponent<Itemlist>();
        bag = new Inventory.bag();
        overlay = GameObject.Find("wrldctrl").GetComponent<GUIoverlay>();
        progress = false;
        initInventory();
        
	}
	void initInventory()
    {
        bag.addToInventory(list.getSeed(2), 5);
        bag.addToInventory(list.getSeed(3), 6);
        bag.addToInventory(list.getSeed(4), 7);
        bag.addToInventory(list.getPlant(5),4);
        bag.addToInventory(list.getFruit(3),2);
        bag.addToInventory(list.getTool(1));
        bag.addToInventory(list.getTool(2));
        bag.addToInventory(list.getTool(3));
    }
	// Update is called once per frame
	void Update ()
    {
        if (!progress)
        {
            if (Input.GetKeyDown("f"))
            {
                plow();
            }
            if (Input.GetKeyDown("y"))
            {
                curCategory = bag.getNextItemCategory();
                overlay.setCategory(curCategory);
            }
            if (Input.GetKeyDown("x"))
            {
                curItem = bag.getNextItem();
                overlay.setCurItem(curItem);
                overlay.setCurItemName(bag.getName(curItem));
            }
            if(Input.GetKeyDown("v"))
            {
                plant(curItem);
            }
            if(Input.GetKeyDown("enter"))
            {
                progress = true;
                bool down = true;
                while(down == true)
                {
                    if (GameObject.Find("Directional light").GetComponent<Light>().intensity > 0)
                        GameObject.Find("Directional light").GetComponent<Light>().intensity -= Time.deltaTime;
                    else
                        down = false;
                }
                
                foreach(KeyValuePair<long,GameObject> entry in world.tilelog)
                {
                    entry.Value.GetComponent<tileproperties>().grow();
                }
                bool up = true;
                while(up == true)
                {
                    if (GameObject.Find("Directional light").GetComponent<Light>().intensity < 1)
                        GameObject.Find("Directional light").GetComponent<Light>().intensity += Time.deltaTime;
                    else
                        up = false;
                }
                progress = false;
            }
        }
        else
        {
            if(Input.GetKeyDown("esc"))
            {
                //cancel current action
            }
        }
	}
    void plow()
    {
        curTool = bag.getSelectedTool();
        if (curTool != null)
        {
            GameObject tile = world.getClosestTile(gameObject);
            tileproperties prop = tile.GetComponent<tileproperties>();
            overlay.info = curTool.getPlowBonus().ToString();
            if (curTool.getPlowBonus() > 0&& !prop.getPlowed() && prop.getPlowable())
            {
                progress = true;
                overlay.castbar(workTime(bag.getSelectedTool().getPlowBonus()));
                prop.setPlowed(tile);
                progress = false;
            }
        }
    }
    void plant(int ID)
    {
        if(bag.getCurCategory()=="seeds"&&bag.getSelectedSeed()!=null)
        {
            GameObject tile = world.getClosestTile(gameObject);
            tileproperties prop = tile.GetComponent<tileproperties>();
            if(!prop.getPlanted()&&prop.getPlantable())
            {
                prop.setSeed(bag.getSelectedSeed());
            }
        }
    }
    float workTime(float multi)
    {
        float time = 0;
        if (multi != 0)
        {
            time = 10 / multi;
        }
        else
        {
            time = 0;
        }
        return time;
    }
    public string getItemName(int ID)
    {
        return bag.getName(ID);
    }

}
