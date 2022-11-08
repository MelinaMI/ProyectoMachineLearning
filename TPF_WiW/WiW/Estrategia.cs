
using System;
using System.Collections.Generic;
using tp1;
using tp2;
using System.Collections;

namespace tpfinal
{

	class Estrategia
	{
		ArrayList datosHojas = new ArrayList();
		public ArbolBinario<DecisionData>CrearArbol(Clasificador clasificador)
		{
			
			DecisionData dato = new DecisionData(clasificador.obtenerPregunta());
			ArbolBinario<DecisionData> ab = new ArbolBinario<DecisionData>(dato);
			Dictionary<string,int> datoHoja;
			if(clasificador.crearHoja()==true)
			{
				datoHoja = new Dictionary<string,int>(clasificador.obtenerDatoHoja());
				DecisionData a = new DecisionData(datoHoja);
				/*ab.agregarHijoDerecho(a);
				 return arb;*/
			}
							
			
			if(ab.getHijoDerecho()!=null)
			{
				return CrearArbol(clasificador.obtenerClasificadorDerecho());
			}
			if(ab.getHijoIzquierdo()!=null)
			{
				 return CrearArbol(clasificador.obtenerClasificadorIzquierdo());
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
			ArrayList camino = new ArrayList();
			ArrayList caminos = new ArrayList();
			ArrayList opciones = new ArrayList(arbol.todosLosCaminos(camino,caminos));
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