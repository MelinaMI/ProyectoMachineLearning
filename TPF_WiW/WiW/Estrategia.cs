
using System;
using System.Collections.Generic;
using tp1;
using tp2;
using System.Collections;

namespace tpfinal
{

	class Estrategia
	{
		
		public ArbolBinario<DecisionData>CrearArbol(Clasificador clasificador)
		{
			/*
 			 * tengo que almacenar en el arbol la pregunta, dependiendo de la respuesta tengo hacer de nuevo otra pregunta y guardarla en alguno de los hijos. Así hasta llegar a una unica opcion posible
			 * ejemplo
			 * 			¿tiene pelo negro? <-- raiz
			 		--> si	/        \ <-- no
 			 			 otra preg	otra preg
			 			   
			 */
			
			//crea un objeto que almacena una pregunta
			DecisionData dato = new DecisionData(clasificador.obtenerPregunta());
			
			//crea un arbol de decision e inserta el objeto que contiene la pregunta
			ArbolBinario<DecisionData> ab = new ArbolBinario<DecisionData>(dato);
			//ArbolBinario<DecisionData> arb;
			
			//mientras que no sea una hoja 			
			if(clasificador.crearHoja())
			{
				clasificador.obtenerDatoHoja();
			}
			else
			{
				dato = new DecisionData(clasificador.obtenerPregunta());
				
				//guarda en un nuevo nodo la pregunta nueva
				ab = new ArbolBinario<DecisionData>(dato);
			}
			
			if(ab.getHijoDerecho()!=null)
			{
				clasificador.obtenerClasificadorDerecho();
			}
			if(ab.getHijoIzquierdo()!=null)
			{
				 clasificador.obtenerClasificadorIzquierdo();
			}
			
			return ab;
		}
		
		public String Consulta1(ArbolBinario<DecisionData> arbol)
		{
			//Retorna un texto con todas las posibles predicciones que puede calcular el árbol de decisión del sistema..
			
			return arbol.preorden();
			//return arbol.contenidoHoja();
		}


		public String Consulta2(ArbolBinario<DecisionData> arbol)
		{	
			
			ArrayList opciones = new ArrayList(arbol.todosLosCaminos());
			string retorno = "";
			foreach(var i in opciones)
				 retorno = i.ToString();
			
			return retorno;
			
		}
		public String Consulta3(ArbolBinario<DecisionData> arbol)
		{
			string result = "Implementar";
			return result;
		}

	}
}