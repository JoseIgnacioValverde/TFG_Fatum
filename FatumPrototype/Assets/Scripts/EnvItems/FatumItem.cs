using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FatumItem : MonoBehaviour
{
    // Start is called before the first frame update
    public string ItemName;
    public Canvas canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			canvas.gameObject.SetActive(true);
		}
	}
    void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			canvas.gameObject.SetActive(false);
		}
	}
}
