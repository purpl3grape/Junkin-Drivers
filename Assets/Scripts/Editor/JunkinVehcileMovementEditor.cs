using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.PostProcessing;
using UnityEditorInternal;

[CustomEditor(typeof(JunkinVehcileMovement))]
public class JunkinVehcileMovementEditor : Editor
{
    //    /*
    public bool showDebugItems;
    public bool showVehicleComponents;
    public bool showPostProfiling;
    public bool showCinematics;
    public bool showInputType;
    public bool showVehiclePhysicalAttributes;
    public bool showRunTimeVariables;
    public bool showMaxMinValues;
    public bool showLayersGroundSlope;
    public bool showInputResponsiveness;

    Color colorDebug = new Color(50f / 255f, 50f / 255f, 50f / 255f);
    Color colorVehicleComponents = new Color(100f / 255f, 175f / 255f, 50f / 255f);
    Color colorVehiclePhysicalAttributes = new Color(100f / 255f, 175f / 255f, 50f / 255f);
    Color colorPostProfiling = new Color(100f / 255f, 25f / 255f, 200f / 255f);
    Color colorCinematics = new Color(100f / 255f, 25f / 255f, 200f / 255f);
    Color colorRunTimeVariables = new Color(200f / 255f, 50f / 255f, 100f / 255f);
    Color colorMaxMinValues = new Color(200f / 255f, 50f / 255f, 100f / 255f);
    Color colorLayersGroundSlope = new Color(50f / 255f, 125f / 255f, 150f / 255f);
    Color colorInputResponsiveness = new Color(200f / 255f, 125f / 255f, 0f / 255f);
    Color colorInputType = new Color(200f / 255f, 125f / 255f, 0f / 255f);

    public void UpdateStyle(GUIStyle foldoutStyle, Color foldoutStyleColor)
    {
        foldoutStyle.fontStyle = FontStyle.Bold;
        foldoutStyle.normal.textColor = foldoutStyleColor;
        foldoutStyle.onNormal.textColor = foldoutStyleColor;
        foldoutStyle.hover.textColor = foldoutStyleColor;
        foldoutStyle.onHover.textColor = foldoutStyleColor;
        foldoutStyle.focused.textColor = foldoutStyleColor;
        foldoutStyle.onFocused.textColor = foldoutStyleColor;
        foldoutStyle.active.textColor = foldoutStyleColor;
        foldoutStyle.onActive.textColor = foldoutStyleColor;
    }

    public override void OnInspectorGUI()
    {
        

        
        JunkinVehcileMovement junkinVehcileMovement = (JunkinVehcileMovement)target;

        if (!junkinVehcileMovement.isEditorGUI)
        {
            base.OnInspectorGUI();
            return;
        }

        GUIStyle foldoutStyle = new GUIStyle(EditorStyles.foldout);
        Color foldoutStyleColor = colorVehicleComponents;
        foldoutStyle.fontStyle = FontStyle.Bold;
        foldoutStyle.normal.textColor = foldoutStyleColor;
        foldoutStyle.onNormal.textColor = foldoutStyleColor;
        foldoutStyle.hover.textColor = foldoutStyleColor;
        foldoutStyle.onHover.textColor = foldoutStyleColor;
        foldoutStyle.focused.textColor = foldoutStyleColor;
        foldoutStyle.onFocused.textColor = foldoutStyleColor;
        foldoutStyle.active.textColor = foldoutStyleColor;
        foldoutStyle.onActive.textColor = foldoutStyleColor;

        GUILayout.Space(20);
        UpdateStyle(foldoutStyle, colorDebug);
        showDebugItems = EditorGUILayout.Foldout(showDebugItems, "Debug Menu", foldoutStyle);
        if (showDebugItems || junkinVehcileMovement.isEditorGUI)
        {
            junkinVehcileMovement.isCodeDebug = EditorGUILayout.ToggleLeft("Click to debug vehicle in editor", junkinVehcileMovement.isCodeDebug);
            junkinVehcileMovement.isEditorGUI = EditorGUILayout.ToggleLeft("Click to switch back to simple inspector", junkinVehcileMovement.isEditorGUI);
            junkinVehcileMovement.keepTabsOpen = EditorGUILayout.ToggleLeft("Expand All Sections", junkinVehcileMovement.keepTabsOpen);
            junkinVehcileMovement.showRunTimeVariablesOnly = EditorGUILayout.ToggleLeft("View Run-Time Variables Only", junkinVehcileMovement.showRunTimeVariablesOnly);
        }

        GUILayout.Space(20);


        UpdateStyle(foldoutStyle, colorVehicleComponents);
        showVehicleComponents = EditorGUILayout.Foldout(showVehicleComponents, "Junkin Vehicle Components", foldoutStyle);


        if (showVehicleComponents || junkinVehcileMovement.keepTabsOpen)
        {
            junkinVehcileMovement.vehicle_transform = EditorGUILayout.ObjectField("Vehicle Transform", junkinVehcileMovement.vehicle_transform, typeof(Transform), true) as Transform;
            junkinVehcileMovement.vehicle_rigidbody = EditorGUILayout.ObjectField("Vehicle Rigidbody", junkinVehcileMovement.vehicle_rigidbody, typeof(Rigidbody), true) as Rigidbody;
            junkinVehcileMovement.vehicle_heading_transform = EditorGUILayout.ObjectField("Vehicle Heading", junkinVehcileMovement.vehicle_heading_transform, typeof(Transform), true) as Transform;
            junkinVehcileMovement.vehicle_camera_transform = EditorGUILayout.ObjectField("Vehicle Camera", junkinVehcileMovement.vehicle_camera_transform, typeof(Transform), true) as Transform;

            junkinVehcileMovement.axel_rr_transform = EditorGUILayout.ObjectField("Axel: Rear Right", junkinVehcileMovement.axel_rr_transform, typeof(Transform), true) as Transform;
            junkinVehcileMovement.axel_rl_transform = EditorGUILayout.ObjectField("Axel: Rear Left", junkinVehcileMovement.axel_rl_transform, typeof(Transform), true) as Transform;
            junkinVehcileMovement.axel_fr_transform = EditorGUILayout.ObjectField("Axel: Front Right", junkinVehcileMovement.axel_fr_transform, typeof(Transform), true) as Transform;
            junkinVehcileMovement.axel_fl_transform = EditorGUILayout.ObjectField("Axel: Front Left", junkinVehcileMovement.axel_fl_transform, typeof(Transform), true) as Transform;
        }
        GUILayout.Space(20);

        UpdateStyle(foldoutStyle, colorVehiclePhysicalAttributes);
        showVehiclePhysicalAttributes = EditorGUILayout.Foldout(showVehiclePhysicalAttributes, "Vehicle Physical Attributes", foldoutStyle);
        if (showVehiclePhysicalAttributes || junkinVehcileMovement.keepTabsOpen)
        {
            junkinVehcileMovement.is_4wd = EditorGUILayout.ToggleLeft("Use 4 Wheel Drive", junkinVehcileMovement.is_4wd);
            junkinVehcileMovement.width_float = EditorGUILayout.Slider("Vehicle Width", junkinVehcileMovement.width_float, 0.1f, 10);
            junkinVehcileMovement.length_float = EditorGUILayout.Slider("Vehicle Length", junkinVehcileMovement.length_float, 0.1f, 10);
            junkinVehcileMovement.height_float = EditorGUILayout.Slider("Vehicle Height", junkinVehcileMovement.height_float, 0.1f, 10);
        }

        GUILayout.Space(20);

        UpdateStyle(foldoutStyle, colorPostProfiling);
        showPostProfiling = EditorGUILayout.Foldout(showPostProfiling, "Post Profiling", foldoutStyle);
        if (showPostProfiling || junkinVehcileMovement.keepTabsOpen)
        {
            junkinVehcileMovement.vehicle_camera_postprocess_behavior = EditorGUILayout.ObjectField("Post Process Behavior", junkinVehcileMovement.vehicle_camera_postprocess_behavior, typeof(PostProcessingBehaviour), true) as PostProcessingBehaviour;
            junkinVehcileMovement.vehicle_camera_profile = EditorGUILayout.ObjectField("Post Process Profile", junkinVehcileMovement.vehicle_camera_profile, typeof(PostProcessingProfile), true) as PostProcessingProfile;
        }

        GUILayout.Space(20);

        UpdateStyle(foldoutStyle, colorCinematics);
        showCinematics = EditorGUILayout.Foldout(showCinematics, "Cinematics", foldoutStyle);
        if (showCinematics || junkinVehcileMovement.keepTabsOpen)
        {
            junkinVehcileMovement.is_Cinematic_View = EditorGUILayout.ToggleLeft("Enable Cinematic View", junkinVehcileMovement.is_Cinematic_View);
            junkinVehcileMovement.min_fov_float = EditorGUILayout.Slider("Cinematic -> FOV: Min", junkinVehcileMovement.min_fov_float, 60, 110);
            junkinVehcileMovement.max_fov_float = EditorGUILayout.Slider("Cinematic -> FOV: Max", junkinVehcileMovement.max_fov_float, 110, 160);
            junkinVehcileMovement.pan_away_float = EditorGUILayout.Slider("Cinematic -> Camera Pan Away Smoothness", junkinVehcileMovement.pan_away_float, 5, 50);
            junkinVehcileMovement.pan_toward_float = EditorGUILayout.Slider("Cinematic -> Camera Pan Toward Smoothness", junkinVehcileMovement.pan_toward_float, 5, 50);
            junkinVehcileMovement.is_MotionBlur = EditorGUILayout.ToggleLeft("Enable Motion Blur", junkinVehcileMovement.is_MotionBlur);
        }

        GUILayout.Space(20);

        UpdateStyle(foldoutStyle, colorRunTimeVariables);
        showRunTimeVariables = EditorGUILayout.Foldout(showRunTimeVariables, "[RUN TIME] Vehicle Movement Variables", foldoutStyle);
        if (showRunTimeVariables || junkinVehcileMovement.keepTabsOpen || junkinVehcileMovement.showRunTimeVariablesOnly)
        {
            //Do not show: Ground_Check_Ray
            //Do not show: GroundCheck_hits
            //public bool is_grounded;
            junkinVehcileMovement.is_grounded = EditorGUILayout.ToggleLeft("Is Vehicle Grounded", junkinVehcileMovement.is_grounded);
            junkinVehcileMovement.gravity_float = (float)EditorGUILayout.FloatField("Gravity", junkinVehcileMovement.gravity_float);
            junkinVehcileMovement.max_accel_modified = EditorGUILayout.FloatField("Maximum Target Speed", junkinVehcileMovement.max_accel_modified);
            junkinVehcileMovement.wheel_steer_float = EditorGUILayout.FloatField("Wheel Steer", junkinVehcileMovement.wheel_steer_float);
            junkinVehcileMovement.max_steer_modified = EditorGUILayout.FloatField("Maximum Target Vehicle Steering", junkinVehcileMovement.max_steer_modified);
            junkinVehcileMovement.accel_magnitude_float = EditorGUILayout.FloatField("Current Acceleration", junkinVehcileMovement.accel_magnitude_float);
            junkinVehcileMovement.steer_magnitude_float = EditorGUILayout.FloatField("Current Steering", junkinVehcileMovement.steer_magnitude_float);
            junkinVehcileMovement.brake_magnitude_float = EditorGUILayout.FloatField("Current Breaking", junkinVehcileMovement.brake_magnitude_float);
            junkinVehcileMovement.drift_correction_float = EditorGUILayout.FloatField("Current Drift Correction", junkinVehcileMovement.drift_correction_float);
            junkinVehcileMovement.nitros_meter_float = EditorGUILayout.FloatField("Current Nitros Meter", junkinVehcileMovement.nitros_meter_float);
            junkinVehcileMovement.nitros_speed_float = EditorGUILayout.FloatField("Current Nitros Speed", junkinVehcileMovement.nitros_speed_float);
            junkinVehcileMovement.tiltLerp_float = EditorGUILayout.FloatField("Current Slope Adjustment", junkinVehcileMovement.tiltLerp_float);
            junkinVehcileMovement.is_drift = EditorGUILayout.ToggleLeft("Is Vehicle Drifting", junkinVehcileMovement.is_drift);
            junkinVehcileMovement.is_nitrosboost = EditorGUILayout.ToggleLeft("Use Vechicle Nitros", junkinVehcileMovement.is_nitrosboost);
        }

        GUILayout.Space(20);

        UpdateStyle(foldoutStyle, colorMaxMinValues);
        showMaxMinValues = EditorGUILayout.Foldout(showMaxMinValues, "Max and Min Vehicle Movement Values", foldoutStyle);
        if (showMaxMinValues || junkinVehcileMovement.keepTabsOpen)
        {
            junkinVehcileMovement.max_gravity_float = EditorGUILayout.Slider("Max Gravity", junkinVehcileMovement.max_gravity_float, 0, 500);
            junkinVehcileMovement.max_steer_float = EditorGUILayout.Slider("Max Steering", junkinVehcileMovement.max_steer_float, 0, 50);
            junkinVehcileMovement.max_accel_float = EditorGUILayout.Slider("Max Acceleration", junkinVehcileMovement.max_accel_float, 0, 500);
            junkinVehcileMovement.max_brake_float = EditorGUILayout.Slider("Max Braking", junkinVehcileMovement.max_brake_float, 0, 500);
            junkinVehcileMovement.min_drift_correction_float = EditorGUILayout.Slider("Min Drift Correction", junkinVehcileMovement.min_drift_correction_float, 0, 1);
            junkinVehcileMovement.max_drift_correction_float = EditorGUILayout.Slider("Max Drift Correction", junkinVehcileMovement.max_drift_correction_float, 0, 1);
            junkinVehcileMovement.drift_correction_multiplier = EditorGUILayout.Slider("Drift Correction Multiplier", junkinVehcileMovement.drift_correction_multiplier, 0, 0.1f);
            junkinVehcileMovement.drift_accel_multiplier_float = EditorGUILayout.Slider("Drift Accel Multiplier", junkinVehcileMovement.drift_accel_multiplier_float, 0, 0.1f);
            junkinVehcileMovement.drift_turn_ratio_float = EditorGUILayout.Slider("Drift Turn Ratio", junkinVehcileMovement.drift_turn_ratio_float, 0, 1);
            junkinVehcileMovement.max_nitros_meter_float = EditorGUILayout.Slider("Max Nitros Meter", junkinVehcileMovement.max_nitros_meter_float, 0, 100);
            junkinVehcileMovement.max_nitros_speed_float = EditorGUILayout.Slider("Max Nitros Speed", junkinVehcileMovement.max_nitros_speed_float, 0, 100);
            junkinVehcileMovement.nitros_depletion_rate = EditorGUILayout.Slider("Nitros Ddepletion Rate", junkinVehcileMovement.nitros_depletion_rate, 0, 20);
        }

        GUILayout.Space(20);

        UpdateStyle(foldoutStyle, colorLayersGroundSlope);
        showLayersGroundSlope = EditorGUILayout.Foldout(showLayersGroundSlope, "Ground and Slope Layers", foldoutStyle);
        if (showLayersGroundSlope || junkinVehcileMovement.keepTabsOpen)
        {
            LayerMask tempMask = EditorGUILayout.MaskField(InternalEditorUtility.LayerMaskToConcatenatedLayersMask(junkinVehcileMovement.rayCast_layerMask), InternalEditorUtility.layers);
            
            //This goes by regular numbers not bit numbers for this particular case...
            tempMask = ~(1 << 1 | 1 << 4 | 1 << 5);
            junkinVehcileMovement.rayCast_layerMask = InternalEditorUtility.ConcatenatedLayersMaskToLayerMask(tempMask);
            //Debug.Log("Masks are: " + junkinVehcileMovement.rayCast_layerMask);
            junkinVehcileMovement.slope_ray_dist_float = EditorGUILayout.Slider("Slope Adjustment Distance", junkinVehcileMovement.slope_ray_dist_float, 10f, 10000f);
        }

        GUILayout.Space(20);

        UpdateStyle(foldoutStyle, colorInputResponsiveness);
        showInputResponsiveness = EditorGUILayout.Foldout(showInputResponsiveness, "Input Responsiveness", foldoutStyle);
        if (showInputResponsiveness || junkinVehcileMovement.keepTabsOpen)
        {
            junkinVehcileMovement.ACCEL = EditorGUILayout.Slider("ACCEL", junkinVehcileMovement.ACCEL, 0, 100);
            junkinVehcileMovement.DRAG = EditorGUILayout.Slider("DRAG", junkinVehcileMovement.DRAG, 0, 100);
            junkinVehcileMovement.GRAVITY = EditorGUILayout.Slider("GRAVITY", junkinVehcileMovement.GRAVITY, 1, 100);
            junkinVehcileMovement.STEER = EditorGUILayout.Slider("STEER", junkinVehcileMovement.STEER, 1, 30);
            junkinVehcileMovement.STEER_DECELERATION = EditorGUILayout.Slider("STEER DECELERATION", junkinVehcileMovement.STEER_DECELERATION, 1, 50);
            junkinVehcileMovement.DRIFT_ACCELERATION = EditorGUILayout.Slider("DRIFT ACCELERATION", junkinVehcileMovement.DRIFT_ACCELERATION, 1, 50);
            junkinVehcileMovement.DRIFT_STEER_DAMPEN = EditorGUILayout.Slider("DRIFT STEER DAMPEN", junkinVehcileMovement.DRIFT_STEER_DAMPEN, 1, 50);
        }

        GUILayout.Space(20);

        UpdateStyle(foldoutStyle, colorInputType);
        showInputType = EditorGUILayout.Foldout(showInputType, "Input Types", foldoutStyle);
        if (showInputType || junkinVehcileMovement.keepTabsOpen)
        {
            junkinVehcileMovement.input_type_enum = (InputType)EditorGUILayout.EnumFlagsField("Input Type", junkinVehcileMovement.input_type_enum);
        }

 
    }
    //    */
}