using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.PostProcessing;
using UnityEditorInternal;
using ModuloKart.CustomVehiclePhysics;

namespace ModuloKart.CustomInspector
{

    [CustomEditor(typeof(VehicleBehavior))]
    public class CustomInspectorBehavior : Editor
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



            VehicleBehavior vehicleBehavior = (VehicleBehavior)target;

            if (!vehicleBehavior.isEditorGUI)
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
            if (showDebugItems || vehicleBehavior.isEditorGUI)
            {
                vehicleBehavior.isCodeDebug = EditorGUILayout.ToggleLeft("Click to debug vehicle in editor", vehicleBehavior.isCodeDebug);
                vehicleBehavior.isEditorGUI = EditorGUILayout.ToggleLeft("Click to switch back to simple inspector", vehicleBehavior.isEditorGUI);
                vehicleBehavior.keepTabsOpen = EditorGUILayout.ToggleLeft("Expand All Sections", vehicleBehavior.keepTabsOpen);
                vehicleBehavior.showRunTimeVariablesOnly = EditorGUILayout.ToggleLeft("View Run-Time Variables Only", vehicleBehavior.showRunTimeVariablesOnly);
            }

            GUILayout.Space(20);


            UpdateStyle(foldoutStyle, colorVehicleComponents);
            showVehicleComponents = EditorGUILayout.Foldout(showVehicleComponents, "Modulo Kart Vehicle Components", foldoutStyle);


            if (showVehicleComponents || vehicleBehavior.keepTabsOpen)
            {
                vehicleBehavior.vehicle_transform = EditorGUILayout.ObjectField("Vehicle Transform", vehicleBehavior.vehicle_transform, typeof(Transform), true) as Transform;
                vehicleBehavior.vehicle_rigidbody = EditorGUILayout.ObjectField("Vehicle Rigidbody", vehicleBehavior.vehicle_rigidbody, typeof(Rigidbody), true) as Rigidbody;
                vehicleBehavior.vehicle_heading_transform = EditorGUILayout.ObjectField("Vehicle Heading", vehicleBehavior.vehicle_heading_transform, typeof(Transform), true) as Transform;
                vehicleBehavior.vehicle_camera_transform = EditorGUILayout.ObjectField("Vehicle Camera", vehicleBehavior.vehicle_camera_transform, typeof(Transform), true) as Transform;

                vehicleBehavior.axel_rr_transform = EditorGUILayout.ObjectField("Axel: Rear Right", vehicleBehavior.axel_rr_transform, typeof(Transform), true) as Transform;
                vehicleBehavior.axel_rl_transform = EditorGUILayout.ObjectField("Axel: Rear Left", vehicleBehavior.axel_rl_transform, typeof(Transform), true) as Transform;
                vehicleBehavior.axel_fr_transform = EditorGUILayout.ObjectField("Axel: Front Right", vehicleBehavior.axel_fr_transform, typeof(Transform), true) as Transform;
                vehicleBehavior.axel_fl_transform = EditorGUILayout.ObjectField("Axel: Front Left", vehicleBehavior.axel_fl_transform, typeof(Transform), true) as Transform;
            }
            GUILayout.Space(20);

            UpdateStyle(foldoutStyle, colorVehiclePhysicalAttributes);
            showVehiclePhysicalAttributes = EditorGUILayout.Foldout(showVehiclePhysicalAttributes, "Vehicle Physical Attributes", foldoutStyle);
            if (showVehiclePhysicalAttributes || vehicleBehavior.keepTabsOpen)
            {
                vehicleBehavior.is_4wd = EditorGUILayout.ToggleLeft("Use 4 Wheel Drive", vehicleBehavior.is_4wd);
                vehicleBehavior.width_float = EditorGUILayout.Slider("Vehicle Width", vehicleBehavior.width_float, 0.1f, 10);
                vehicleBehavior.length_float = EditorGUILayout.Slider("Vehicle Length", vehicleBehavior.length_float, 0.1f, 10);
                vehicleBehavior.height_float = EditorGUILayout.Slider("Vehicle Height", vehicleBehavior.height_float, 0.1f, 10);
            }

            GUILayout.Space(20);

            UpdateStyle(foldoutStyle, colorPostProfiling);
            showPostProfiling = EditorGUILayout.Foldout(showPostProfiling, "Post Profiling", foldoutStyle);
            if (showPostProfiling || vehicleBehavior.keepTabsOpen)
            {
                vehicleBehavior.vehicle_camera_postprocess_behavior = EditorGUILayout.ObjectField("Post Process Behavior", vehicleBehavior.vehicle_camera_postprocess_behavior, typeof(PostProcessingBehaviour), true) as PostProcessingBehaviour;
                vehicleBehavior.vehicle_camera_profile = EditorGUILayout.ObjectField("Post Process Profile", vehicleBehavior.vehicle_camera_profile, typeof(PostProcessingProfile), true) as PostProcessingProfile;
            }

            GUILayout.Space(20);

            UpdateStyle(foldoutStyle, colorCinematics);
            showCinematics = EditorGUILayout.Foldout(showCinematics, "Cinematics", foldoutStyle);
            if (showCinematics || vehicleBehavior.keepTabsOpen)
            {
                vehicleBehavior.is_Cinematic_View = EditorGUILayout.ToggleLeft("Enable Cinematic View", vehicleBehavior.is_Cinematic_View);
                vehicleBehavior.min_fov_float = EditorGUILayout.Slider("Cinematic -> FOV: Min", vehicleBehavior.min_fov_float, 60, 110);
                vehicleBehavior.max_fov_float = EditorGUILayout.Slider("Cinematic -> FOV: Max", vehicleBehavior.max_fov_float, 110, 160);
                vehicleBehavior.pan_away_float = EditorGUILayout.Slider("Cinematic -> Camera Pan Away Smoothness", vehicleBehavior.pan_away_float, 5, 50);
                vehicleBehavior.pan_toward_float = EditorGUILayout.Slider("Cinematic -> Camera Pan Toward Smoothness", vehicleBehavior.pan_toward_float, 5, 50);
                vehicleBehavior.is_MotionBlur = EditorGUILayout.ToggleLeft("Enable Motion Blur", vehicleBehavior.is_MotionBlur);
            }

            GUILayout.Space(20);

            UpdateStyle(foldoutStyle, colorRunTimeVariables);
            showRunTimeVariables = EditorGUILayout.Foldout(showRunTimeVariables, "[RUN TIME] Vehicle Movement Variables", foldoutStyle);
            if (showRunTimeVariables || vehicleBehavior.keepTabsOpen || vehicleBehavior.showRunTimeVariablesOnly)
            {
                //Do not show: Ground_Check_Ray
                //Do not show: GroundCheck_hits
                //public bool is_grounded;
                vehicleBehavior.is_grounded = EditorGUILayout.ToggleLeft("Is Vehicle Grounded", vehicleBehavior.is_grounded);
                vehicleBehavior.gravity_float = (float)EditorGUILayout.FloatField("Current Gravity", vehicleBehavior.gravity_float);
                vehicleBehavior.max_accel_modified = EditorGUILayout.FloatField("Current Maximum Target Speed", vehicleBehavior.max_accel_modified);
                vehicleBehavior.wheel_steer_float = EditorGUILayout.FloatField("Current Wheel Steer", vehicleBehavior.wheel_steer_float);
                vehicleBehavior.max_steer_modified = EditorGUILayout.FloatField("Current Maximum Target Vehicle Steering", vehicleBehavior.max_steer_modified);
                vehicleBehavior.accel_magnitude_float = EditorGUILayout.FloatField("Current Acceleration", vehicleBehavior.accel_magnitude_float);
                vehicleBehavior.steer_magnitude_float = EditorGUILayout.FloatField("Current Steering", vehicleBehavior.steer_magnitude_float);
                vehicleBehavior.brake_magnitude_float = EditorGUILayout.FloatField("Current Breaking", vehicleBehavior.brake_magnitude_float);
                vehicleBehavior.drift_correction_float = EditorGUILayout.FloatField("Current Drift Correction", vehicleBehavior.drift_correction_float);
                vehicleBehavior.nitros_meter_float = EditorGUILayout.FloatField("Current Nitros Meter", vehicleBehavior.nitros_meter_float);
                vehicleBehavior.nitros_speed_float = EditorGUILayout.FloatField("Current Nitros Speed", vehicleBehavior.nitros_speed_float);
                vehicleBehavior.tiltLerp_float = EditorGUILayout.FloatField("Current Slope Adjustment", vehicleBehavior.tiltLerp_float);
                vehicleBehavior.vehicle_air_height = EditorGUILayout.FloatField("Current Vehicle Air Height", vehicleBehavior.vehicle_air_height);
                vehicleBehavior.vehicle_air_control = EditorGUILayout.FloatField("Current Air Control", vehicleBehavior.vehicle_air_control);
                vehicleBehavior.vehicle_speed_turn_ratio = EditorGUILayout.FloatField("Current Vehicle Speed Turn Ratio", vehicleBehavior.vehicle_speed_turn_ratio);
                vehicleBehavior.is_drift = EditorGUILayout.ToggleLeft("Is Vehicle Drifting", vehicleBehavior.is_drift);
                vehicleBehavior.is_nitrosboost = EditorGUILayout.ToggleLeft("Use Vechicle Nitros", vehicleBehavior.is_nitrosboost);
            }

            GUILayout.Space(20);

            UpdateStyle(foldoutStyle, colorMaxMinValues);
            showMaxMinValues = EditorGUILayout.Foldout(showMaxMinValues, "Max and Min Vehicle Movement Values", foldoutStyle);
            if (showMaxMinValues || vehicleBehavior.keepTabsOpen)
            {
                vehicleBehavior.max_gravity_float = EditorGUILayout.Slider("Max Gravity", vehicleBehavior.max_gravity_float, 0, 500);
                vehicleBehavior.max_steer_float = EditorGUILayout.Slider("Max Steering", vehicleBehavior.max_steer_float, 0, 50);
                vehicleBehavior.max_accel_float = EditorGUILayout.Slider("Max Acceleration", vehicleBehavior.max_accel_float, 0, 500);
                vehicleBehavior.max_brake_float = EditorGUILayout.Slider("Max Braking", vehicleBehavior.max_brake_float, 0, 500);
                vehicleBehavior.min_drift_correction_float = EditorGUILayout.Slider("Min Drift Correction", vehicleBehavior.min_drift_correction_float, 0, 1);
                vehicleBehavior.max_drift_correction_float = EditorGUILayout.Slider("Max Drift Correction", vehicleBehavior.max_drift_correction_float, 0, 1);
                vehicleBehavior.drift_correction_multiplier = EditorGUILayout.Slider("Drift Correction Multiplier", vehicleBehavior.drift_correction_multiplier, 0, 0.1f);
                vehicleBehavior.drift_accel_multiplier_float = EditorGUILayout.Slider("Drift Accel Multiplier", vehicleBehavior.drift_accel_multiplier_float, 0, 1f);
                vehicleBehavior.drift_turn_ratio_float = EditorGUILayout.Slider("Drift Turn Ratio", vehicleBehavior.drift_turn_ratio_float, 0, 1);
                vehicleBehavior.max_nitros_meter_float = EditorGUILayout.Slider("Max Nitros Meter", vehicleBehavior.max_nitros_meter_float, 0, 100);
                vehicleBehavior.max_nitros_speed_float = EditorGUILayout.Slider("Max Nitros Speed", vehicleBehavior.max_nitros_speed_float, 0, 100);
                vehicleBehavior.nitros_depletion_rate = EditorGUILayout.Slider("Nitros Ddepletion Rate", vehicleBehavior.nitros_depletion_rate, 0, 20);
                vehicleBehavior.min_air_control = EditorGUILayout.Slider("Nitros Ddepletion Rate", vehicleBehavior.min_air_control, 0, 1);
            }

            GUILayout.Space(20);

            UpdateStyle(foldoutStyle, colorLayersGroundSlope);
            showLayersGroundSlope = EditorGUILayout.Foldout(showLayersGroundSlope, "Ground and Slope Layers", foldoutStyle);
            if (showLayersGroundSlope || vehicleBehavior.keepTabsOpen)
            {
                LayerMask tempMask = EditorGUILayout.MaskField(InternalEditorUtility.LayerMaskToConcatenatedLayersMask(vehicleBehavior.rayCast_layerMask), InternalEditorUtility.layers);

                //This goes by regular numbers not bit numbers for this particular case...
                tempMask = ~(1 << 1 | 1 << 4 | 1 << 5);
                vehicleBehavior.rayCast_layerMask = InternalEditorUtility.ConcatenatedLayersMaskToLayerMask(tempMask);
                //Debug.Log("Masks are: " + vehiclleBehavior.rayCast_layerMask);
                vehicleBehavior.slope_ray_dist_float = EditorGUILayout.Slider("Slope Adjustment Distance", vehicleBehavior.slope_ray_dist_float, 10f, 10000f);
            }

            GUILayout.Space(20);

            UpdateStyle(foldoutStyle, colorInputResponsiveness);
            showInputResponsiveness = EditorGUILayout.Foldout(showInputResponsiveness, "Input Responsiveness", foldoutStyle);
            if (showInputResponsiveness || vehicleBehavior.keepTabsOpen)
            {
                vehicleBehavior.ACCEL = EditorGUILayout.Slider("ACCEL", vehicleBehavior.ACCEL, 0, 100);
                vehicleBehavior.DRAG = EditorGUILayout.Slider("DRAG", vehicleBehavior.DRAG, 0, 100);
                vehicleBehavior.ROTATIONAL_DRAG = EditorGUILayout.Slider("ROTATIONAL DRAG", vehicleBehavior.ROTATIONAL_DRAG, 0, 100);
                vehicleBehavior.GRAVITY = EditorGUILayout.Slider("GRAVITY", vehicleBehavior.GRAVITY, 1, 2000);
                vehicleBehavior.STEER = EditorGUILayout.Slider("STEER", vehicleBehavior.STEER, 1, 30);
                vehicleBehavior.STEER_DECELERATION = EditorGUILayout.Slider("STEER DECELERATION", vehicleBehavior.STEER_DECELERATION, 1, 50);
                vehicleBehavior.DRIFT_ACCELERATION = EditorGUILayout.Slider("DRIFT ACCELERATION", vehicleBehavior.DRIFT_ACCELERATION, 1, 50);
                vehicleBehavior.DRIFT_STEER_DAMPEN = EditorGUILayout.Slider("DRIFT STEER DAMPEN", vehicleBehavior.DRIFT_STEER_DAMPEN, 1, 50);
            }

            GUILayout.Space(20);

            UpdateStyle(foldoutStyle, colorInputType);
            showInputType = EditorGUILayout.Foldout(showInputType, "Input Types", foldoutStyle);
            if (showInputType || vehicleBehavior.keepTabsOpen)
            {
                vehicleBehavior.input_type_enum = (InputType)EditorGUILayout.EnumFlagsField("Input Type", vehicleBehavior.input_type_enum);
                vehicleBehavior.PlayerNum = EditorGUILayout.IntSlider("Player Number", vehicleBehavior.PlayerNum, 1, 4);
                vehicleBehavior.input_steering = EditorGUILayout.TextField("Input Steering", vehicleBehavior.input_steering);
                vehicleBehavior.input_accelerate = EditorGUILayout.TextField("Input Accelerate", vehicleBehavior.input_accelerate);
                vehicleBehavior.input_drift = EditorGUILayout.TextField("Input Drift", vehicleBehavior.input_drift);
                vehicleBehavior.input_nitros = EditorGUILayout.TextField("Input Nitros", vehicleBehavior.input_nitros);
            }


        }
        //    */
    }

}