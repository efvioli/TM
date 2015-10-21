using UnityEngine;
using System.Collections;

public class PathThroughObjects : MonoBehaviour {
	//To get it working for now
	//need to figure out how the resources are actually moved.
	public GameObject[] pathPoints;
	public float speed = 1.0f;
	public float goalSize = 0.1f;

	private int currentPathIndex = 0;
	private Vector3 movementDirection;
	// Use this for initialization
	void Start () {
		movementDirection = (pathPoints[currentPathIndex].transform.position - transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		//movement code
		transform.position += movementDirection*speed*Time.deltaTime;
	}
	
	void OnTriggerEnter(Collider other)
	{
		//if the object that was triggered is the current 'move to' object
		if(other.gameObject.name == pathPoints[currentPathIndex].name)
		{
			//set to the same position as the 'move to' object
			transform.position = pathPoints[currentPathIndex].transform.position;
			currentPathIndex++;
			//if there are no more objects in the 'move to' list
			if(currentPathIndex >= pathPoints.Length)
			{
				//ADD LOGIC TO DO SOMETHING
				Destroy(gameObject);
			}
			//go to next 'move to' object
			else
			{
				movementDirection = (pathPoints[currentPathIndex].transform.position - transform.position).normalized;
			}
		}
	}
	
	void SetPathPoints(GameObject[] inputPathPoints)
	{
		pathPoints = inputPathPoints;
	}
}
