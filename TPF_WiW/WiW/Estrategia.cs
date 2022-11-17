
using System;
using System.Collections.Generic;
using tp1;
using tp2;
using System.Collections;

namespace tpfinal
{

	class Estrategia
	{
		ArrayList camino = new ArrayList();
		ArrayList caminos = new ArrayList();
		ArrayList copia = new ArrayList();	
		Cola<ArbolBinario<DecisionData>> c = new Cola<ArbolBinario<DecisionData>>();
		
		public ArbolBinario<DecisionData>CrearArbol(Clasificador clasificador)
		{
			DecisionData dato = new DecisionData(clasificador.obtenerPregunta()); //Construye un objeto que almacena una pregunta.
			
			ArbolBinario<DecisionData> ab = new ArbolBinario<DecisionData>(dato); //crea un nodo de decision e inserta el objeto que contiene la pregunta
			
			DecisionData nodohoja;
			
			if(clasificador.crearHoja()==true) //Retorna True si el conjunto de datos corresponde a un nodo-hoja y False en caso contrario
			{
				nodohoja = new DecisionData(clasificador.obtenerDatoHoja()); // Devuelve el dato que debe almacenarse en un nodo-hoja. El dato devuelto es de tipo Dictionary
				
				ab = new ArbolBinario<DecisionData>(nodohoja);
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

		public String Consulta2(ArbolBinario<DecisionData> arbol)
		{
			return arbol.Caminos(camino,caminos,copia);
			
		}
		
		public String Consulta3(ArbolBinario<DecisionData> arbol)
		{
			ArbolBinario<DecisionData> arbolaux;
			c.encolar(arbol);
			c.encolar(null);
			string cola = "";
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
					cola += arbolaux.getDatoRaiz().ToString() + " ";
					if(arbolaux.getHijoIzquierdo()!=null)
						c.encolar(arbolaux.getHijoIzquierdo());
					if(arbolaux.getHijoDerecho()!=null)
						c.encolar(arbolaux.getHijoDerecho());
				}
			}
			
			return cola;
		}
	}
}