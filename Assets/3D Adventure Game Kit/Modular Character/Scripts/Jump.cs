using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterMotor))]

/// <summary>
/// This class handles the basic jump mechanics.
/// </summary>
public class Jump : AbstractBehaviour {

    public float jumpForce = 10f;  //Used to define the force used to jump, the higher the value the higher the jump.

    /// <summary>
    /// This update handles input for jumping using the InputManagers values.
    /// </summary>
    public virtual void Update()
    {
        if (m_Input.current.jumpBtn > 0)
        {
            OnJump();
        }
    }

    /// <summary>
    /// This method handles the conditions on whether the jump is sucessful.
    /// </summary>
    public virtual void OnJump()
    {
        //Initially we just check if the character is grounded.
        //If so perform the jump.
        if (m_Motor.collision.grounded)
        {
            BaseJump();
        }
    }

    /// <summary>
    /// This method is the logic behind the jump calculating the direction and the force.
    /// </summary>
    public virtual void BaseJump()
    {
		Vector3 newVelocity = m_Motor.movement.movementDirection;
		//print (newVelocity);
		if (newVelocity.magnitude<1)
		{
			//print ("Case 1");
			newVelocity = m_Motor.transform.TransformDirection(Vector3.forward)*jumpForce/20;
			newVelocity.z = newVelocity.z*12;
			newVelocity.x = newVelocity.x*12;
		} 
		else if (newVelocity.z < Mathf.Abs(1f) && newVelocity.x < Mathf.Abs(1f))
		{
			//print ("Case 2");
			newVelocity = m_Motor.transform.TransformDirection(Vector3.forward)*jumpForce/40;
			//newVelocity.z = newVelocity.z*12;
			//newVelocity.x = newVelocity.x*12;
		} 
		else {
			//Calculates a new Velocity 
			//print ("Case 3");
			newVelocity = m_Motor.transform.TransformDirection(Vector3.forward/200)*jumpForce;
		}
        newVelocity.y = jumpForce/1.35f;
        //then Inputs it through the ChangeVelocity method in CharacterMotor which limits the amount of sources force can be applied to the character cutting down on some strange interactions.
        m_Motor.ChangeVelocity(newVelocity);
    }
}
