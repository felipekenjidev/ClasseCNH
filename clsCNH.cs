using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Classe com Métodos de Validação de CNH
/// </summary>
public class CNH
{
    /// <summary>
    /// Construtor da Classe para formatação de Dígitos
    /// </summary>
    /// <param name="digitos">Dígitos do CNH</param>
    /// <exception cref="ArgumentException">Erro adquirido ao inserir dígitos que não correspondam a um CNH</exception>
    public CNH(string digitos)
    {
        //Verificação do Formato do CNH Inserido
        digitos = digitos.Trim();
        if (String.IsNullOrEmpty(digitos))
            throw new ArgumentException("O CNH não pode ser vazio.");
        if (digitos.Length != 11)
            throw new ArgumentException("O CNH deve possuir todos os 11 dígitos.");
        if (!long.TryParse(digitos, out long digitosFormatados))
            throw new ArgumentException("O CNH deve ser composto somente por dígitos númericos.");

        //Guardar os Dígitos do CNH
        this.Digitos = digitos;
    }

    /// <summary>
    /// Propriedade que guarda todos os Dígitos do CNH
    /// </summary>
    public string Digitos { get; set; }

    /// <summary>
    /// Método que retorna a validade do Documento CNH
    /// </summary>
    /// <returns>Retorna a Validade do Documento</returns>
    public bool Validar()
    {
        //Caso haja somente números iguais, retornar que é Falso o Documento
        if (this.Digitos == new string(Convert.ToChar(this.Digitos.Substring(0, 1)), 11))
            return false;

        //Gerar o CNH Válido e Padrão
        int digitoVerificador1 = GerarDigitoVerificador(this.Digitos.Substring(0, 9), false);
        int diferencial = 0;
        if (digitoVerificador1 == 10)
        {
            digitoVerificador1 = 0;
            diferencial = 2;
        }

        int digitoVerificador2 = GerarDigitoVerificador(this.Digitos.Substring(0, 9), true);
        digitoVerificador2 = digitoVerificador2 == 10 ? 0 : digitoVerificador2 - diferencial;

        string CNHReal = Digitos.Substring(0, 9) + digitoVerificador1.ToString() + digitoVerificador2.ToString();

        //Enviar resposta da Validação
        return this.Digitos == CNHReal ? true : false;
    }

    //Método que realiza os cálculos para gerar os Dígitos Verificadores
    private int GerarDigitoVerificador(string digitos, bool crescente)
    {
        //Calcular as Multiplicações de cada Dígito do CNH
        int soma = 0;
        int multiplicador = crescente ? 1 : 9;
        for (int indice = 0; indice < digitos.Length; indice++)
        {
            soma += int.Parse(digitos.Substring(indice, 1)) * multiplicador;
            multiplicador += crescente ? 1 : -1;
        }

        //Retornar o Dígito Validador
        return soma % 11;
    }
}