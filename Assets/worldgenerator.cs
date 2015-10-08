using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class worldgenerator : MonoBehaviour {
    Dictionary<long, GameObject> tilelog = new Dictionary<long, GameObject>();
    int x = 10;
    int y = 10;
    int xcnt = 0;
    int ycnt = 0;
    long tilecnt = 0;
    string test = "1";
    int cnt = 1;
    public GameObject tile;
    GameObject closest = null;

	// Use this for initialization
	void Start () {
	    while(xcnt<x)
        {
            while(ycnt<y)
            {
                generateTile((float)xcnt, (float)ycnt);
                ycnt++;
            }
            ycnt = 0;
            xcnt++;
        }
	}
	
	// Update is called once per frame
	void OnGUI () {
        
    }
    public void generateTile(float x, float y)
    {
        GameObject newTile = Instantiate(tile, new Vector3(x, y, 0),new Quaternion(tile.transform.rotation.x, tile.transform.rotation.y, tile.transform.rotation.z, tile.transform.rotation.w)) as GameObject;
        tilelog.Add(tilecnt, newTile);
        tilecnt++;
    }
    public GameObject getClosestTile(GameObject obj)
    {
        GameObject closest = null;
        float dist = 10;
        foreach(KeyValuePair<long,GameObject> entry in tilelog)
        {
            if(Vector3.Distance(entry.Value.transform.position,obj.transform.position)<dist)
            {
                closest = entry.Value;
                dist = Vector3.Distance(entry.Value.transform.position, obj.transform.position);
            }
        }
        return closest;
    }
    public GameObject getClosestTileToDirection(Vector3 point, string dir)
    {
        closest = null;
        float dist = 10;
        if(dir=="north")
        {
            foreach(KeyValuePair<long,GameObject> entry in tilelog)
            {
                if ((Vector3.Distance(entry.Value.transform.position, point) < dist) && ( entry.Value.transform.position.y > point.y ))
                {
                    closest = entry.Value;
                    dist = Vector3.Distance(entry.Value.transform.position, point);
                }
            }
        }
        if (dir == "south")
        {
            foreach (KeyValuePair<long, GameObject> entry in tilelog)
            {
                if ((Vector3.Distance(entry.Value.transform.position, point) < dist) && (entry.Value.transform.position.y < point.y))
                {
                    closest = entry.Value;
                    dist = Vector3.Distance(entry.Value.transform.position, point);
                }
            }
        }
        if (dir == "west")
        {
            foreach (KeyValuePair<long, GameObject> entry in tilelog)
            {
                if ((Vector3.Distance(entry.Value.transform.position, point) < dist) && (entry.Value.transform.position.x < point.x))
                {
                    closest = entry.Value;
                    dist = Vector3.Distance(entry.Value.transform.position, point);
                }
            }
        }
        if (dir == "east")
        {
            foreach (KeyValuePair<long, GameObject> entry in tilelog)
            {
                if ((Vector3.Distance(entry.Value.transform.position, point) < dist) && (entry.Value.transform.position.x > point.x))
                {
                    closest = entry.Value;
                    dist = Vector3.Distance(entry.Value.transform.position, point);
                }
            }
        }
        return closest;
    }

}
