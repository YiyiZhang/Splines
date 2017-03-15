using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMover : MonoBehaviour {
	public Rail rail;
	public Transform lookAt; /*tells camera where to be looking*/
	public bool smoothMove = true; /*for smoothing camera transition between nodes*/
	public float moveSpeed = 5.0f; /*camera transition speed*/

	private Transform thisTransform;
	private Vector3 lastPosition; /*the position of the camera just before jumping to the next node*/

	private void Start(){
		thisTransform = transform;
		lastPosition = thisTransform.position;
	}

	private void Update(){
		if (smoothMove) {
			lastPosition = Vector3.Lerp(lastPosition, rail.ProjectPositionOnRail (lookAt.position), Time.deltaTime * moveSpeed);
			thisTransform.position = lastPosition;
		} else {
			thisTransform.position = rail.ProjectPositionOnRail (lookAt.position); /*look at where the thing is on the rail*/
			thisTransform.LookAt (lookAt.position); /*look at the player*/
		}
	}
}
