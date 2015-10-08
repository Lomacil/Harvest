using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public worldgenerator world;
    float movingSpeed;
    float runningSpeed;
    float currentSpeed;
    string lastDirection;
    bool running;
    public string t;

    public void setSpeed(float speed)
    {
        movingSpeed = speed;
    }
	// Use this for initialization
	void Start () {
        lastDirection = "east";
        movingSpeed = 1;
        runningSpeed = 2;
        currentSpeed = movingSpeed;
        running = false;
        world = GameObject.Find("wrldctrl").GetComponent<worldgenerator>();
	}
	public string getLastDirection()
    {
        return lastDirection;
    }
    
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("left shift"))
        {
            currentSpeed = runningSpeed;
            running = true;
        }
        if(Input.GetKeyUp("left shift"))
        {
            currentSpeed = movingSpeed;
            running = false;
        }
        if (Input.GetKey("a") && world.getClosestTileToDirection(transform.position, "west")!=null)
        {
            gameObject.transform.Translate(new Vector2(-1, 0) * Time.deltaTime*currentSpeed);
            lastDirection = "west";
            t = world.getClosestTile(gameObject).tag.ToString();
        }
        if (Input.GetKey("d") && world.getClosestTileToDirection(transform.position, "east")!=null)
        {
            gameObject.transform.Translate(new Vector2(1, 0) * Time.deltaTime * currentSpeed);
            lastDirection = "east";
        }
        if (Input.GetKey("w")&&world.getClosestTileToDirection(transform.position,"north")!=null)
        {
            gameObject.transform.Translate(new Vector2(0, 1) * Time.deltaTime * currentSpeed);
            lastDirection = "north";
        }
        if (Input.GetKey("s") && world.getClosestTileToDirection(transform.position, "south")!=null)
        {
            gameObject.transform.Translate(new Vector2(0, -1) * Time.deltaTime * currentSpeed);
            lastDirection = "south";
        }


    }
}
