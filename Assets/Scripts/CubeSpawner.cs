using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {
	public GameObject[] requiredResources;
	public int[] stock;
	public GameObject[] pathPoints;
	public GameObject spawnObject;
	public float spawnTime = 2.0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void Spawn(){
		bool allowSpawn = true;

		//if it needs a resource
		if(requiredResources.Length > 0)
		{
			//check the stock level
			for(int i = 0; i < requiredResources.Length; i++)
			{
				if(stock[i] <= 0 )
				{
					allowSpawn = false;
				}
			}
		}

		if(allowSpawn)
		{
			//reduce the stock level
			for(int i = 0; i <stock.Length; i++)
			{
				stock[i]--;
			}
			//spawn the resource
			GameObject reference = Instantiate(spawnObject, transform.position, Quaternion.identity) as GameObject;
			//set path information
			reference.SendMessage ("SetPathPoints", pathPoints, SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		for(int i = 0; i < requiredResources.Length; i++)
		{
			//if the colliding resource is in the requiredResource array, update the stock level
			if(other.gameObject.tag == requiredResources[i].tag)
			{
				stock[i]++;
			}
		}
	}

}
