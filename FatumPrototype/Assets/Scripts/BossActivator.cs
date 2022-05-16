using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public BossHermitController hermitController;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			hermitController.enabled = true;
		}
	}
}
