using UnityEngine;
using System.Collections;

public class Actionctrl : MonoBehaviour {

    public worldgenerator world;
    public Inventory inv;
    public Items selectedItem;
    Inventory.bag bag;
    public GUIoverlay overlay;
    public string curCategory;
    int curItem;
    // Use this for initialization
    void Start () {
        world = GameObject.Find("wrldctrl").GetComponent<worldgenerator>();
        inv = GameObject.Find("wrldctrl").GetComponent<Inventory>();
        bag = new Inventory.bag();
        overlay = GameObject.Find("wrldctrl").GetComponent<GUIoverlay>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown("f"))
        {
            plow();
        }
        if(Input.GetKeyDown("y"))
        {
            curCategory = bag.getNextItemCategory();
            overlay.setCategory(curCategory);
        }
        if(Input.GetKeyDown("x"))
        {
            curItem = bag.getNextItem();
            overlay.setCurItemName(bag.getName(curItem));
            overlay.setCurItem(curItem);
        }
	}
    void plow()
    {
        GameObject tile = world.getClosestTile(gameObject);
        tileproperties prop = tile.GetComponent<tileproperties>();
        if (!prop.getPlowed()&&prop.getPlowable())
        {
            prop.setPlowed(tile);
        }
    }

}
