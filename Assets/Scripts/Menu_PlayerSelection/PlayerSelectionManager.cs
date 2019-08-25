using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ModuloKart.Controls;
using ModuloKart.CustomVehiclePhysics;

namespace ModuloKart.PlayerSelectionMenu
{
    public enum NumPlayerOption
    {
        players1 = 1,
        players2 = 2,
        players3 = 3,
        players4 = 4,
        returnToMain = -1,
    }
    public class PlayerSelectionManager : MonoBehaviour
    {
        PlayerSelectionManager Instance;

        private GameObject bg_Numplayers1;
        private GameObject bg_Numplayers2;
        private GameObject bg_Numplayers3;
        private GameObject bg_Numplayers4;
        private GameObject bg_ReturnToMain;

        public NumPlayerOption numPlayerOption;
        public bool inGameScene;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }

            GetPlayerSelectionOptions();
            InitPlayerOptions();
        }

        void Update()
        {
            if (inGameScene)
                return;

            NumPlayerSelectionNext();
            NumPlayerSelectionPrev();
            ConfirmNumberPlayers();
        }


        bool isPressPrev;
        bool isPressPrevRelease;
        private void NumPlayerSelectionPrev()
        {
            if (Input.GetAxis("LeftJoyStickY_ANYPLAYER") < 0)
            {
                isPressPrev = true;
            }
            if (isPressPrev)
            {
                if (Input.GetAxis("LeftJoyStickY_ANYPLAYER") == 0)
                {
                    isPressPrev = false;
                    isPressPrevRelease = true;
                }
            }
            if (isPressPrevRelease)
            {
                isPressPrevRelease = false;

                switch (numPlayerOption)
                {
                    case NumPlayerOption.players1:
                        numPlayerOption = NumPlayerOption.returnToMain;
                        bg_Numplayers1.SetActive(true);
                        bg_Numplayers2.SetActive(true);
                        bg_Numplayers3.SetActive(true);
                        bg_Numplayers4.SetActive(true);
                        bg_ReturnToMain.SetActive(false);
                        break;
                    case NumPlayerOption.players2:
                        numPlayerOption = NumPlayerOption.players1;
                        bg_Numplayers1.SetActive(false);
                        bg_Numplayers2.SetActive(true);
                        bg_Numplayers3.SetActive(true);
                        bg_Numplayers4.SetActive(true);
                        bg_ReturnToMain.SetActive(true);
                        break;
                    case NumPlayerOption.players3:
                        numPlayerOption = NumPlayerOption.players2;
                        bg_Numplayers1.SetActive(true);
                        bg_Numplayers2.SetActive(false);
                        bg_Numplayers3.SetActive(true);
                        bg_Numplayers4.SetActive(true);
                        bg_ReturnToMain.SetActive(true);
                        break;
                    case NumPlayerOption.players4:
                        numPlayerOption = NumPlayerOption.players3;
                        bg_Numplayers1.SetActive(true);
                        bg_Numplayers2.SetActive(true);
                        bg_Numplayers3.SetActive(false);
                        bg_Numplayers4.SetActive(true);
                        bg_ReturnToMain.SetActive(true);
                        break;
                    case NumPlayerOption.returnToMain:
                        numPlayerOption = NumPlayerOption.players4;
                        bg_Numplayers1.SetActive(true);
                        bg_Numplayers2.SetActive(true);
                        bg_Numplayers3.SetActive(true);
                        bg_Numplayers4.SetActive(false);
                        bg_ReturnToMain.SetActive(true);
                        break;
                    default:
                        Debug.Log("Unexpected Player Number Selection Option");
                        break;
                }
            }
        }


        bool isPressNext;
        bool isPressNextRelease;
        private void NumPlayerSelectionNext()
        {
            if (Input.GetAxis("LeftJoyStickY_ANYPLAYER") > 0)
            {
                isPressNext = true;
            }
            if (isPressNext)
            {
                if (Input.GetAxis("LeftJoyStickY_ANYPLAYER") == 0)
                {
                    isPressNext = false;
                    isPressNextRelease = true;
                }
            }
            if (isPressNextRelease)
            {
                isPressNextRelease = false;

                switch (numPlayerOption)
                {
                    case NumPlayerOption.players1:
                        numPlayerOption = NumPlayerOption.players2;
                        bg_Numplayers1.SetActive(true);
                        bg_Numplayers2.SetActive(false);
                        bg_Numplayers3.SetActive(true);
                        bg_Numplayers4.SetActive(true);
                        bg_ReturnToMain.SetActive(true);
                        break;
                    case NumPlayerOption.players2:
                        numPlayerOption = NumPlayerOption.players3;
                        bg_Numplayers1.SetActive(true);
                        bg_Numplayers2.SetActive(true);
                        bg_Numplayers3.SetActive(false);
                        bg_Numplayers4.SetActive(true);
                        bg_ReturnToMain.SetActive(true);
                        break;
                    case NumPlayerOption.players3:
                        numPlayerOption = NumPlayerOption.players4;
                        bg_Numplayers1.SetActive(true);
                        bg_Numplayers2.SetActive(true);
                        bg_Numplayers3.SetActive(true);
                        bg_Numplayers4.SetActive(false);
                        bg_ReturnToMain.SetActive(true);
                        break;
                    case NumPlayerOption.players4:
                        numPlayerOption = NumPlayerOption.returnToMain;
                        bg_Numplayers1.SetActive(true);
                        bg_Numplayers2.SetActive(true);
                        bg_Numplayers3.SetActive(true);
                        bg_Numplayers4.SetActive(true);
                        bg_ReturnToMain.SetActive(false);
                        break;
                    case NumPlayerOption.returnToMain:
                        numPlayerOption = NumPlayerOption.players1;
                        bg_Numplayers1.SetActive(false);
                        bg_Numplayers2.SetActive(true);
                        bg_Numplayers3.SetActive(true);
                        bg_Numplayers4.SetActive(true);
                        bg_ReturnToMain.SetActive(true);
                        break;
                    default:
                        Debug.Log("Unexpected Player Number Selection Option");
                        break;
                }
            }
        }

        private void InitPlayerOptions()
        {
            numPlayerOption = NumPlayerOption.players1;
            bg_Numplayers1.SetActive(false);
            bg_Numplayers2.SetActive(true);
            bg_Numplayers3.SetActive(true);
            bg_Numplayers4.SetActive(true);
            bg_ReturnToMain.SetActive(true);
        }

        private void GetPlayerSelectionOptions()
        {
            PlayerSelectionOption[] temp = GameObject.FindObjectsOfType<PlayerSelectionOption>();

            foreach (PlayerSelectionOption t in temp)
            {
                if (t.numplayerOption.Equals(NumPlayerOption.players1))
                {
                    bg_Numplayers1 = t.bg;
                }
                else if (t.numplayerOption.Equals(NumPlayerOption.players2))
                {
                    bg_Numplayers2 = t.bg;
                }
                else if (t.numplayerOption.Equals(NumPlayerOption.players3))
                {
                    bg_Numplayers3 = t.bg;
                }
                else if (t.numplayerOption.Equals(NumPlayerOption.players4))
                {
                    bg_Numplayers4 = t.bg;
                }
                else if (t.numplayerOption.Equals(NumPlayerOption.returnToMain))
                {
                    bg_ReturnToMain = t.bg;
                }
            }
        }

        private void ConfirmNumberPlayers()
        {
            if (Input.GetButtonDown("A_ANYPLAYER"))
            {
                switch (numPlayerOption)
                {
                    case NumPlayerOption.players1:
                        ButtonBehavior_LoadGameScene();
                        break;
                    case NumPlayerOption.players2:
                        ButtonBehavior_LoadGameScene();
                        break;
                    case NumPlayerOption.players3:
                        ButtonBehavior_LoadGameScene();
                        break;
                    case NumPlayerOption.players4:
                        ButtonBehavior_LoadGameScene();
                        break;
                    case NumPlayerOption.returnToMain:
                        ButtonBehavior_ReturnToMain();
                        break;
                    default:
                        Debug.Log("Unexpected Player Number Selection Option");
                        break;
                }
            }
        }

        public void ButtonBehavior_ReturnToMain()
        {
            SceneManager.LoadScene(0);
        }

        public void ButtonBehavior_LoadGameScene()
        {
            SceneManager.LoadScene(2);
        }

        ControllerHandler controller;
        private void OnLevelWasLoaded(int level)
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
            {
                Destroy(this.gameObject);
            }

                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2))
            {
                inGameScene = true;
                ControllerHandler controllerHandler = GameObject.FindObjectOfType<ControllerHandler>();
                controllerHandler.ControllersToAssign = (int)numPlayerOption;
                Debug.Log("Number of Controllers To Begin Assigning: " + controllerHandler.ControllersToAssign);

                switch (numPlayerOption)
                {
                    case NumPlayerOption.players1:
                        controllerHandler.vehicle2.gameObject.SetActive(false);
                        controllerHandler.vehicle3.gameObject.SetActive(false);
                        controllerHandler.vehicle4.gameObject.SetActive(false);

                        controllerHandler.HUDPlayer2.gameObject.SetActive(false);
                        controllerHandler.HUDPlayer3.gameObject.SetActive(false);
                        controllerHandler.HUDPlayer4.gameObject.SetActive(false);

                        //FullScreen
                        controllerHandler.vehicle1.vehicle_camera_transform.GetComponent<Camera>().rect = new Rect(0, 0, 1, 1);
                        controllerHandler.HUDPlayer1.ViewPortRect.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                        controllerHandler.HUDPlayer1.ViewPortRect.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                        controllerHandler.HUDPlayer1.ViewPortRect.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                        controllerHandler.HUDPlayer1.ViewPortRect.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
                        break;
                    case NumPlayerOption.players2:
                        controllerHandler.vehicle3.gameObject.SetActive(false);
                        controllerHandler.vehicle4.gameObject.SetActive(false);

                        controllerHandler.HUDPlayer3.gameObject.SetActive(false);
                        controllerHandler.HUDPlayer4.gameObject.SetActive(false);

                        //Top
                        controllerHandler.vehicle1.vehicle_camera_transform.GetComponent<Camera>().rect = new Rect(0, 0.5f, 1, 0.5f);

                        controllerHandler.HUDPlayer1.ViewPortRect.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
                        controllerHandler.HUDPlayer1.ViewPortRect.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                        controllerHandler.HUDPlayer1.ViewPortRect.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                        controllerHandler.HUDPlayer1.ViewPortRect.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

                        //Bottom
                        controllerHandler.vehicle2.vehicle_camera_transform.GetComponent<Camera>().rect = new Rect(0, 0f, 1, 0.5f);

                        controllerHandler.HUDPlayer2.ViewPortRect.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
                        controllerHandler.HUDPlayer2.ViewPortRect.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
                        controllerHandler.HUDPlayer2.ViewPortRect.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                        controllerHandler.HUDPlayer2.ViewPortRect.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

                        break;
                    case NumPlayerOption.players3:
                        controllerHandler.vehicle4.gameObject.SetActive(false);

                        controllerHandler.HUDPlayer4.gameObject.SetActive(false);

                        //Top
                        controllerHandler.vehicle1.vehicle_camera_transform.GetComponent<Camera>().rect = new Rect(0, 0.5f, 1, 0.5f);
                        controllerHandler.HUDPlayer1.ViewPortRect.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0.5f);
                        controllerHandler.HUDPlayer1.ViewPortRect.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                        controllerHandler.HUDPlayer1.ViewPortRect.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                        controllerHandler.HUDPlayer1.ViewPortRect.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

                        //Bottom Left
                        controllerHandler.vehicle2.vehicle_camera_transform.GetComponent<Camera>().rect = new Rect(0, 0f, 0.5f, 0.5f);
                        controllerHandler.HUDPlayer2.ViewPortRect.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0f);
                        controllerHandler.HUDPlayer2.ViewPortRect.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
                        controllerHandler.HUDPlayer2.ViewPortRect.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                        controllerHandler.HUDPlayer2.ViewPortRect.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

                        //Bottom Right
                        controllerHandler.vehicle3.vehicle_camera_transform.GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 0.5f);
                        controllerHandler.HUDPlayer3.ViewPortRect.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0f);
                        controllerHandler.HUDPlayer3.ViewPortRect.GetComponent<RectTransform>().anchorMax = new Vector2(1, 0.5f);
                        controllerHandler.HUDPlayer3.ViewPortRect.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
                        controllerHandler.HUDPlayer3.ViewPortRect.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);

                        break;
                    case NumPlayerOption.players4:
                        break;
                    case NumPlayerOption.returnToMain:
                        break;
                    default:
                        break;
                }
            }
        }


    }
}