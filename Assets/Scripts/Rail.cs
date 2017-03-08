using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour {
	private Vector3[] nodes;
	private int nodeCount;

	private void Start(){
		nodeCount = transform.GetChildCount(); /*counts number of children in transform*/
		nodes = new Vector3[nodeCount]; /*there will be as many Vector3s as there are children*/

		for(int i = 0; i < nodeCount; i++){
			nodes[i] = transform.GetChild(i).position; /*get transform for each node iterating from 0 to the number of nodes there are*/
		}
	}

	private void Update(){
		if (nodeCount > 1) { /*if there's more than one node. if there's only one node, obvs only need to return the position of the one*/
			for (int i = 0; i < nodeCount - 1; i++) {
				Debug.DrawLine (nodes [i], nodes [i + 1], Color.green);
			}
		}
	}

	public Vector3 ProjectPositionOnRail(Vector3 pos){ /*compares position of object against relative distance to the distance between nodes*/
		int closestNodeIndex = 0; /*get closest node*/
		if (closestNodeIndex == 0){
			/*Project on first segment*/
		} else if(closestNodeIndex == nodeCount -1){
			/*Project on last segment*/
		} else {
			/*Project on the 2 connected Segments*/
			/*Return shortest vector*/
		}
}
