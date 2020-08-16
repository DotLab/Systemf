using UnityEngine;
using UnityEditor.Callbacks;
using UnityEditor;
using System;
using System.IO;

namespace Systemf {
	public sealed class AutoIncrementBuildVersion : MonoBehaviour {
#if UNITY_EDITOR_WIN
		[PostProcessBuildAttribute(0)]
		public static void OnPostprocessBuild(BuildTarget buildTarget, string path) {
			string version = PlayerSettings.bundleVersion;
			IncreaseVersion(0, 0, 0, 1);
			
			if (buildTarget == BuildTarget.Android) {
				string newPath = path.Replace(
					Path.GetFileNameWithoutExtension(path),
					PlayerSettings.applicationIdentifier + "-" + version);
				Debug.Log("Copying apk to " + newPath);
				File.Copy(path, newPath, true);
			}

			ArchiveProject();
		}

		[MenuItem("Build/Print Version")]
		static void PrintVersion() {
			IncreaseVersion(0, 0, 0, 0);
		}
		
		[MenuItem("Build/Increase Major Version")]
		static void IncreaseMajor() {
			IncreaseVersion(1, -1, -1, 0);
		}
		
		[MenuItem("Build/Increase Minor Version")]
		static void IncreaseMinor() {
			IncreaseVersion(0, 1, -1, 0);
		}
		
		[MenuItem("Build/Increase Patch Version")]
		static void IncreasePatch() {
			IncreaseVersion(0, 0, 1, 0);
		}

		static string GetDateStrig() {
			return DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
		}

		[MenuItem("Build/Archive Project")]
		static void ArchiveProject() {
			const string BANDIZIP_PATH = "\"C:\\Program Files\\Bandizip\\Bandizip.exe\"";
			string archiveName = string.Format("{0}-{1}.zip", GetDateStrig(), PlayerSettings.bundleVersion);

			Debug.Log("Archiving project to " + archiveName);
			System.Diagnostics.Process.Start("CMD.exe",
				string.Format("/C {0} c -r E:/Unity/Touhou-Mix-Unity/Archives/{1} E:/Unity/Touhou-Mix-Unity/Assets E:/Unity/Touhou-Mix-Unity/ProjectSettings E:/Unity/Touhou-Mix-Unity/Unpacked",
				BANDIZIP_PATH, archiveName));
		}

		static void IncreaseVersion(int majorInc, int minorInc, int patchInc, int buildInc) {
			try {
				string[] segs = PlayerSettings.bundleVersion.Split('.');
				int major = Convert.ToInt32(segs[0]) + majorInc;
				int minor = minorInc < 0 ? 0 : Convert.ToInt32(segs[1]) + minorInc;
				int patch = patchInc < 0 ? 0 : Convert.ToInt32(segs[2]) + patchInc;
				int build = Convert.ToInt32(segs[3]) + buildInc;
				
				PlayerSettings.bundleVersion = major + "." + minor + "." + patch + "." + build;
				
				PlayerSettings.iOS.buildNumber = build.ToString();
				PlayerSettings.Android.bundleVersionCode = build;
				PlayerSettings.WSA.packageVersion = new Version(major, minor, patch, build);
				Debug.LogFormat("Next version {0}, build {1:N0}", PlayerSettings.bundleVersion, build);
				
			} catch (Exception e) {
				Debug.LogError("IncreaseVersion failed:\n" + e);
			}
		}
#endif
	}
}