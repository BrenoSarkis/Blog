﻿using Blog.Fronteiras.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entidades;

namespace Blog.Testes.Dublês.Repositorios
{
    public class PostRepositorioMock : IPostRepositorio
    {
        public void Atualizar(Post post)
        {
            throw new NotImplementedException();
        }

        public int ContagemDePosts()
        {
            throw new NotImplementedException();
        }

        public void DeletarTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> ListarComPaginacao(int pagina, int quantidadeDePosts, string termoDePesquisa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> ListarPorTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ListarTodasAsTagsUnicas()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Post ObterCodigo(int codigo)
        {
            throw new NotImplementedException();
        }

        public Post ObterPorUrl(string url)
        {
            throw new NotImplementedException();
        }

        public Tag ObterTag(string tag, int codigoDoPost)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Post post)
        {
            throw new NotImplementedException();
        }

        public void SalvarComentario(Comentario comentario)
        {
            
        }
    }
}
