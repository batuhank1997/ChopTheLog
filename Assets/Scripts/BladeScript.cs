using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

public class BladeScript : MonoBehaviour
{
	//variables
	public float moveSpeed = 1f;
	public GameObject blade;
	public float boundary = 1.942f;

	private Rigidbody rb;
	private float ScreenWidth;


	// Use this for initialization
	void Start()
	{
		ScreenWidth = Screen.width;
		rb = blade.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		Move();
	}
	void FixedUpdate()
	{
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A) && transform.position.x > -1.9)
        {
			transform.position += Vector3.left * Time.deltaTime * moveSpeed;
		}
		if (Input.GetKey(KeyCode.D) && transform.position.x < 1.6)
        {
			transform.position += Vector3.right * Time.deltaTime * moveSpeed;
		}
		//Move();
#endif
	}

	//move player
	private void Move()
	{
		int i = 0;
		//loop over every touch found
		while (i < Input.touchCount)
		{
			if (Input.GetTouch(i).position.x > ScreenWidth / 2 && transform.position.x < 1.6)
			{
				//move right
				transform.position += Vector3.right * Time.deltaTime * moveSpeed;
			}
			else if (Input.GetTouch(i).position.x < ScreenWidth / 2 && transform.position.x > -1.9)
			{
				//move left
				transform.position += Vector3.left * Time.deltaTime * moveSpeed;
			}
			else
			{
				
			}
			++i;
		}
	}
}
