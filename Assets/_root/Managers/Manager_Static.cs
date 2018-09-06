﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TAAI
{

    //ES EL MANAGER STATICO ES UN SCRIPT QUE SE COMUNICA CON TODOS LOS DEMAS SCRIPTS SIN IMPORTA SI ESTA EN LA ESCENA

    //ESTE ES UN ENUMERADOR QUE NOS DICE LOS ESTADOS DE LA APLICACION
    public enum AppState
    {
        main_menu,
        gameplay,
        pause_menu,
        end_game,
        credits
    }

    //ENUMERADO ENCARGADO DE EL MODO EN EL QUE SE ENCUENTRA EL MODO DE JUEGO
    public enum ModeGame
    {
        endless,
        points,
        limitmoves
    }


    //ESTE SE ENCARGARA DE MANTENER A LOS DEMAS MANAGER COMUNICADOS ENTRE ELLOS
	public static class Manager_Static 
	{
		public static Manager_Input inputManager;
		public static Manager_App appManager;
		public static Manager_Scene sceneManager;
	}
}
