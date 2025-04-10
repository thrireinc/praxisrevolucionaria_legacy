namespace Game.S.Scripts.MVC.Model
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using UnityEngine;

    public class Dados : MonoBehaviour
    {
        public static void SalvarDado(string filename, string dado, bool criptografrar)
        {
            var arquivo =  File.Open(filename, FileMode.OpenOrCreate);

            try
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(arquivo, criptografrar ? Encriptador.Encriptar(dado) : dado);
            }
            catch (SerializationException e)
            {
                Debug.Log("Problema na serialização. Motivo: " + e.Message);
                throw;
            }
            finally
            {
                arquivo.Close();
            }
        }
        public static object CarregarDado(string filename, bool estaCriptografado)
        {
            if (!File.Exists(filename)) return null;

            object dadoBruto;
            var arquivo = new FileStream(filename, FileMode.OpenOrCreate);

            try
            {
                var formatter = new BinaryFormatter();
                dadoBruto = formatter.Deserialize(arquivo);
            }
            catch (SerializationException e)
            {
                Debug.Log("Problema na deserialização. Motivo: " + e.Message);
                throw;
            }
            finally
            {
                arquivo.Close();
            }

            var dado = dadoBruto.ToString();
            return estaCriptografado ? Encriptador.Decriptar(dado) : dado;
        }
    }
}