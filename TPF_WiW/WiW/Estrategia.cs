
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
			//Construyo un objeto que almacena una pregunta.
			DecisionData dato = new DecisionData(clasificador.obtenerPregunta());
			
			//crea un nodo de decision e inserta el objeto que contiene la pregunta
			ArbolBinario<DecisionData> ab = new ArbolBinario<DecisionData>(dato);
			
			//Construyo un objeto que almacena un dato de un nodo-hoja de tipo Dictionary<string, int>
			Dictionary<string,int> nodohoja = new Dictionary<string,int>();
			
				
			if(clasificador.crearHoja()) //Retorna True si el conjunto de datos corresponde a un nodo-hoja y False en caso contrario
			{
				nodohoja = clasificador.obtenerDatoHoja(); // Devuelve el dato que debe almacenarse en un nodo-hoja. El dato devuelto es de tipo Dictionary
				
			}
			else
			{
				dato = new DecisionData(clasificador.obtenerPregunta());
				
				//guarda en un nuevo nodo la pregunta nueva
				//ab = new ArbolBinario<DecisionData>(dato);
			}
			
			if(ab.getHijoDerecho()!=null)
			{
				ab.agregarHijoDerecho(CrearArbol(clasificador.obtenerClasificadorDerecho()));
			}
				                      
			if(ab.getHijoIzquierdo()!=null)
			{
				ab.agregarHijoIzquierdo(CrearArbol(clasificador.obtenerClasificadorIzquierdo()));
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