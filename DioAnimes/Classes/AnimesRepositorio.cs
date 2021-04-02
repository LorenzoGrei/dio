using System.Collections.Generic;
using System;
using Dio.Animes.Interfaces;


namespace Dio.Animes
{
    public class AnimesRepositorio : IRepositorio<Anime>
    {
      private List<Anime> listaAnime =  new  List<Anime>();
       public void Atualiza(int id, Anime objeto)
        {
            listaAnime[id] = objeto;
        }                
        
        public void Exclui(int id)
        {
            listaAnime[id].Excluir();
        }

        public void Insere(Anime objeto)
        {
            listaAnime.Add(objeto);
        }

        public List<Anime> lista()
        {
            return listaAnime;
        }

        public int ProximoId()
        {
            return listaAnime.Count;  
        }

        public Anime RetonrnaPorId(int id)
        {
            return listaAnime[id]; 
        } 
    
    }
}