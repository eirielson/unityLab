using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject OnHitFx;



	void OnCollisionEnter(Collision collision){

		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy") {
			Debug.Log("HIT");
			collision.gameObject.GetComponent<Stats>().ApplyDamage(500);
			//GameObject go = (GameObject)GameObject.Instantiate(OnHitFx, transform.position, OnHitFx.transform.rotation);
			//Destroy (gameObject);
		}

	}
}
