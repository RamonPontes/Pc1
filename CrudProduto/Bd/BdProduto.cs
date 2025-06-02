using System;
using System.Collections.Generic;
using CrudProduto.Models;
using MySql.Data.MySqlClient;
using MsBox.Avalonia;

namespace CrudProduto.Bd
{
    public class BdProduto
    {
        public void Insere(Produto produto)
        {
            MySqlDataAdapter da = new();
            MySqlCommand cmd = new();
            try
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into produto (descricao, marca, quantidade) values (@descricao, @marca, @quantidade)";
                cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@marca", produto.Marca);
                cmd.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                cmd.Connection = Bd.Conexao;
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var box = MessageBoxManager.GetMessageBoxStandard(
                    "Erro",
                    e.Message,
                    MsBox.Avalonia.Enums.ButtonEnum.Ok
                );

                var result = box.ShowAsync();
            }
        }

        public void Atualiza(Produto produto)
        {
            MySqlDataAdapter da = new();
            MySqlCommand cmd = new();

            try
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update produto set descricao=@descricao, marca=@marca, quantidade=@quantidade where id=@id";
                cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@marca", produto.Marca);
                cmd.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                cmd.Parameters.AddWithValue("@id", produto.Id);
                cmd.Connection = Bd.Conexao;
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var box = MessageBoxManager.GetMessageBoxStandard(
                    "Erro",
                    e.Message,
                    MsBox.Avalonia.Enums.ButtonEnum.Ok
                );

                var result = box.ShowAsync();
            }
        }

        public void Exclui(int id)
        {
            MySqlDataAdapter da = new();
            MySqlCommand cmd = new();

            try
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from produto where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = Bd.Conexao;
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                var box = MessageBoxManager.GetMessageBoxStandard(
                    "Erro",
                    e.Message,
                    MsBox.Avalonia.Enums.ButtonEnum.Ok
                );

                var result = box.ShowAsync();
            }
        }

        public Produto Localiza(int id)
        {
            MySqlDataReader dr;
            MySqlCommand cmd = new();
            Produto produto = new();

            try
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from produto where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = Bd.Conexao;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    produto.Id = dr.GetInt32("id");
                    produto.Descricao = dr.GetString("descricao");
                    produto.Marca = dr.GetString("marca");
                    produto.Quantidade = dr.GetInt32("quantidade");
                }

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                var box = MessageBoxManager.GetMessageBoxStandard(
                    "Erro",
                    e.Message,
                    MsBox.Avalonia.Enums.ButtonEnum.Ok
                );

                var result = box.ShowAsync();
            }

            return produto;
        }

        public List<Produto> Pesquisa(string descricao)
        {
            List<Produto> lista = new();
            MySqlDataReader dr;
            MySqlCommand cmd = new();

            try
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from produto where descricao like @descricao";
                cmd.Parameters.AddWithValue("@descricao", "%" + descricao + "%");
                cmd.Connection = Bd.Conexao;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Produto produto = new();
                    produto.Id = dr.GetInt32("id");
                    produto.Descricao = dr.GetString("descricao");
                    produto.Marca = dr.GetString("marca");
                    produto.Quantidade = dr.GetInt32("quantidade");

                    lista.Add(produto);
                }

                dr.Close();
                cmd.Dispose();
            }
            catch (Exception e)
            {
                var box = MessageBoxManager.GetMessageBoxStandard(
                    "Erro",
                    e.Message,
                    MsBox.Avalonia.Enums.ButtonEnum.Ok
                );

                var result = box.ShowAsync();
            }

            return lista;
        }
    }
}
