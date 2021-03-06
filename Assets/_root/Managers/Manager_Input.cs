﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Mangos
{
	public class Manager_Input : MonoBehaviour {

        public VisualGrid visualGrid;

        public int pickingMode;

		void Awake()
		{
            //SE OCUOPA DECIRLEA AL MANAGER STATIC QUIEN ES SI MANAGER DE INPUTS
			Manager_Static.inputManager = this;

            if (Manager_Static.appManager.currentState == AppState.SCORES)
            {

            }
		}

        bool holding = false;

		void Update()
  	{
            //CODIGO DE LOS INPUTS DEPENDIENDO DEL ESTADO DEL JUEGO

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION ESTA EN GAMEPLAY
            if (Manager_Static.appManager.currentState == AppState.MAIN_MENU)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Manager_Static.appManager.SetPause();
                }
            }

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION ESTA EN PAUSA
            else if (Manager_Static.appManager.currentState == AppState.PAUSE_MENU)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Manager_Static.appManager.SetPlay();
                }
            }

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION ESTA EN GAME END
            else if (Manager_Static.appManager.currentState == AppState.GAME_END)
            {
                if (Input.anyKeyDown)
                {
                    Manager_Static.appManager.SetScores();
                    Manager_Static.sceneManager.LoadScene("PLACEHOLDER_SCORES", false);
                }
            }

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION ESTA EN EL MENU PRINCIPAL
            else if (Manager_Static.appManager.currentState == AppState.GAMEPLAY)
			{
                if (Input.GetMouseButtonDown(0))
                {
                    if (pickingMode == 0)
                    {
                        Ray ray;
                        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit))
                        {
                            if (hit.collider.CompareTag("Candy"))
                            {
                                visualGrid.OnCandyPicked(hit.collider.gameObject);
                                holding = true;
                            }
                            else
                            {
                                Debug.Log("Candy not hit");
                            }
                        }
                    }
                    else if (pickingMode == 1)
                    {
                        Vector3Int clickOn = visualGrid.grid.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                        if(clickOn.x >= 0 && clickOn.x < visualGrid.width && clickOn.y >= 0 && clickOn.y < visualGrid.height)
                            holding = visualGrid.OnCandyPicked(clickOn);
                    }
                }
                else if (Input.GetMouseButton(0) && holding)
                {
                    visualGrid.OnCandyHold(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
                else if (Input.GetMouseButtonUp(0) && holding)
                {
                    holding = false;
                    visualGrid.OnCandyDropped();
                }
			}

	        //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION DE LA APLIACION ESTA EN FIN DEL JUEGO
	        else if (Manager_Static.appManager.currentState == AppState.GAME_END)
	        {
	        }
		}
    }
}
