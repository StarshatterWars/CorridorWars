/**********************************************************
*          Copyright (c) 2012 Mad Pixel Machine           *
*                  All Rights Reserved                    *
*                                                         *
*             http://www.madpixelmachine.com              *
**********************************************************/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class EnergyBarInspectorBase : EnergyBarToolkit.EditorBase {

    // ===========================================================
    // Constants
    // ===========================================================

    // ===========================================================
    // Fields
    // ===========================================================
    
    protected SerializedProperty texturesBackground;
    protected SerializedProperty texturesForeground;
    protected SerializedProperty premultipliedAlpha;
    
    protected SerializedProperty pivot;
    protected SerializedProperty guiDepth;
    protected SerializedProperty anchorObject;
    protected SerializedProperty anchorCamera;
    protected SerializedProperty positionSizeFromTransform;
    protected SerializedProperty positionSizeFromTransformNormalized;
    
    protected SerializedProperty effectSmoothChange;
    protected SerializedProperty effectSmoothChangeSpeed;
    
    // ===========================================================
    // Constructors (Including Static Constructors)
    // ===========================================================

    // ===========================================================
    // Getters / Setters
    // ===========================================================

    // ===========================================================
    // Methods for/from SuperClass/Interfaces
    // ===========================================================
    
    public void OnEnable() {
        texturesBackground = serializedObject.FindProperty("texturesBackground");
        texturesForeground = serializedObject.FindProperty("texturesForeground");
        premultipliedAlpha = serializedObject.FindProperty("premultipliedAlpha");
    
        pivot = serializedObject.FindProperty("pivot");
        guiDepth = serializedObject.FindProperty("guiDepth");
        anchorObject = serializedObject.FindProperty("anchorObject");
        anchorCamera = serializedObject.FindProperty("anchorCamera");
        positionSizeFromTransform = serializedObject.FindProperty("positionSizeFromTransform");
        positionSizeFromTransformNormalized = serializedObject.FindProperty("positionSizeFromTransformNormalized");
        
        effectSmoothChange = serializedObject.FindProperty("effectSmoothChange");
        effectSmoothChangeSpeed = serializedObject.FindProperty("effectSmoothChangeSpeed");
    }

    // ===========================================================
    // Methods
    // ===========================================================
    
    protected void CheckTextureIsGUI(Texture2D texture) {
        if (texture == null) {
            return;
        }
        
        var path = AssetDatabase.GetAssetPath(texture);
        var importer = TextureImporter.GetAtPath(path) as TextureImporter;
        
        if (importer.textureType != TextureImporterType.GUI) {
            if (WarningFix("It's recommended that this texture type is set to GUI.")) {
                importer.textureType = TextureImporterType.GUI;
                
                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            }
        }
    }
    
    protected void CheckTextureIsReadable(Texture2D texture) {
        if (texture == null) {
            return;
        }
        
        var path = AssetDatabase.GetAssetPath(texture);
        var importer = TextureImporter.GetAtPath(path) as TextureImporter;
        
        if (importer.textureType != TextureImporterType.Default || !importer.isReadable || importer.npotScale != TextureImporterNPOTScale.None) {
            if (ErrorFix("This texture must be set to Advanced/Readable without power of 2.")) {
                importer.textureType = TextureImporterType.Default;
                importer.isReadable = true;
                importer.npotScale = TextureImporterNPOTScale.None;
                
                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            }
        }
    }
    
    protected void CheckTextureFilterTypePoint(Texture2D texture) {
        if (texture == null) {
            return;
        }
        
        var path = AssetDatabase.GetAssetPath(texture);
        var importer = TextureImporter.GetAtPath(path) as TextureImporter;
        
        if (importer.filterMode != FilterMode.Point) {
            if (WarningFix("It's recommended that this texture filter mode is set to Point.")) {
                importer.filterMode = FilterMode.Point;
                
                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            }
        }
    }
    
    protected void CheckTextureFilterTypeNotPoint(Texture2D texture) {
        if (texture == null) {
            return;
        }
        
        var path = AssetDatabase.GetAssetPath(texture);
        var importer = TextureImporter.GetAtPath(path) as TextureImporter;
        
        if (importer.filterMode == FilterMode.Point) {
            if (WarningFix("It's recommended that this texture filter mode is set to Bilinear or Trilinear")) {
                importer.filterMode = FilterMode.Bilinear;
                
                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            }
        }
    }
    
#region Fields
    protected void FieldBackgroundTextures() {
        GUITextures(ref texturesBackground, "Background Textures");
    }
    
    protected void FieldForegroundTextures() {
        GUITextures(ref texturesForeground, "Foreground Textures");
    }
    
    private void GUITextures(ref SerializedProperty textures, string label) {
        ArrayList(textures, label, (property) => {
            var texture = property.FindPropertyRelative("texture");
            var color = property.FindPropertyRelative("color");
            
            GUITexture(texture, color);
            
            CheckTextureIsGUI(texture.objectReferenceValue as Texture2D);
        });
    }
    
    protected void GUITexture(SerializedProperty texture, SerializedProperty color) {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(texture, new GUIContent(""), GUILayout.MaxWidth(150), GUILayout.ExpandWidth(true));
        EditorGUILayout.PropertyField(color, new GUIContent(""), GUILayout.MaxWidth(100));
        EditorGUILayout.EndHorizontal();
    }
    
    protected void FieldRelativeToTransform() {
        PropertyField(positionSizeFromTransform, "Relative To Transform",
            "Affects position and size by this game object transform.");
        if (positionSizeFromTransform.boolValue) {
            Indent(() => {
                PropertyField(positionSizeFromTransformNormalized, "Normalized");
            });
        }
    }
    
    protected void FieldPremultipliedAlpha() {
        PropertyField(premultipliedAlpha, "Premultiplied Alpha",
        "Check this if your textures has its components multiplied by alpha channel.");
    }
    
    protected void FieldSmoothEffect() {
        PropertyFieldToggleGroup2(effectSmoothChange, "Smooth Effect", () => {
            Indent(() => {
                PropertyField(effectSmoothChangeSpeed, "Smooth Speed");
            });
        });
    }
 
#endregion   
}