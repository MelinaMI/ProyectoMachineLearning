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
	
		ArrayList camino = new ArrayList();
		ArrayList caminos = new ArrayList();
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
		
		public string preorden()
		{
			//Se procesa primero la raíz y luego sus hijos, izquierdo y derecho.
			string preOrden = "";
			//Se procesa primero la raíz y luego sus hijos, izquierdo y derecho.
			if(dato !=null)
				preOrden = dato.ToString() + " ";
			if(hijoIzquierdo!=null)
				preOrden = preOrden + hijoIzquierdo.preorden();
			if(hijoDerecho!=null)
				preOrden  = preOrden + hijoDerecho.preorden();
			return preOrden;
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
		
		
		ArrayList copia = new ArrayList();
		
		public ArrayList todosLosCaminos()
		{
			camino.Add(this);
			
			if(this.esHoja())
			{
				//guarda camino en una lista de copia
				copia.AddRange(camino);
				//copia camino en caminos
				foreach(var i in camino)
		    		caminos.Add(i);
				
			}
			else
			{
				if(hijoIzquierdo!=null)
				{
					hijoIzquierdo.todosLosCaminos();
					camino.RemoveAt(camino.Count-1);
					
				}
				
				if(hijoDerecho!=null)
				{
					hijoDerecho.todosLosCaminos();
					camino.RemoveAt(camino.Count-1);
					
				}
			}
			return caminos;
		}
		
		public void recorridoEntreNiveles(int n,int m) {
		}
	}
}
