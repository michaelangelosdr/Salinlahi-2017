using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay_Fade_Script : MonoBehaviour {

	public Texture2D FadeOutTexture;
	public float FadeSpeed = 1.5f;

	private int drawDepth = -1000;
	private float alpha =0.0f;
	private int fadeDir = 1;
	private bool FadeNow = false;

	void OnGUI()
	{
		if (FadeNow) {
			alpha += fadeDir * FadeSpeed * Time.deltaTime;
			alpha = Mathf.Clamp01 (alpha);
		}
			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.depth = drawDepth;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), FadeOutTexture);
	}

	public float BeginFade(int direction)
	{
		fadeDir = direction;
		return(FadeSpeed);
	}

	public void StartFade()
	{
		FadeNow = true;
	}

}
