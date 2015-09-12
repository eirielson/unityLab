using UnityEngine;
using System.Collections;

public class PlayerTank : MonoBehaviour
{
	private Transform m_transform;

	public GameObject ProjectTile;
	public Transform ProjectRef;
	public float ProjectTileSpeed = 50;
	public Transform CannonBase;


	public int MoveSpeed = 40;
	public int RotateSpeed = 70;

	void Start ()
	{
		m_transform = transform;
	}

	void Update ()
	{
		GetInput ();
		Fire ();
	}

	/// <summary>
	/// Recebe comandos do teclado e mouse
	/// </summary>
	private void GetInput(){
		int horizontal_input = 0;
		int vertical_input = 0;

		if (Input.GetKey (KeyCode.W)) {
			vertical_input = 1;
		}
		else if (Input.GetKey(KeyCode.S)) {
			vertical_input = -1;
		}

		if (Input.GetKey(KeyCode.A)) {
			horizontal_input = -1;	
		}
		else if (Input.GetKey(KeyCode.D)) {
			horizontal_input = 1;
		}


		float translation = vertical_input * MoveSpeed;
		float rotation = horizontal_input * RotateSpeed;

		//
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;

		m_transform.Translate (translation, 0, 0);
		m_transform.Rotate (0, rotation,0);

		float cannonRotation = Input.GetAxis ("Mouse X") * MoveSpeed;
		CannonBase.Rotate (0, cannonRotation, 0);


	}


	void Fire(){
		if(Input.GetMouseButtonDown(button:0)){
			GameObject go = (GameObject)GameObject.Instantiate (ProjectTile, ProjectRef.position, ProjectRef.rotation);
			go.rigidbody.velocity = ProjectRef.up * ProjectTileSpeed;
		}
	}
}
