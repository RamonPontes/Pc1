using System.Collections.Generic;
using CrudProduto.Models;
using MySql.Data.MySqlClient;
using MsBox.Avalonia;
using System;
using System.Data;
using MySqlX.XDevAPI.Common;

namespace CrudProduto.Db {
    public class DbProduto {
        public void Insere(Produto produto) {
            MySqlDataAdapter da = new();
            MySqlCommand cmd = new();
            try {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into produto (nome, valor) values (@nome, @valor)";
                cmd.Parameters.AddWithValue("@nome", produto.Nome);
                cmd.Parameters.AddWithValue("@valor", produto.Valor);
                cmd.Connection = Db.Conexao;
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
            } catch (Exception e) {
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
                cmd.CommandText = "update produto set nome=@nome, valor=@valor where id=@id";
                cmd.Parameters.AddWithValue("@nome", produto.Nome);
                cmd.Parameters.AddWithValue("@valor", produto.Valor);
                cmd.Parameters.AddWithValue("@id", produto.Id);
                cmd.Connection = Db.Conexao;
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
            } catch (Exception e) {
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
                cmd.Connection = Db.Conexao;
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
            } catch (Exception e) {
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
                cmd.Connection = Db.Conexao;
                dr = cmd.ExecuteReader();

                if (dr.Read()) {
                    produto.Id = dr.GetInt32("id");
                    produto.Nome = dr.GetString("nome");
                    produto.Valor = dr.GetInt32("valor");
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

        public List<Produto> Pesquisa(String nome) {
            List<Produto> lista = [];
            MySqlDataReader dr;
            MySqlCommand cmd = new();

            try {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from produto where nome like @nome";
                cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");
                cmd.Connection = Db.Conexao;
                dr = cmd.ExecuteReader();
                
                while (dr.Read()) {
                    Produto produto = new();
                    produto.Id = dr.GetInt32("id");
                    produto.Nome = dr.GetString("nome");
                    produto.Valor = dr.GetInt32("valor");

                    lista.Add(produto);
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

            return lista;
        }
    }
}