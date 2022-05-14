using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMover : MonoBehaviour
{
    public Canvas canvas;
    public GameObject itemToUnlock;
    public bool PlayerIn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerIn&&Input.GetButton("Collect")){
            canvas.gameObject.SetActive(false);
            itemToUnlock.SetActive(true);
            transform.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			canvas.gameObject.SetActive(true);
            PlayerIn = true;
		}
	}
    void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			canvas.gameObject.SetActive(false);
            PlayerIn = false;
		}
	}
}
