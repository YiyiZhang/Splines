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
		int closestNodeIndex = GetClosestNode(pos); /*get closest node position using function below that spits out the V3 position of the closest node*/
		if (closestNodeIndex == 0){
			return ProjectOnSegment (nodes [0], nodes [1], pos); /*for first segment*/
		} else if(closestNodeIndex == nodeCount -1){
			return ProjectOnSegment (nodes [nodeCount - 1], nodes [nodeCount - 2], pos); /*for first segment*/
		} else {
			Vector3 leftSeg = ProjectOnSegment (nodes [closestNodeIndex - 1], nodes [closestNodeIndex], pos);
			Vector3 rightSeg = ProjectOnSegment (nodes [closestNodeIndex + 1], nodes [closestNodeIndex], pos);

			Debug.DrawLine (pos, leftSeg, Color.red);
			Debug.DrawLine (pos, rightSeg, Color.blue);

			if ((pos - leftSeg).sqrMagnitude <= (pos - rightSeg).sqrMagnitude) {
				return leftSeg;

			} else {
				return rightSeg;
			}
			/*Project on the 2 connected Segments*/
			/*Return shortest vector*/
		}
	}

	private int GetClosestNode(Vector3 pos){ /*getting position of the closest node to the object*/
		int closestNodeIndex = -1;
		float shortestDistance = 0.0f;

		for(int i = 0; i < nodeCount; i++){
			float sqrDistance = (nodes[i] - pos).sqrMagnitude; /*calculating distance of nodes in square to save memory*/
			if(shortestDistance == 0.0f || sqrDistance < shortestDistance){
				shortestDistance = sqrDistance;
				closestNodeIndex = i;
			}
		}
		return closestNodeIndex;
	}

	private Vector3 ProjectOnSegment(Vector3 v1, Vector3 v2, Vector3 pos){
		Vector3 v1ToPos = pos - v1;
		Vector3 segDirection = (v2 - v1).normalized; /*to get the intersection point between the two vectors*/

		float distanceFromV1 = Vector3.Dot(segDirection,v1ToPos); /*distance from the 1st point to where we should be on the line*/
		if(distanceFromV1 < 0.0f){
			return v1;
		} else if (distanceFromV1*distanceFromV1 > (v2-v1).sqrMagnitude){
			return v2;
		} else {
			Vector3 fromV1 = segDirection * distanceFromV1;
			return v1 + fromV1;
		}
	}
}

//14:32 https://www.youtube.com/watch?v=B3LYJINnYtE&feature=youtu.be