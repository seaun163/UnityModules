﻿#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Leap.Unity.Testing;


namespace Leap.Unity.GraphicalRenderer.Tests {

  public static class SetupGraphicRendererTests {
    [SetupLeapTests]
    private static void setupTests() {
      var scenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);
      addScene("ShaderOutputTestScenes/StationaryBakedRendererShaderTestScene", scenes);
      addScene("ShaderOutputTestScenes/TranslationBakedRendererShaderTestScene", scenes);

      EditorBuildSettings.scenes = scenes.ToArray();
    }

    private static void addScene(string name, List<EditorBuildSettingsScene> scenes) {
      var sceneAsset = EditorResources.Load<SceneAsset>(name);
      if (sceneAsset == null) {
        Debug.LogWarning("Could not find scene " + name);
        return;
      }

      string path = AssetDatabase.GetAssetPath(sceneAsset);
      scenes.Add(new EditorBuildSettingsScene(path, enable: true));
    }
  }
}
#endif