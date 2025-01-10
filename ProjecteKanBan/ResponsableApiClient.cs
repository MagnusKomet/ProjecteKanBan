using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using System.Windows.Input;

namespace ProjecteKanBan
{
    public class ResponsablesApiClient
    {
        string BaseUri;
        public ResponsablesApiClient()
        {
            BaseUri = "https://localhost:44351/api/";
        }

        /// <summary>
        /// Obté un usuari a partir del Id
        /// </summary>
        /// <param name="id">Codi d'usuari</param>
        /// <returns>Usuari o null si no el troba</returns>
        public async Task<Responsable> GetResponsableAsync(int id)
        {
            Responsable responsable = new Responsable("","","");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /users/{Id}
                HttpResponseMessage response = await client.GetAsync($"responsables/{id}");
                if (response.IsSuccessStatusCode)
                {
                    //Reposta 204 quan no ha trobat dades
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        responsable = null;
                    }
                    else
                    {
                        //Obtenim el resultat i el carreguem al Objecte User
                        responsable = await response.Content.ReadAsAsync<Responsable>();
                        response.Dispose();
                    }
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? 
                }
            }
            return responsable;
        }

        /// <summary>
        /// Obté una llista de tots els usuaris de la base de dades
        /// </summary>
        /// <returns></returns>
        
        public async Task<ObservableCollection<Responsable>> GetResponsableAsync()
        {
            ObservableCollection<Responsable> llista_responsables = new ObservableCollection<Responsable>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /users}
                HttpResponseMessage response = await client.GetAsync("responsables");
                if (response.IsSuccessStatusCode)
                {
                    //Obtenim el resultat i el carreguem al objecte llista d'usuaris
                    llista_responsables = await response.Content.ReadAsAsync<ObservableCollection<Responsable>>();
                    response.Dispose();
                }
                else
                {
                    //TODO: que fer si ha anat malament? retornar null? missatge?
                }
            }
            return llista_responsables;
        }

        /// <summary>
        /// Afegeix un nou usuari
        /// </summary>
        /// <param name="responsable">Usuari que volem afegir</param>
        /// <returns></returns>
        public async Task AddAsync(Responsable responsable)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició POST al endpoint /users}
                HttpResponseMessage response = await client.PostAsJsonAsync("responsables", responsable);
                response.EnsureSuccessStatusCode();
            }
        }

        /// <summary>
        /// Modificar un usuari
        /// </summary>
        /// <param name="responsable">Usuari que volem modificar</param>
        /// <returns></returns>
        public async Task UpdateAsync(Responsable responsable)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició PUT al endpoint /users/Id
                HttpResponseMessage response = await client.PutAsJsonAsync($"responsables/{responsable.id}", responsable);
                response.EnsureSuccessStatusCode();
            }
        }


        /// <summary>
        /// Modificar un usuari
        /// </summary>
        /// <param name="responsable">Usuari que volem modificar</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició DELETE al endpoint /users/Id
                HttpResponseMessage response = await client.DeleteAsync($"responsable/{id}");
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
