using System;
using BdCSharp.Bd;
using CrudProduto.Models;
using MsBox.Avalonia;
using MySql.Data.MySqlClient;

namespace CrudProduto.Db {
    public class DbProduto {
        public void Insere(Produto produto) {
            MySqlDataAdapter da = new();
            MySqlCommand cmd = new();

            try {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into produto (descricao, marca, quantidade) values (@descricao, @marca, @quantidade)";
                cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@marca", produto.Marca);
                cmd.Parameters.AddWithValue("@quantidade", produto.Quantidade);

                cmd.Connection = Bd.Conexao;
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e) {
                var box = MessageBoxManager.GetMessageBoxStandard(
                    "Erro",
                    e.Message,
                    MsBox.Avalonia.Enums.ButtonEnum.Ok
                );

                var result = box.ShowAsync();
            }
        }
        public void Atualiza(Produto produto) {
            MySqlDataAdapter da = new();
            MySqlCommand cmd = new();

            try {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update produto set descricao=@descricao, marca=@descricao, quantidade=@quantidade where id=@id";
                cmd.Parameters.AddWithValue("@descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@marca", produto.Marca);
                cmd.Parameters.AddWithValue("@quantidade", produto.Quantidade);
                cmd.Parameters.AddWithValue("@id", produto.Id);

                cmd.Connection = Bd.Conexao;
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e) {
                var box = MessageBoxManager.GetMessageBoxStandard(
                    "Erro",
                    e.Message,
                    MsBox.Avalonia.Enums.ButtonEnum.Ok
                );

                var result = box.ShowAsync();
            }
        }
        public void Exclui(int id) {
            MySqlDataAdapter da = new();
            MySqlCommand cmd = new();

            try {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "delete from produto where id=@id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.Connection = Bd.Conexao;
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
            }
            catch (Exception e) {
                var box = MessageBoxManager.GetMessageBoxStandard(
                    "Erro",
                    e.Message,
                    MsBox.Avalonia.Enums.ButtonEnum.Ok
                );

                var result = box.ShowAsync();
            }
        }

        public Produto Localiza(int id) {
            MySqlDataReader dr;
            MySqlCommand cmd = new();
            Produto produto = new();

            try {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from produto where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = Bd.Conexao;
                dr = cmd.ExecuteReader();

                if (dr.Read()) {
                    produto.Id = dr.GetInt32("id");
                    produto.Descricao = dr.GetString("descricao");
                    produto.Marca = dr.GetString("marca");
                    produto.Quantidade = dr.GetInt32("id");
                }

                dr.Close();
                cmd.Dispose();
            } catch (Exception e) {
                var box = MessageBoxManager.GetMessageBoxStandard(
                    "Erro",
                    e.Message,
                    MsBox.Avalonia.Enums.ButtonEnum.Ok
                );

                var result = box.ShowAsync();
            }

            return produto;
        }

    }
}