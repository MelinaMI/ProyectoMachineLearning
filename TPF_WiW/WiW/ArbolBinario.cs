using System;
using System.Collections.Generic;
using System.Collections;
using tp1;
namespace tp2
{
	public class ArbolBinario<T>
	{
		
		private T dato;
		private ArbolBinario<T> hijoIzquierdo;
		private ArbolBinario<T> hijoDerecho;

		public ArbolBinario(T dato) {
			this.dato = dato;
		}
		
		public T getDatoRaiz() {
			return this.dato;
		}
		
		public ArbolBinario<T> getHijoIzquierdo() {
			return this.hijoIzquierdo;
		}
		
		public ArbolBinario<T> getHijoDerecho() {
			return this.hijoDerecho;
		}
		
		public void agregarHijoIzquierdo(ArbolBinario<T> hijo) {
			this.hijoIzquierdo=hijo;
		}
		
		public void agregarHijoDerecho(ArbolBinario<T> hijo) {
			this.hijoDerecho=hijo;
		}
		
		public void eliminarHijoIzquierdo() {
			this.hijoIzquierdo=null;
		}
		
		public void eliminarHijoDerecho() {
			this.hijoDerecho=null;
		}
		
		public bool esHoja() {
			return this.hijoIzquierdo==null && this.hijoDerecho==null;
		}
		
		public void inorden()
		{
			//Se procesa el hijo izquierdo, luego la raíz y último el hijo derecho
			if(hijoIzquierdo!=null)
				hijoIzquierdo.inorden();
			Console.Write(dato + " ");
			if(hijoDerecho!=null)
				hijoDerecho.inorden();
		}
		
		
		
		public void postorden()
		{
			//Se procesan primero los hijos, izquierdo y derecho, y luego la raíz
			if(hijoIzquierdo!=null)
				hijoIzquierdo.postorden();
			if(hijoDerecho!=null)
				hijoDerecho.postorden();
			Console.Write(dato + " ");
		}
		
		public void recorridoPorNiveles()
		{
			//Se procesan los nodos teniendo en cuenta sus niveles, primero la raíz, luego los hijos, los hijos de éstos, etc.
			
			Cola<ArbolBinario<T>> c = new Cola<ArbolBinario<T>>();
			ArbolBinario<T> arbolaux;
			c.encolar(this);
			while(!c.esVacia())
			{
				arbolaux=c.desencolar();
				Console.Write(arbolaux.dato + " ");
				
				if(arbolaux.hijoIzquierdo !=null)
					c.encolar(arbolaux.hijoIzquierdo);
				if(arbolaux.hijoDerecho !=null)
					c.encolar(arbolaux.hijoDerecho);
			}
		}
		
		
		/*public string recorridoPorNivelesConSeparacion(
		{
			//Se procesan los nodos teniendo en cuenta sus niveles, primero la raíz, luego los hijos, los hijos de éstos, etc.
			
			
			/*
			Cola<ArbolBinario<T>> c = new Cola<ArbolBinario<T>>();
			ArbolBinario<T> arbolaux;
			c.encolar(this);
			c.encolar(null);
			
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
					Console.Write(arbolaux.dato + " ");
					if(arbolaux.hijoIzquierdo!=null)
						c.encolar(arbolaux.hijoIzquierdo);
					if(arbolaux.hijoDerecho!=null)
						c.encolar(arbolaux.hijoDerecho);
				}
				
			}*/
		
		public string Preorden()
		{
			//Se procesa primero la raíz y luego sus hijos, izquierdo y derecho.
			string preOrden = "";
			//Se procesa primero la raíz y luego sus hijos, izquierdo y derecho.
			if(dato !=null)
				preOrden = dato.ToString() + " ";
			if(hijoIzquierdo!=null)
				preOrden = preOrden + hijoIzquierdo.Preorden();
			if(hijoDerecho!=null)
				preOrden  = preOrden + hijoDerecho.Preorden();
			return preOrden;
		}
		
		
		public int contarHojas()
		{
			int contadorHojas=0;
			
			if(esHoja())
				contadorHojas++;
			
			if(hijoIzquierdo!=null)
				contadorHojas = contadorHojas + hijoIzquierdo.contarHojas();
			
			if(hijoDerecho!=null)
				contadorHojas = contadorHojas + hijoDerecho.contarHojas();
			
			
			return contadorHojas;
		}
		
		public string contenidoHoja()
		{
			string contenido = "";
			
			if(esHoja())
				contenido = dato.ToString() + " ";
			
			if(hijoIzquierdo!=null)
				contenido = contenido + hijoIzquierdo.contenidoHoja();
			
			if(hijoDerecho!=null)
				contenido = contenido + hijoDerecho.contenidoHoja();
			
			
			return contenido;
		}
		
		public string Caminos(ArrayList camino, ArrayList caminos, ArrayList copia)
		{
			//Se procesa primero la raíz y luego sus hijos, izquierdo y derecho.
			string preOrden = "";
			//Se procesa primero la raíz y luego sus hijos, izquierdo y derecho.
			if(dato !=null)
			{
				camino.Add(this);
				//guarda camino en una lista de copia
				preOrden = dato.ToString() + " ";
				copia.AddRange(camino);
				//copia camino en caminos
				foreach(var i in camino)
		    		caminos.Add(i);
				
				
			}
			if(hijoIzquierdo!=null)
				preOrden = preOrden + hijoIzquierdo.Caminos(camino,caminos,copia);
			if(hijoDerecho!=null)
				preOrden  = preOrden + hijoDerecho.Caminos(camino,caminos,copia);
			return preOrden;
		}
		
		
		public void recorridoPorNivelesConSeparacion(ArbolBinario<T>arbol)
		{
			//Se procesan los nodos teniendo en cuenta sus niveles, primero la raíz, luego los hijos, los hijos de éstos, etc.
			
			Cola<ArbolBinario<T>> c = new Cola<ArbolBinario<T>>();
			ArbolBinario<T> arbolaux;
			c.encolar(this);
			c.encolar(null);
			
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
					Console.WriteLine(arbolaux.dato + " ");
					if(arbolaux.hijoIzquierdo!=null)
						c.encolar(arbolaux.hijoIzquierdo);
					if(arbolaux.hijoDerecho!=null)
						c.encolar(arbolaux.hijoDerecho);
				}
				
			}
		}
		
		
		
	}
}
