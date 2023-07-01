using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace XamarinGrupo3
{
   
    public class UsuarioDB
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://fir-xamarin-213c2-default-rtdb.firebaseio.com/");

        public async Task<bool> GuardarUsuario(UsuarioModelo usuario)
        {
            var info = await firebaseClient.Child(nameof(UsuarioModelo)).PostAsync(JsonConvert.SerializeObject(usuario));
            if(!string.IsNullOrEmpty(info.Key))
            { 
                return true;
            }
            return false;

        }
        public async Task<List<UsuarioModelo>>GetAll()
        {
            return (await firebaseClient.Child(nameof(UsuarioModelo)).OnceAsync<UsuarioModelo>()).Select(item => new UsuarioModelo
            {
                nombreuser=item.Object.nombreuser,
                apellidouser=item.Object.apellidouser,
                edaduser=item.Object.edaduser,
                generouser=item.Object.generouser,
                cedulauser =item.Object.cedulauser,
                ciudaduser=item.Object.ciudaduser,
                telefonouser=item.Object.telefonouser,
                roleuser =item.Object.roleuser,

            }).ToList();

            

        }
        public async Task<UsuarioModelo> GetById(string id)
        {
            return (await firebaseClient.Child(nameof(UsuarioModelo) + "/" + id).OnceSingleAsync<UsuarioModelo>());
            

        }
        public async Task<bool> Update(UsuarioModelo usuario)
        {
            await firebaseClient.Child(nameof(UsuarioModelo) + "/" + usuario.IdUser).PutAsync(JsonConvert.SerializeObject(usuario));
            return true;

        }
        public async Task<bool> Borrar(string id)
        {
            await firebaseClient.Child(nameof(UsuarioModelo) + "/" + id).DeleteAsync();
            return true;
        }




    }
}
