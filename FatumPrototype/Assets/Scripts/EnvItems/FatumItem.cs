using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FatumItem : MonoBehaviour
{
    // Start is called before the first frame update
    public string ItemName;
    public Canvas canvas;
    public InventoryManager manager;
    public bool PlayerIn;
    void Start()
    {
        PlayerIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerIn&&Input.GetButton("Collect")){
                UnityEngine.Debug.Log("Papoi");
                manager.UnlockItem(ItemName);
                canvas.gameObject.SetActive(false);
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
