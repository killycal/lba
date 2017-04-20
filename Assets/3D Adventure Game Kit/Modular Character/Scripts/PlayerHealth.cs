using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Extends health.cs adding audio and updating the UI based on the players health.
/// </summary>
public class PlayerHealth : Health {
    public Text text;           //Text which displays the current player health.
    public AudioClip hurtSfx;   //Sound FX played when damaged.
	private float fillAmount=1;
    /// <summary>
    /// Start method uses Health.cs base start and collects the reference for the health text.
    /// </summary>
    public override void Start()
    {
        base.Start();
        //If there is an object in the scene called HeartText it retrieves and stores the text component.
        if (GameObject.Find("HeartText"))
        {
            text = GameObject.Find("HeartText").GetComponent<Text>();
        }
        //Update the UI after storing the variable.
        VisualUpdate();
    }

    /// <summary>
    /// Knockback method uses Health.cs base knockback and also plays the audio when the character is knocked back.
    /// </summary>
    public override void Knockback(Vector3? origin)
    {
        //If the m_Audio is set in AbstractBehaviour play the sound.
        if (m_Audio)
        {
            m_Audio.PlayOneShot(hurtSfx);
        }
        base.Knockback(origin);
    }
	public override void ChangeHealth(int value)
	{
		currentHealth += value;
		currentHealth = Mathf.Clamp (currentHealth, 0, healthMax);
		if (value > 0)
			m_Audio.PlayOneShot (healSfx);
		fillAmount = fillAmount + value * .2f;
		content.fillAmount = fillAmount;
		VisualUpdate ();
	}


    /// <summary>
    /// Update the UI with the characters current Health.
    /// </summary>
    public override void VisualUpdate()
    {
        if (text)
        {
            text.text = currentHealth.ToString();
        }
    }

}
