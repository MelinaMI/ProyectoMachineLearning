
using System;
using System.Collections.Generic;
using tp1;
using tp2;
using System.Collections;

namespace tpfinal
{

	class Estrategia
	{
		List<ArbolBinario<DecisionData>> camino = new List<ArbolBinario<DecisionData>>();
		List<ArbolBinario<DecisionData>> caminos = new List<ArbolBinario<DecisionData>>();
		List<ArbolBinario<DecisionData>> copia = new List<ArbolBinario<DecisionData>>();	
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
			string todosLosCaminos= "";
			Caminos(arbol,ref camino,ref caminos, ref copia);
			foreach(ArbolBinario<DecisionData> j in caminos)
			{
				if(j.esHoja())
					todosLosCaminos+= "|" + j.getDatoRaiz().ToString() + "|" + "\n";
				else
					todosLosCaminos += "|" + j.getDatoRaiz().ToString();
			}			
			return todosLosCaminos;	
		}
		
		private List<ArbolBinario<DecisionData>> Caminos(ArbolBinario<DecisionData> arbol, ref List<ArbolBinario<DecisionData>> camino, ref List<ArbolBinario<DecisionData>> caminos,ref List<ArbolBinario<DecisionData>> copia)
		{
		
			if(arbol.getDatoRaiz() !=null)
			{
				camino.Add(arbol);
				if(arbol.esHoja())
				{
					//guarda camino en una lista de copia
					copia.AddRange(camino);
					//copia camino en caminos
					foreach(ArbolBinario<DecisionData> i in camino)
						caminos.Add(i);
					 camino.RemoveAt(camino.Count - 1);
					 return camino;
				}
			
				if(arbol.getHijoIzquierdo()!=null)
				
					Caminos(arbol.getHijoIzquierdo(),ref camino,ref caminos,ref copia);
				
				
				if(arbol.getHijoDerecho()!=null)
					Caminos(arbol.getHijoDerecho(),ref camino,ref caminos,ref copia);
										
				camino.RemoveAt(camino.Count - 1);
				return camino;
			}
			
			return caminos;
		}
		
		public String Consulta3(ArbolBinario<DecisionData> arbol)
		{
			int contadorNivel = 0;
			ArbolBinario<DecisionData> arbolaux;
			c.encolar(arbol);
			c.encolar(null);
			string info = "", infoAux= "";
			while(!c.esVacia())
			{
				arbolaux=c.desencolar();
				if(arbolaux == null)
				{
					if(!c.esVacia())
						c.encolar(null);
					info = info + "Nivel "+ contadorNivel++ + ": " + infoAux + "\n";
					infoAux=""; //vuelvo a almacenar vacio
				}
				else
				{
					infoAux = infoAux + arbolaux.getDatoRaiz().ToString() + " | ";
					if(arbolaux.getHijoIzquierdo()!=null)
						c.encolar(arbolaux.getHijoIzquierdo());
					if(arbolaux.getHijoDerecho()!=null)
						c.encolar(arbolaux.getHijoDerecho());
				}
			}
			return  info;
		}
	}
}