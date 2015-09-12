using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject OnHitFx;



	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy") {
			GameObject go = (GameObject)GameObject.Instantiate(OnHitFx, transform.position, OnHitFx.transform.rotation);
		}

		Destroy (gameObject);
	}
}
