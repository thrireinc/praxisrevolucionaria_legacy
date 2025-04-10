namespace Game.S.Scripts.MVC.Model
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using UnityEngine;

    public class Encriptador : MonoBehaviour
    {
        private static object _saveChave = Dados.CarregarDado(Diretorios.KeyPath + "/key.save", false);
        public static string Chave = _saveChave.ToString();
        private const string Iv = "helioingridcarol";

        private static ICryptoTransform _icrypt;
        private static byte[] _textbytes, _enc;
        private static Encoding ascii = Encoding.ASCII;
        private static AesCryptoServiceProvider _endec;
        
        public static string Encriptar(string decrypted)
        {
            _endec = ConfigurarDados();
            _textbytes = ascii.GetBytes(decrypted);
            _icrypt = _endec.CreateEncryptor(_endec.Key, _endec.IV);
            _enc = _icrypt.TransformFinalBlock(_textbytes, 0, _textbytes.Length);
            _icrypt.Dispose();
            
            return Convert.ToBase64String(_enc);
        }
        public static string Decriptar(string encrypted)
        {
            _endec = ConfigurarDados();
            _textbytes = Convert.FromBase64String(encrypted);
            _icrypt = _endec.CreateDecryptor(_endec.Key, _endec.IV);
            _enc = _icrypt.TransformFinalBlock(_textbytes, 0, _textbytes.Length);
            _icrypt.Dispose();
            
            return ascii.GetString(_enc);
        }
        private static AesCryptoServiceProvider ConfigurarDados()
        {
            return new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 256,
                IV = ascii.GetBytes(Iv),
                Key = ascii.GetBytes(Chave),
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC
            };
        }
    }
}