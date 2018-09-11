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
			}

            //ENTRA EN ESTE IF SI EL ESTADO DE LA APLICACION DE LA APLIACION ESTA EN FIN DEL JUEGO
            else if (Manager_Static.appManager.currentState == AppState.END_GAME)
            {
			}
		}
    }
}
