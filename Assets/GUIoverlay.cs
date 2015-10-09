using UnityEngine;
using System.Collections;

public class GUIoverlay : MonoBehaviour {
    public string amount;
    public string category;
    public int curItem;
    public string curName;
    bool casting;
    public Actionctrl bag;
    public string info = "";
	// Use this for initialization
    public void setCategory(string cat)
    {
        category = cat;
    }
    public void setCurItem(int item)
    {
        curItem = item;
    }
    public void setAmount(int curAmount)
    {
        amount = curAmount.ToString();
    }
    public void setCurItemName(string name)
    {
        curName = name;
    }
    public void castbar(float time)
    {
        float startTime = 0;
        casting = true;
        while (startTime<time)
        {
            startTime += Time.deltaTime;
        }
        casting = false;
    }
    void Start () {
        category = "tools";
        amount = "1";
        curItem = 1;
        curName = "hand";
        casting = false;
        bag = GameObject.Find("Player").GetComponent<Actionctrl>();
    }
	// Update is called once per frame
	void Update () {
        
	}
    void OnGUI ()
    {
        GUI.Label(new Rect(10, 10, 100, 30), category, "box");
        GUI.Label(new Rect(10, 50, 100, 30), curName, "box");
        GUI.Label(new Rect(120, 50, 30, 30), amount, "box");
        GUI.Label(new Rect(300, 500, 300, 30), info, "box");
        if(casting)
        {
            GUI.Label(new Rect(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y-10,20,5),"", "box");
        }
    }
}
