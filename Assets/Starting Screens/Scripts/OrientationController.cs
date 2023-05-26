using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationController : MonoBehaviour
{
	public static void setLandscapeView()
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public static void setPortraitView()
	{
		Screen.orientation = ScreenOrientation.Portrait;
	}
}
