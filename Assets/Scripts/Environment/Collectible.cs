using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Collectible : MonoBehaviour {

	[SerializeField] private float rotationSpeed;
	[SerializeField] private AudioClip collectSound;
	[SerializeField] private GameObject collectEffect;

	public delegate void TakeCollectible(int count);
	public event TakeCollectible OnCollect;
	
	void FixedUpdate () {
			transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			Collect();
		}
	}

	public void Collect()
	{
		if(OnCollect!=null)OnCollect.Invoke(5);
		if(collectSound)
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if(collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);
		Destroy (gameObject);
	}
}

