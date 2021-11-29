/*
* Copyright (c) 2013 Mad Pixel Machine
* All Rights Reserved
*
* http://www.madpixelmachine.com
*/

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(EnergyBarRenderer))]
public class EnergyBarRendererInspector : EnergyBarInspectorBase {

    // ===========================================================
    // Constants
    // ===========================================================
    
    public const string FormatHelp =
        @"{cur} - current int value
{min} - minimal value
{max} - maximum value
{cur%} - current % value (0 - 100)
{cur2%} - current % value with precision of tens (0.0 - 100.0)

Examples:
{cur}/{max} - 27/100
{cur%} % - 27 %";

    // ===========================================================
    // Fields
    // ===========================================================
    
    private SerializedProperty textureBar;
    
    private SerializedProperty textureBarColorType;
    private SerializedProperty textureBarColor;
    private SerializedProperty textureBarGradient;
    
    private SerializedProperty screenPosition;
    private SerializedProperty screenPositionNormalized;
    private SerializedProperty screenPositionCalculateSize;
    private SerializedProperty size;
    private SerializedProperty sizeNormalized;
    
    private SerializedProperty growDirection;
    
    private SerializedProperty radialOffset;
    private SerializedProperty radialLength;
    
    private SerializedProperty labelEnabled;
    private SerializedProperty labelSkin;
    private SerializedProperty labelPosition;
    private SerializedProperty labelFormat;
    private SerializedProperty labelColor;
    private SerializedProperty labelOutlineEnabled;
    private SerializedProperty labelOutlineColor;
    
    private SerializedProperty effectBurn;
    private SerializedProperty effectBurnTextureBar;
    private SerializedProperty effectBurnTextureBarColor;
    
    private SerializedProperty effectBlink;
    private SerializedProperty effectBlinkValue;
    private SerializedProperty effectBlinkRatePerSecond;
    private SerializedProperty effectBlinkColor;

    // ===========================================================
    // Constructors (Including Static Constructors)
    // ===========================================================

    // ===========================================================
    // Getters / Setters
    // ===========================================================

    // ===========================================================
    // Methods for/from SuperClass/Interfaces
    // ===========================================================
    
    new public void OnEnable() {
        base.OnEnable();
        
        textureBar = serializedObject.FindProperty("textureBar");
        
        textureBarColorType = serializedObject.FindProperty("textureBarColorType");
        textureBarColor = serializedObject.FindProperty("textureBarColor");
        textureBarGradient = serializedObject.FindProperty("textureBarGradient");
        
        screenPosition = serializedObject.FindProperty("screenPosition");
        screenPositionNormalized = serializedObject.FindProperty("screenPositionNormalized");
        screenPositionCalculateSize = serializedObject.FindProperty("screenPositionCalculateSize");
        size = serializedObject.FindProperty("size");
        sizeNormalized = serializedObject.FindProperty("sizeNormalized");
        
        growDirection = serializedObject.FindProperty("growDirection");
        
        radialOffset = serializedObject.FindProperty("radialOffset");
        radialLength = serializedObject.FindProperty("radialLength");
        
        labelEnabled = serializedObject.FindProperty("labelEnabled");
        labelSkin = serializedObject.FindProperty("labelSkin");
        labelPosition = serializedObject.FindProperty("labelPosition");
        labelFormat = serializedObject.FindProperty("labelFormat");
        labelColor = serializedObject.FindProperty("labelColor");
        labelOutlineEnabled = serializedObject.FindProperty("labelOutlineEnabled");
        labelOutlineColor = serializedObject.FindProperty("labelOutlineColor");
        
        effectBurn = serializedObject.FindProperty("effectBurn");
        effectBurnTextureBar = serializedObject.FindProperty("effectBurnTextureBar");
        effectBurnTextureBarColor = serializedObject.FindProperty("effectBurnTextureBarColor");
        
        effectBlink = serializedObject.FindProperty("effectBlink");
        effectBlinkValue = serializedObject.FindProperty("effectBlinkValue");
        effectBlinkRatePerSecond = serializedObject.FindProperty("effectBlinkRatePerSecond");
        effectBlinkColor = serializedObject.FindProperty("effectBlinkColor");
        
    }
    
    public override void OnInspectorGUI() {
        serializedObject.Update();
        
        var t = target as EnergyBarRenderer;
        
        if (Foldout("Textures", true)) {
            BeginBox();
            FieldBackgroundTextures();
            
            EditorGUILayout.PropertyField(textureBar, new GUIContent("Bar Texture"));         
            CheckTextureIsReadable(t.textureBar);
            CheckTextureFilterTypeNotPoint(t.textureBar);
            
            FieldForegroundTextures();
            
            FieldPremultipliedAlpha();
            EndBox();
        }
        
        if (Foldout("Position & Size", true)) {
            BeginBox();
            
            PropertyFieldVector2(screenPosition, "Position");
            
            EditorGUI.indentLevel++;
            PropertySpecialNormalized(screenPosition, screenPositionNormalized);
            PropertyField(pivot, "Pivot");
            PropertyField(anchorObject, "Anchor");
            PropertyField(anchorCamera, "Anchor Camera", "Camera on which world coordinates will be translated to "
                + "screen coordinates.");
            EditorGUI.indentLevel--;
            
            PropertyField(guiDepth, "GUI Depth");
            
//            screenPositionCalculateSize.boolValue = !EditorGUILayout.BeginToggleGroup("Manual Size", !screenPositionCalculateSize.boolValue);
            PropertyFieldToggleGroupInv2(screenPositionCalculateSize, "Manual Size", () => {
                Indent(() => {
                    PropertyFieldVector2(size, "Size");
                    EditorGUI.indentLevel++;
                    PropertySpecialNormalized(size, sizeNormalized);
                    EditorGUI.indentLevel--;
                });
            });
            
            FieldRelativeToTransform();
            EndBox();
        }
        
        if (Foldout("Appearance", false)) {
            BeginBox();
            
            var dir = (EnergyBarRenderer.GrowDirection) growDirection.enumValueIndex;
        
            if (dir == EnergyBarRenderer.GrowDirection.ColorChange) {
                GUI.enabled = false;
            }
            EditorGUILayout.PropertyField(textureBarColorType, new GUIContent("Bar Color Type"));
            EditorGUI.indentLevel++;
                switch ((EnergyBarRenderer.ColorType)textureBarColorType.enumValueIndex) {
                    case EnergyBarRenderer.ColorType.Solid:
                        EditorGUILayout.PropertyField(textureBarColor, new GUIContent("Bar Color"));
                        break;
                        
                    case EnergyBarRenderer.ColorType.Gradient:
                        EditorGUILayout.PropertyField(textureBarGradient, new GUIContent("Bar Gradient"));
                        break;
                }
                
            EditorGUI.indentLevel--;
            
            GUI.enabled = true;
            
            EditorGUILayout.PropertyField(growDirection, new GUIContent("Grow Direction"));
            
            if (dir == EnergyBarRenderer.GrowDirection.RadialCW || dir == EnergyBarRenderer.GrowDirection.RadialCCW) {
                Indent(() => {
                    EditorGUILayout.Slider(radialOffset, -1, 1, "Offset");
                    EditorGUILayout.Slider(radialLength, 0, 1, "Length");
                });
            } else if (dir == EnergyBarRenderer.GrowDirection.ColorChange) {
                EditorGUILayout.PropertyField(textureBarGradient, new GUIContent("Bar Gradient"));
            }
            
            PropertyFieldToggleGroup2(labelEnabled, "Draw Label", () => {
                Indent(() => {
                    EditorGUILayout.PropertyField(labelSkin, new GUIContent("Label Skin"));
            
                    labelPosition.vector2Value = EditorGUILayout.Vector2Field("Label Position", labelPosition.vector2Value);
                    EditorGUILayout.PropertyField(labelFormat, new GUIContent("Label Format"));
                    
                    if (Foldout("Label Format Help", false)) {
                        EditorGUILayout.HelpBox(FormatHelp, MessageType.None);
                    }
                    
                    EditorGUILayout.PropertyField(labelColor, new GUIContent("Label Color"));
                    
                    PropertyFieldToggleGroup2(labelOutlineEnabled, "Label Outline", () => {
                        Indent(() => {
                            EditorGUILayout.PropertyField(labelOutlineColor, new GUIContent("Outline Color"));
                        });
                    });
                });
            });
            
            EndBox();
        }
        
        if (Foldout("Effects", false)) {
            BeginBox();
            
            FieldSmoothEffect();
            
            PropertyFieldToggleGroup2(effectBurn, "Burn Out Effect", () => {
                Indent(() => {
                    PropertyField(effectBurnTextureBar, "Burn Texture Bar");
                    PropertyField(effectBurnTextureBarColor, "Burn Color");
                });
            });
            
            PropertyFieldToggleGroup2(effectBlink, "Blink Effect", () => {
                Indent(() => {
                    PropertyField(effectBlinkValue, "Value");
                    PropertyField(effectBlinkRatePerSecond, "Rate (per second)");
                    PropertyField(effectBlinkColor, "Color");
                });
            });
            
            EndBox();
        }
        
        EditorGUILayout.Space();
        
        serializedObject.ApplyModifiedProperties();
    
//        base.OnInspectorGUI();
    }
    
    // ===========================================================
    // Methods
    // ===========================================================
    
    // ===========================================================
    // Static Methods
    // ===========================================================

    // ===========================================================
    // Inner and Anonymous Classes
    // ===========================================================

}