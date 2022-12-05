
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
			DecisionData pregunta, nodohoja;
			ArbolBinario<DecisionData> arb;
			
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
			List<ArbolBinario<DecisionData>> camino = new List<ArbolBinario<DecisionData>>();
			List<ArbolBinario<DecisionData>> caminos = new List<ArbolBinario<DecisionData>>();
			string todosLosCaminos= "";
			Caminos(arbol, camino, caminos);
			foreach(ArbolBinario<DecisionData> j in caminos)
			{
				if(j.esHoja())
					todosLosCaminos+= "|" + j.getDatoRaiz().ToString() + "|" + "\n";
				else
					todosLosCaminos += "|" + j.getDatoRaiz().ToString();
			}
			return todosLosCaminos;
		}
		
		private List<ArbolBinario<DecisionData>> Caminos(ArbolBinario<DecisionData> arbol,  List<ArbolBinario<DecisionData>> camino, List<ArbolBinario<DecisionData>> caminos)
		{
			if(arbol.getDatoRaiz() !=null)
			{
				camino.Add(arbol);
				if(arbol.esHoja())
				{
					foreach(ArbolBinario<DecisionData> i in camino)
						caminos.Add(i);
					if(camino.Count>0)
					{
						camino.RemoveAt(camino.Count - 1);
						return camino;
					}
				}
				
				if(arbol.getHijoIzquierdo()!=null)
					Caminos(arbol.getHijoIzquierdo(), camino, caminos);
					
				if(arbol.getHijoDerecho()!=null)
					Caminos(arbol.getHijoDerecho(), camino, caminos);
			}
			
			camino.RemoveAt(camino.Count - 1);
			return caminos;
		}
		
		public String Consulta3(ArbolBinario<DecisionData> arbol)
		{
			Cola<ArbolBinario<DecisionData>> c = new Cola<ArbolBinario<DecisionData>>();
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