using UnityEngine;
using System.Collections;

public class PlayerTank : MonoBehaviour
{
	private Transform m_transform;

	void Start ()
	{
		m_transform = transform;
	}

	void Update ()
	{
		GetInput ();
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


		float translation = vertical_input * 100;
		float rotarion = horizontal_input * 100;

		//
		translation *= Time.deltaTime;
		rotarion *= Time.deltaTime;

		m_transform.Translate (translation, 0, 0);
		m_transform.Rotate (0, rotarion,0);
	}
}
