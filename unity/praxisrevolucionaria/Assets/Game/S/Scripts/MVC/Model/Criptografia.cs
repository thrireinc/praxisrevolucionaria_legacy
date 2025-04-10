namespace Game.S.Scripts.MVC.Model
{
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;

    public class Criptografia : MonoBehaviour
    {
        private static Dictionary<string, string> _arquivos;
        
        public static void AtualizarChaveDeEncriptacao()
        {
            _arquivos = new Dictionary<string, string>();
            
            foreach (var diretorio in Diretorios.DiretoriosParaCriar)
            {
                var diretorioAtual = new DirectoryInfo(diretorio);
                var arquivosPresentesNoDiretorioAtual = diretorioAtual.GetFiles();
                var enumeradorDeArquivosNoDiretorioAtualCarregados = arquivosPresentesNoDiretorioAtual.Select(arquivo => Dados.CarregarDado($"{diretorio}/{arquivo.Name}", true));
                var listaDeArquivosNoDiretorioAtualCarregados = enumeradorDeArquivosNoDiretorioAtualCarregados.ToList();

                for (var i = 0; i < arquivosPresentesNoDiretorioAtual.Length; i++)
                    _arquivos.Add($"{diretorio}/{arquivosPresentesNoDiretorioAtual[i].Name}", listaDeArquivosNoDiretorioAtualCarregados[i].ToString());
            }

            GerarChave();

            foreach (var arquivo in _arquivos)
                Dados.SalvarDado(arquivo.Key, arquivo.Value, true);

        }
        private static void GerarChave()
        {
            var palavrasParaCriarChave = new[] {"helio", "ingrid", "carol", "lucas", "bia", "manuella"};
            var palavrasUtilizadas = new bool[palavrasParaCriarChave.Length];
            var chaveTemporaria = "";

            for (var i = 0; i < palavrasParaCriarChave.Length;)
            {
                var indexRandomizado = Random.Range(0, palavrasParaCriarChave.Length);
                if (palavrasUtilizadas[indexRandomizado]) continue;

                palavrasUtilizadas[indexRandomizado] = true;
                chaveTemporaria += palavrasParaCriarChave[indexRandomizado];
                i++;
            }
            
            Dados.SalvarDado(Diretorios.KeyPath + "/key.save", chaveTemporaria, false);
            Encriptador.Chave = chaveTemporaria;
            Debug.Log("Chave gerada");
        }
    }
}