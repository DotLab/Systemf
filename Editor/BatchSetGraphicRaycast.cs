using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace Systemf {
  public sealed class BatchSetGraphicRaycast : MonoBehaviour {
		[MenuItem("Systemf/Batch Set Graphic Raycast")]
		public static void SetGraphicRaycast() {
			var root = Selection.activeGameObject.transform;
			foreach (var graphic in root.GetComponentsInChildren<Graphic>()) {
				graphic.raycastTarget = true;
			}
		}

		[MenuItem("Systemf/Batch Unset Graphic Raycast")]
		public static void UnsetGraphicRaycast() {
			var root = Selection.activeGameObject.transform;
			foreach (var graphic in root.GetComponentsInChildren<Graphic>()) {
				graphic.raycastTarget = false;
			}
		}
	}
}
