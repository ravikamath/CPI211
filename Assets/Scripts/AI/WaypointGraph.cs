using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using System;

public class WaypointGraph : MonoBehaviour {
	
	private List<Node> nodes;
	public Transform waypoints;
	
	void Start () {
		// Create nodes
		nodes = new List<Node>();
		GameObject[] waypoints = new GameObject[this.waypoints.childCount];
		for(int i = 0; i < waypoints.Length; i++)
			waypoints[i] = this.waypoints.GetChild(i).gameObject;
		for(int i = 0; i < waypoints.Length; i++)
		{
			Node node = new Node();
			node.position = waypoints[i].transform.position;
			node.waypoint = waypoints[i];
			nodes.Add(node);
			//Destroy(waypoints[i]);
		}
		RaycastHit info;
		// Find neighbors
		for(int i = 0; i < nodes.Count; i++)
			for(int j = i+1; j < nodes.Count; j++)
		{
			Vector3 dir = nodes[j].position - nodes[i].position;
			// if i-j can be connected, then
			if(Physics.Raycast(
				new Ray(nodes[i].position,
				dir.normalized), out info,
				dir.magnitude) && info.collider.gameObject == nodes[j].waypoint)
			{
				nodes[i].neighbors.Add (nodes[j]);
				nodes[j].neighbors.Add (nodes[i]);
			}
			Destroy (nodes[i].waypoint.collider);
		}
		
	}
	
	public List<Vector3> Search(Vector3 enemyPosition, Vector3 playerPosition)
	{
		Node start = null, end = null;
		float startDistance = float.MaxValue;
		float endDistance = float.MaxValue;
		foreach(Node node in nodes)
		{
			if ((node.position - playerPosition).magnitude < startDistance)
			{
				start = node;
				startDistance = (node.position - playerPosition).magnitude;
			}
			
			if ((node.position - enemyPosition).magnitude < endDistance)
			{
				end = node;
				endDistance = (node.position - enemyPosition).magnitude;
			}
		}
		FindPath (start, end);
		List<Vector3> path = new List<Vector3>();
		Node current = end;
		while(current != null)
		{
			path.Add (current.position);
			print (current.position);
			current.waypoint.renderer.material.color = Color.green;
			current = current.parent;
		}
		return path;
	}
	
	void FindPath(Node start, Node end)
	{
		foreach(Node node in nodes)
		{
			node.Reset();
		}
		SortedList<float, List<Node>> openList = new SortedList<float, List<Node>>();
		start.cost = 0;
		start.heuristic = (end.position - start.position).magnitude;
		start.total = start.cost + start.heuristic;
		start.status = Node.NodeStatus.Open;
		AddNode(openList, start);
		
		while(openList.Count > 0)
		{
			Node current = openList.ElementAt(0).Value[0];
			RemoveNode(openList, current);
			current.status = Node.NodeStatus.Closed;
			
			if(current == end)
				break;
			foreach(Node node in current.neighbors)
			{
				if(node.status == Node.NodeStatus.Closed)
					continue;
				float tempCost = current.cost + (current.position - node.position).magnitude;
				if(tempCost < node.cost)
				{
					if(node.status == Node.NodeStatus.Open)
						RemoveNode (openList,node);
					node.cost = tempCost;
					node.heuristic = (end.position - node.position).magnitude;
					node.total = node.cost + node.heuristic;
					node.parent = current;
					AddNode (openList,node);
					node.status = Node.NodeStatus.Open;
				}
			}
			
		}
	}
	
	void AddNode(SortedList<float, List<Node>> openList, Node node)
	{
		if(openList.ContainsKey(node.total))
			openList[node.total].Add(node);
		else
		{
			openList[node.total] = new List<Node>();
			openList[node.total].Add(node);
		}
	}
	
	void RemoveNode(SortedList<float, List<Node>> openList, Node node)
	{
		openList[node.total].Remove(node);
		if(openList[node.total].Count == 0)
			openList.Remove(node.total);
	}
}
