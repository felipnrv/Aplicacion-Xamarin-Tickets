using Firebase.Auth;
using Firebase.Database;
using Firebase.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace XamarinGrupo3
{
   
    public class UsuarioDB
    {
        FirebaseStorage firebaseStorage = new FirebaseStorage("fir-xamarin-213c2.appspot.com");
        //Se coloca la url de la realtimeDB Firebase 
        FirebaseClient firebaseClient = new FirebaseClient("https://fir-xamarin-213c2-default-rtdb.firebaseio.com/");

        //Guardar los datos 
        //Task(Operacion asincronica) de resultado un bool
        //await y async es para hacer tareas asincronicas esperando la respuesta del usuario
        public async Task<bool> GuardarUsuario(UsuarioModelo usuario)
        {
            //.child coloca la ruta
            //nameof obtiene la clase
            //hace un envio post y los convierte a JSON 
            var info = await firebaseClient.Child(nameof(UsuarioModelo)).PostAsync(JsonConvert.SerializeObject(usuario));
            //verifica que la cadena no se vacia
            //indica si se encuentra el valor
            if(!string.IsNullOrEmpty(info.Key))
            { 
                return true;
            }
            return false;

        }
        //devuelve una lista
        public async Task<List<UsuarioModelo>>GetAll()
        {
            return (await firebaseClient.Child(nameof(UsuarioModelo)).OnceAsync<UsuarioModelo>()).Select(item => new UsuarioModelo
            {
                //se asigna la instancia del objeto
                nombreuser=item.Object.nombreuser,
                apellidouser=item.Object.apellidouser,
                edaduser=item.Object.edaduser,
                generouser=item.Object.generouser,
                cedulauser =item.Object.cedulauser,
                ciudaduser=item.Object.ciudaduser,
                telefonouser=item.Object.telefonouser,
                roleuser =item.Object.roleuser,
                Id=item.Key,

            }).ToList();

        }
        public async Task<UsuarioModelo> GetById(string id)
        {
            //Regresa un solo record en la ruta especifica 
            return (await firebaseClient.Child(nameof(UsuarioModelo) + "/" + id).OnceSingleAsync<UsuarioModelo>());
            

        }
        public async Task<bool> Update(UsuarioModelo usuario)
        {
            //Crea la ruta a la que accede
            await firebaseClient.Child(nameof(UsuarioModelo) + "/" + usuario.Id).PutAsync(JsonConvert.SerializeObject(usuario));
            return true;

        }
        public async Task<bool> Borrar(string id)
        {
            //Crea la ruta a la que accede
            await firebaseClient.Child(nameof(UsuarioModelo) + "/" + id).DeleteAsync();
            return true;
        }

        public async Task<string> Subir(Stream img, string filenomb)
        {
            var image = await firebaseStorage.Child("Imagen").Child(filenomb).PutAsync(img);
            return image;
        }


    }
}
