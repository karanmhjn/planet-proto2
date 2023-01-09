using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

	const float G = 2f;
	public bool orbitting; 
	public int bodyId;
	public int bodyToOrbit; 

	public static List<Attractor> Attractors;

	public Rigidbody rb;

	void FixedUpdate ()
	{
		if (orbitting == false)
		{
			foreach (Attractor attractor in Attractors)
			{
				if (attractor != this)
					Attract(attractor);
			}
		}
		if (orbitting == true)
		{
			foreach (Attractor attractor in Attractors)
			{
				if (attractor.bodyId == bodyToOrbit)
				{
					if (attractor != this)
						BeAttracted(attractor);
				}
				
			}
		}
		
	}

	void OnEnable ()
	{
		if (Attractors == null)
			Attractors = new List<Attractor>();

		Attractors.Add(this);
	}

	void OnDisable ()
	{
		Attractors.Remove(this);
	}

	void Attract (Attractor objToAttract)
	{
		Rigidbody rbToAttract = objToAttract.rb;

		Vector3 direction = rb.position - rbToAttract.position;
		float distance = direction.magnitude;

		if (distance == 0f)
			return;

		float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
		Vector3 force = direction.normalized * forceMagnitude;

		rbToAttract.AddForce(force);
	}

	void BeAttracted (Attractor attractedFrom)
	{
		Rigidbody rbAttractFrom = attractedFrom.rb;

		Vector3 direction = rbAttractFrom.position - rb.position;
		float distance = direction.magnitude;

		if (distance == 0f)
			return;

		float forceMagnitude = G * (rb.mass * rbAttractFrom.mass) / Mathf.Pow(distance, 2);
		Vector3 force = direction.normalized * forceMagnitude;

		rb.AddForce(force);
	}

}