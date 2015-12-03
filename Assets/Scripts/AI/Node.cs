using UnityEngine;
using System.Collections.Generic;

public class Node
{
	public enum NodeStatus { Default, Open, Closed }
	
	public Vector3 position {get; set;}
	public float cost {get;set;}
	public float heuristic {get;set;}
	public float total {get;set;}
	public Node parent {get;set;}
	public NodeStatus status {get;set;}
	public List<Node> neighbors {get; protected set;}
	public GameObject waypoint {get;set;}
	
	public Node()
	{
		position = Vector3.zero;
		neighbors = new List<Node>();
	}
	
	public void Reset()
	{
		status = NodeStatus.Default;
		cost = float.MaxValue;
		parent = null;
	}

}
