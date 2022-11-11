
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
			Dictionary<string,int> nodohoja;
				
			if(clasificador.crearHoja()==true) //Retorna True si el conjunto de datos corresponde a un nodo-hoja y False en caso contrario
			{
				nodohoja = new Dictionary<string,int>(clasificador.obtenerDatoHoja()); // Devuelve el dato que debe almacenarse en un nodo-hoja. El dato devuelto es de tipo Dictionary
				
			}
			else
			{
				dato = new DecisionData(clasificador.obtenerPregunta());
				ab = new ArbolBinario<DecisionData>(dato);
				ab.agregarHijoDerecho(CrearArbol(clasificador.obtenerClasificadorDerecho()));
				ab.agregarHijoIzquierdo(CrearArbol(clasificador.obtenerClasificadorIzquierdo()));
			
			}

			return ab;
		}
		
		
		public String Consulta1(ArbolBinario<DecisionData> arbol)
		{			
			return arbol.contenidoHoja();
		}

		ArrayList camino = new ArrayList();
		ArrayList caminos = new ArrayList();
		ArrayList copia = new ArrayList();
		
		public String Consulta2(ArbolBinario<DecisionData> arbol)
		{	 		
			return arbol.Caminos(camino,caminos,copia);
			
		}
		public String Consulta3(ArbolBinario<DecisionData> arbol)
		{
			Cola<ArbolBinario<DecisionData>> c = new Cola<ArbolBinario<DecisionData>>();
			ArbolBinario<DecisionData> arbolaux;
			c.encolar(arbol);
			c.encolar(null);
			String cola = "";
			while(!c.esVacia())
			{
				arbolaux=c.desencolar();
				if(arbolaux == null)
				{
					if(!c.esVacia())
						c.encolar(null);
				}
				else
				{
					cola = arbolaux.getDatoRaiz().ToString() + " ";
					if(arbolaux.getHijoIzquierdo()!=null)
						c.encolar(arbolaux.getHijoIzquierdo());
					if(arbolaux.getHijoIzquierdo()!=null)
						c.encolar(arbolaux.getHijoIzquierdo());
				}
				
			}
			
			
			return cola;
		}

	}
}