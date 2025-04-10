namespace Game.S.Scripts.MVC.Model
{
    using System.IO;
    using UnityEngine;

    public class Diretorios : MonoBehaviour
    {
        public static readonly string SavePath = Application.persistentDataPath + "/Saves";
        public static string KeyPath = SavePath + "/Key";
        public static string DouglasPath = SavePath + "/Douglas";
        public static string GislenePath = SavePath + "/Gislene";

        public static string[] DiretoriosParaCriar = {SavePath, KeyPath, DouglasPath, GislenePath};
        private static bool[] EsconderDiretorio = {false, true, false, false};

        public static void CriarDiretoriosEssenciais()
        {
            var diretoriosParaCriar = DiretoriosParaCriar;
            for (var i = 0; i < diretoriosParaCriar.Length; i++)
            {
                if (Directory.Exists(diretoriosParaCriar[i])) continue;
                var atributosDiretorio = Directory.CreateDirectory(diretoriosParaCriar[i]);
                    
                if (EsconderDiretorio[i])
                    atributosDiretorio.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
            
            if (!File.Exists(KeyPath + "/key.save"))
                Dados.SalvarDado(KeyPath + "/key.save", "helioingridcarollucasbiamanuella", false);
        }
    }
}