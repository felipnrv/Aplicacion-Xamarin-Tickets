using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinGrupo3
{
    public class TecnicoDB
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://fir-xamarin-213c2-default-rtdb.firebaseio.com/");

        public async Task<bool> GuardarTecnico(TecnicoModelo tecnico)
        {
            var info = await firebaseClient.Child(nameof(TecnicoModelo)).PostAsync(JsonConvert.SerializeObject(tecnico));
            if (!string.IsNullOrEmpty(info.Key))
            {
                return true;
            }
            return false;

        }
        public async Task<List<TecnicoModelo>> GetAll()
        {
            return (await firebaseClient.Child(nameof(TecnicoModelo)).OnceAsync<TecnicoModelo>()).Select(item => new TecnicoModelo
            {
                nombretec = item.Object.nombretec,
                apellidotec = item.Object.apellidotec,
                edadtecn = item.Object.edadtecn,
                generotecn = item.Object.generotecn,
                cedulatec = item.Object.cedulatec,
                ciudadtec = item.Object.ciudadtec,
                telefonotec = item.Object.telefonotec,
                roletec = item.Object.roletec,

            }).ToList();

        }
        public async Task<TecnicoModelo> GetById(string id)
        {
            return (await firebaseClient.Child(nameof(TecnicoModelo)+"/"+id).OnceSingleAsync<TecnicoModelo>());

        }
        public async Task<bool> Update(TecnicoModelo tecnico)
        {
            await firebaseClient.Child(nameof(TecnicoModelo) + "/" + tecnico.Id).PutAsync(JsonConvert.SerializeObject(tecnico));
            return true;
        }
        public async Task<bool> Borrar (string id)
        {
            await firebaseClient.Child(nameof(TecnicoModelo) + "/" + id).DeleteAsync();
            return true;
        }
    }
}
