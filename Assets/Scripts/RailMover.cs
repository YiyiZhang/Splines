using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailMover : MonoBehaviour {
	public Rail rail;
	public Transform lookAt; /*tells camera where to be looking*/

	private Transform thisTransform;

	private void Start(){
		thisTransform = transform;
	}

}
