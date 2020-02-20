using System.Linq;
using System.IO;
using System.Collections.Generic;
using UnityEditor;

public static class BuildHelper
{
	private static string _buildLocation;

	public static void StandaloneWindows64()
	{
		SetupVariables();
		BuildPipeline.BuildPlayer(GetScenes(), _buildLocation + ".exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
	}

	public static void StandaloneLinux64()
	{
		SetupVariables();
		BuildPipeline.BuildPlayer(GetScenes(), _buildLocation, BuildTarget.StandaloneLinuxUniversal, BuildOptions.None);
	}

	public static void StandaloneOSX()
	{
		SetupVariables();
		BuildPipeline.BuildPlayer(GetScenes(), _buildLocation + ".app", BuildTarget.StandaloneOSX, BuildOptions.None);
	}

	private static string[] GetScenes()
	{
		return EditorBuildSettings.scenes.Where(s => s.enabled).Select(s => s.path).ToArray();
	}

	private static void SetupVariables()
	{
		PlayerSettings.productName = "Unity Sample";
		// PlayerSettings.companyName = "...";
		// PlayerSettings.forceSingleInstance = true;
		PlayerSettings.bundleVersion = "0.0.0.0";
		_buildLocation = "./Builds/";
	}
}
