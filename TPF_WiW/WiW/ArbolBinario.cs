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
				contenido = dato.ToString() + " \n ";
			
			if(hijoIzquierdo!=null)
				contenido =  contenido + hijoIzquierdo.contenidoHoja();
			
			if(hijoDerecho!=null)
				contenido =   contenido + hijoDerecho.contenidoHoja();
			
			
			return contenido;
		}
		
		
		}
	}
}
