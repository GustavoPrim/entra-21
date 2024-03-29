﻿using System.Data;
using Entra21.BancoDados01.Ado.Net.Exercicio.DataBase;
using Entra21.BancoDados01.Ado.Net.Exercicio.Models;

namespace Entra21.BancoDados01.Ado.Net.Exercicio.Services
{
    internal class CidadeService : ICidadeService
    {
        public void Apagar(int id)
        {
            var conexao = new Conexao().Conectar();
            var comando = conexao.CreateCommand();
            comando.CommandText = "DELETE FROM cidades WHERE id = @ID";

            comando.Parameters.AddWithValue("@ID", id);
            comando.ExecuteNonQuery();
            comando.Connection.Close();
        }

        public void Cadastrar(Cidade cidade)
        {
            var conexao = new Conexao().Conectar();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"INSERT INTO cidades (id_unidade_federativa, nome, quantidade_habitantes,
                          data_hora_fundacao, pib)
                          VALUES (@ID_UNIDADE_FEDERATIVA, @NOME, @QUANTIDADE_HABITANTES, @DATA_HORA_FUNDACAO, @PIB);";

            // previnir Sql Injection
            comando.Parameters.AddWithValue("@ID_UNIDADE_FEDERATIVA", cidade.UnidadeFederativa.Id);
            comando.Parameters.AddWithValue("@NOME", cidade.Nome);
            comando.Parameters.AddWithValue("@QUANTIDADE_HABITANTES", cidade.QuantidadeHabitantes);
            comando.Parameters.AddWithValue("@DATA_HORA_FUNDACAO", cidade.DataHoraFundacao);
            comando.Parameters.AddWithValue("@PIB", cidade.Pib);

            // executa o insert
            comando.ExecuteNonQuery();

            // fechar conexão com banco de dados
            comando.Connection.Close();
        }

        public void Editar(Cidade cidade)
        {
            var conexao = new Conexao().Conectar();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"UPDATE cidades SET id_unidade_federativa = @ID_UNIDADE_FEDERATIVA,
                                    nome = @NOME, quantidade_habitantes = @QUANTIDADE_HABITANTES,
                                    data_hora_fundacao = @DATA_HORA_FUNDACAO, pib = @PIB WHERE id = @ID";
            // previnir Sql Injection
            comando.Parameters.AddWithValue("@ID_UNIDADE_FEDERATIVA", cidade.UnidadeFederativa.Id);
            comando.Parameters.AddWithValue("@NOME", cidade.Nome);
            comando.Parameters.AddWithValue("@QUANTIDADE_HABITANTES", cidade.QuantidadeHabitantes);
            comando.Parameters.AddWithValue("@DATA_HORA_FUNDACAO", cidade.DataHoraFundacao);
            comando.Parameters.AddWithValue("@PIB", cidade.Pib);
            comando.Parameters.AddWithValue("@ID", cidade.Id);

            // executa o insert
            comando.ExecuteNonQuery();

            // fechar conexão com banco de dados
            comando.Connection.Close();
        }

        public Cidade ObterPorId(int id)
        {
            var conexao = new Conexao().Conectar();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"SELECT id, id_unidade_federativa, nome, quantidade_habitantes, data_hora_fundacao, pib
                                        FROM cidades WHERE id = @ID";

            comando.Parameters.AddWithValue("@ID", id);

            // cria tabela em memória para armazenar registro da consulta
            var dataTable = new DataTable();

            // carregar registro no data table
            dataTable.Load(comando.ExecuteReader());

            // verifica se achou registro
            if (dataTable.Rows.Count == 0)
                return null;

            var registro = dataTable.Rows[0];
            var cidade = new Cidade();
            cidade.Id = Convert.ToInt32(registro["id"]);

            // instanciar unidade federativa para armazenar o registro da mesma
            cidade.UnidadeFederativa = new UnidadeFederativa();
            cidade.UnidadeFederativa.Id = Convert.ToInt32(registro["id_unidade_federativa"]);

            cidade.Nome = registro["nome"].ToString();

            comando.Connection.Close();

            return cidade;
        }

        public List<Cidade> ObterTodos()
        {
            var conexao = new Conexao().Conectar();
            var comando = conexao.CreateCommand();

            comando.CommandText = @"SELECT
c.id,
c.nome,
c.quantidade_habitantes,
c.data_hora_fundacao,
c.pib,
uf.id AS 'id_uf',
uf.nome AS 'nome_uf',
uf.sigla AS 'sigla_uf'
FROM cidades AS c
INNER JOIN unidades_federativas AS uf ON(c.id_unidade_federativa = uf.id)";

            var tabelaMemoria = new DataTable();
            tabelaMemoria.Load(comando.ExecuteReader());

            var cidades = new List<Cidade>();

            for (var i = 0; i < tabelaMemoria.Rows.Count; i++)
            {
                var registro = tabelaMemoria.Rows[i];

                // instanciado cidade com os dados
                var cidade = new Cidade();
                cidade.Id = Convert.ToInt32(registro["id"]);
                cidade.Nome = registro["nome"].ToString();
                cidade.QuantidadeHabitantes = Convert.ToInt32(registro["quantidade_habitantes"]);
                cidade.DataHoraFundacao = Convert.ToDateTime(registro["data_hora_fundacao"]);
                cidade.Pib = Convert.ToDecimal(registro["pib"]);

                // instamciado unidade federativa para armazenar o registro da mesma
                cidade.UnidadeFederativa = new UnidadeFederativa();
                cidade.UnidadeFederativa.Id = Convert.ToInt32(registro["id_uf"]);
                cidade.UnidadeFederativa.Nome = registro["nome_uf"].ToString();
                cidade.UnidadeFederativa.Sigla = registro["sigla_uf"].ToString();

                cidades.Add(cidade);
            }
            comando.Connection.Close();

            return cidades;
        }
    }
}