using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

public class MyPlayerController : MonoBehaviour {

	private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
	private Transform m_Cam;                  // A reference to the main camera in the scenes transform
	private Vector3 m_CamForward;             // The current forward direction of the camera
	private Vector3 m_Move;
	private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
	//摇杆  
	public Joystick Joystick;  
	public GameObject Player;


	private void Start()
	{
		// get the transform of the main camera
		if (Camera.main != null)
		{
			m_Cam = Camera.main.transform;
		}
		else
		{
			Debug.LogWarning(
				"Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
			// we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
		}

		// get the third person character ( this should never be null due to require component )
		m_Character = Player.GetComponent<ThirdPersonCharacter>();
	}




	void FixedUpdate()  
	{   
		//获取摇杆偏移  
		var h = Joystick.getOffset().x;  
		var v = Joystick.getOffset().y;  

		m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
		m_Move = v*m_CamForward + h*m_Cam.right;
		m_Character.Move(m_Move, false, false);

	}  
}
