using System.Collections.Generic;
using BdCSharp.Models;
using MySql.Data.MySqlClient;
using MsBox.Avalonia;
using System;
using System.Data;
using MySqlX.XDevAPI.Common;

namespace BdCSharp.Bd {
    public class BdPessoa {
        public void Insere(Pessoa pessoa) {
            MySqlDataAdapter da = new();
            MySqlCommand cmd = new();
            try {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into pessoa (nome, cpf) values (@nome, @cpf)";
                cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                cmd.Connection = Bd.Conexao;
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
        public void Atualiza(Pessoa pessoa) {
            MySqlDataAdapter da = new();
            MySqlCommand cmd = new();
            
            try {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update pessoa set nome=@nome, cpf=@cpf where id=@id";
                cmd.Parameters.AddWithValue("@nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                cmd.Parameters.AddWithValue("@id", pessoa.Id);
                cmd.Connection = Bd.Conexao;
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
                cmd.CommandText = "delete from pessoa where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = Bd.Conexao;
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

        public Pessoa Localiza(int id) {
            MySqlDataReader dr;
            MySqlCommand cmd = new();
            Pessoa pessoa = new();

            try {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from pessoa where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = Bd.Conexao;
                dr = cmd.ExecuteReader();

                if (dr.Read()) {
                    pessoa.Id = dr.GetInt32("id");
                    pessoa.Nome = dr.GetString("nome");
                    pessoa.Cpf = dr.GetString("cpf");
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

            return pessoa;
        }

        public List<Pessoa> Pesquisa(String nome) {
            List<Pessoa> lista = [];
            MySqlDataReader dr;
            MySqlCommand cmd = new();

            try {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from pessoa where nome like @nome";
                cmd.Parameters.AddWithValue("@nome", "%" + nome + "%");
                cmd.Connection = Bd.Conexao;
                dr = cmd.ExecuteReader();
                
                while (dr.Read()) {
                    Pessoa pessoa = new();
                    pessoa.Id = dr.GetInt32("id");
                    pessoa.Nome = dr.GetString("nome");
                    pessoa.Cpf = dr.GetString("cpf");

                    lista.Add(pessoa);
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