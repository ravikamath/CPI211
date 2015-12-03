using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour {
	
	public WaypointGraph graph;
	public Transform player;
	public float speed = 5;
	bool havePath = false;
	List<Vector3> path;
	
	void Start()
	{
		if(player == null)
			player = GameObject.FindGameObjectWithTag("Player").transform;
		if(graph == null)
			graph = GameObject.FindGameObjectWithTag("GameController").GetComponent<WaypointGraph>();
		path = new List<Vector3>();
		havePath = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!havePath)
		{
			path = graph.Search(transform.position, player.transform.position);
			havePath = true;
		}
		else if(path.Count > 0)
		{
			Vector3 dir = path[0] - transform.position;
			dir.y = 0;
			if(dir.magnitude < Time.deltaTime * speed)
			{
				transform.position = new Vector3(path[0].x, transform.position.y, path[0].z);
				path.RemoveAt(0);
			}
			else
				transform.position += dir.normalized * Time.deltaTime * speed;
		}
	}
}
