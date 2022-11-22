
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
			DecisionData pregunta = new DecisionData(clasificador.obtenerPregunta()); 
			ArbolBinario<DecisionData> arb = new ArbolBinario<DecisionData>(pregunta); 
			
			DecisionData nodohoja;
			
			if(clasificador.crearHoja()==true) 
			{
				nodohoja = new DecisionData(clasificador.obtenerDatoHoja()); 
				arb = new ArbolBinario<DecisionData>(nodohoja);
			}
			else
			{
				pregunta = new DecisionData(clasificador.obtenerPregunta());
				arb = new ArbolBinario<DecisionData>(pregunta);
				arb.agregarHijoDerecho(CrearArbol(clasificador.obtenerClasificadorDerecho()));
				arb.agregarHijoIzquierdo(CrearArbol(clasificador.obtenerClasificadorIzquierdo()));
				
			}

			return arb;
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
					cola += arbolaux.getDatoRaiz().ToString() + "\n";
					if(arbolaux.getHijoIzquierdo()!=null)
						c.encolar(arbolaux.getHijoIzquierdo());
					if(arbolaux.getHijoDerecho()!=null)
						c.encolar(arbolaux.getHijoDerecho());
				}
			}
			
			return  cola;
		}
	}
}