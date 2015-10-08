using UnityEngine;
using System.Collections;

public class GUIoverlay : MonoBehaviour {
    public string amount;
    public string category;
    public int curItem;
    string curName;
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
    public void setCurItemName( string name)
    {
        curName = name;
    }
    void Start () {
        category = "tools";
        amount = "1";
        curItem = 0;
        curName = "hand";
        
    }
	// Update is called once per frame
	void Update () {
        
	}
    void OnGUI ()
    {
        GUI.Label(new Rect(10, 10, 100, 30), category, "box");
        GUI.Label(new Rect(10, 50, 100, 30), curName, "box");
        GUI.Label(new Rect(120, 50, 30, 30), amount, "box");
    }
}
