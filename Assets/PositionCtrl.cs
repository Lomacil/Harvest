using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PositionCtrl : MonoBehaviour {
    Movement move;
    worldgenerator world;

    GameObject closestTile;
    GameObject closestTileToDirection;
    string curDirection;

    public void setDirectin(string dir)
    {
        curDirection = dir;
    }
    

    
	// Use this for initialization
	void Start () {
        move = GameObject.Find("Player").GetComponent<Movement>();
        world = gameObject.GetComponent<worldgenerator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
