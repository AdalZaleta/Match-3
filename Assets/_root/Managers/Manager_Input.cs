using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace TAAI
{
	public class Manager_Input : MonoBehaviour {

		void Awake()
		{
            //SE OCUOPA DECIRLEA AL MANAGER STATIC QUIEN ES SI MANAGER DE INPUTS
			Manager_Static.inputManager = this;
		}

		void Update()
		{
			//CODIGO DE LOS INPUTS DEPENDIENDO DEL ESTADO DEL JUEGO

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION DE LA APLIACION ESTA EN PAUSA
			if (Manager_Static.appManager.currentState == AppState.pause_menu)
            {
			}

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION DE LA APLIACION ESTA EN EL MENU PRINCIPAL
            else if (Manager_Static.appManager.currentState == AppState.main_menu)
            {
			}

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION DE LA APLIACION ESTA EN GAMEPLAY
            else if (Manager_Static.appManager.currentState == AppState.gameplay)
            {
			}

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION DE LA APLIACION ESTA EN FIN DEL JUEGO
            else if (Manager_Static.appManager.currentState == AppState.end_game)
            {
			}
		}
    }
}
