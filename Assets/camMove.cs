using UnityEngine;
using System.Collections;

public class camMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.SetParent(GameObject.Find("Player").transform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
