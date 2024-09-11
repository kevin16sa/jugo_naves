using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Servicios_Web : MonoBehaviour
{
    // Start is called before the first frame update
    public Respuesta_Registro respuesta_Registro;

    void Start()
    {
        Usuario usuario= new Usuario();
        usuario.cedula="1234567890"
        usuario.nombre="Kesviro"
        usuario.email="kdsanch@uny.com"
        StartCroutine(ResgistroUsuario(usuario));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator ResgistroUsuario (Usuario datosRegistro)
    {
        var registroJSON= JsonUtility.ToJson(datosRegistro);

        var solicitud = new UnityWebRequest();
        solicitud.url = "http://localhost:3000/api/jugador/registrar";

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(registroJSON);
        solicitud.uploadHandler = new UploadHandler(bodyRaw);
        solicitud.downloadHandler = new DownloadHandler();
        solicitud.method =UnityWebResquest.kHttpVerbPOST;
        solicitud.SetRequestHeader("Content-Type","application/json");

        solicitud.timeout =10;

        yield return solicitud. SetRequest();

        if(solicitud.resultado= UnityWebRequest.resultado.ConnetionError)
        {
            respuesta_Registro.mensaje="Conexion Fallida";
        }
        else
        {
            respuesta_Registro= (respuesta_Registro)JsonUtility.FromJson(solicitud..downloadHandler.text, typeof(RespuestaRegistro));

        }
        solicitud.Dispose();
    }
}
