using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractiveEntity : MonoBehaviour
{
	private Color originalColor;

	public float blueMultiply = 3.5f;
	public float redGreenMultiply = 0.5f;

	void Start()
	{
		originalColor = renderer.material.color;
	}

	void OnMouseEnter()
	{
		float red = originalColor.r * redGreenMultiply;
		float blue = originalColor.b * blueMultiply;
		float green = originalColor.g * redGreenMultiply;

		renderer.material.color = new Color(red, green, blue);
	}

	void OnMouseExit()
	{
		renderer.material.color = originalColor;
	}

	private bool isDisplayingInteractionOptions;
	private string interactionOptionsTitle;
	private List<string> interactionOptionsToDisplay;

	void OnMouseUpAsButton()
	{
		if (isDisplayingInteractionOptions)
		{
			isDisplayingInteractionOptions = false;
			return;
		}

		isDisplayingInteractionOptions = true;
		interactionOptionsTitle = GetInteractionOptionsTitle();
		interactionOptionsToDisplay = GetInteractionOptions();
	}

	const float WindowTitleHeight = 15;
	const float ButtonPadding = 5;
	const float ButtonWidth = 100;
	const float ButtonHeight = 20;

	void OnGUI()
	{
		if (!isDisplayingInteractionOptions)
			return;

		Vector3 objectCenter = Camera.main.WorldToScreenPoint(transform.position);

		int numberOfOptions = interactionOptionsToDisplay.Count;
		float windowWidth = ButtonWidth + ButtonPadding * 2;
		float windowHeight = WindowTitleHeight + ButtonHeight * numberOfOptions + ButtonPadding * (1 + numberOfOptions);
		float windowLeft = objectCenter.x - windowWidth / 2;
		float windowTop = Screen.height - objectCenter.y - windowHeight / 2;
		Rect windowRect = new Rect(windowLeft, windowTop, windowWidth, windowHeight);

		GUI.Window(0, windowRect, CreateInteractionOptionsWindows, interactionOptionsTitle);
	}

	void CreateInteractionOptionsWindows(int windowID)
	{
		Rect buttonRect = new Rect(ButtonPadding, WindowTitleHeight + ButtonPadding, ButtonWidth, ButtonHeight);
		for (int idx = 0; idx < interactionOptionsToDisplay.Count; ++idx)
		{
			if (GUI.Button(buttonRect, interactionOptionsToDisplay[idx]))
			{
				DidSelectInteractionOption(interactionOptionsToDisplay[idx]);
				isDisplayingInteractionOptions = false;
			}

			buttonRect.yMin += ButtonPadding + ButtonHeight;
			buttonRect.yMax += ButtonPadding + ButtonHeight;
		}
	}

	// This logic will move to some form of delegate later
	string GetInteractionOptionsTitle()
	{
		return "Jake";
	}

	List<string> GetInteractionOptions()
	{
		return new List<string>() { "Run", "Flee", "Die" };
	}

	void DidSelectInteractionOption(string interactionOption)
	{
		print(interactionOption);
	}
}
