using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Mangos
{
	public class Manager_Input : MonoBehaviour {

        public VisualGrid visualGrid;

		void Awake()
		{
            //SE OCUOPA DECIRLEA AL MANAGER STATIC QUIEN ES SI MANAGER DE INPUTS
			Manager_Static.inputManager = this;
		}

        bool holding = false;

		void Update()
		{
			//CODIGO DE LOS INPUTS DEPENDIENDO DEL ESTADO DEL JUEGO

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION DE LA APLIACION ESTA EN PAUSA
			if (Manager_Static.appManager.currentState == AppState.PAUSE_MENU)
            {
			}

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION DE LA APLIACION ESTA EN EL MENU PRINCIPAL
            else if (Manager_Static.appManager.currentState == AppState.MAIN_MENU)
            {
			}

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION DE LA APLIACION ESTA EN GAMEPLAY
            else if (Manager_Static.appManager.currentState == AppState.GAMEPLAY)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray;
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if(Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.CompareTag("Candy"))
                        {
                            visualGrid.OnCandyPicked(hit.collider.gameObject);
                            holding = true;
                            Debug.Log("Candy hit");
                        }
                        else
                        {
                            Debug.Log("Candy not hit");
                        }
                    }
                }
                else if (Input.GetMouseButton(0) && holding)
                {
                    visualGrid.OnCandyHold(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
                else if (Input.GetMouseButtonUp(0) && holding)
                {
                    holding = false;
                    visualGrid.OnCandyDropped();
                }
			}

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION DE LA APLIACION ESTA EN FIN DEL JUEGO
            else if (Manager_Static.appManager.currentState == AppState.END_GAME)
            {
			}
		}
    }
}
