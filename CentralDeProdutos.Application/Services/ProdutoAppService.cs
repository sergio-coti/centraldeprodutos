using AutoMapper;
using CentralDeProdutos.Application.Commands;
using CentralDeProdutos.Application.Ports;
using CentralDeProdutos.Application.Queries;
using CentralDeProdutos.Domain.Interfaces;
using CentralDeProdutos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeProdutos.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoDomainService? _produtoDomainService;
        private readonly IMapper? _mapper;

        public ProdutoAppService(IProdutoDomainService? produtoDomainService, IMapper? mapper)
        {
            _produtoDomainService = produtoDomainService;
            _mapper = mapper;
        }

        public ProdutosQuery Add(CreateProdutoCommand command)
        {
            var produto = _mapper.Map<Produto>(command);
            _produtoDomainService.Add(produto);

            return _mapper.Map<ProdutosQuery>(produto);
        }

        public ProdutosQuery Update(UpdateProdutoCommand command)
        {
            var produto = _mapper.Map<Produto>(command);
            _produtoDomainService.Update(produto);

            return _mapper.Map<ProdutosQuery>(produto);
        }

        public ProdutosQuery Delete(DeleteProdutoCommand command)
        {
            var produto = _mapper.Map<Produto>(command);
            _produtoDomainService.Delete(produto);

            return _mapper.Map<ProdutosQuery>(produto);
        }

        public List<ProdutosQuery> GetAll()
        {
            var produtos = _produtoDomainService.GetAll();
            return _mapper.Map<List<ProdutosQuery>>(produtos);
        }

        public ProdutosQuery GetById(Guid? id)
        {
            var produto = _produtoDomainService.GetById(id.Value);
            return _mapper.Map<ProdutosQuery>(produto);
        }

        public void Dispose()
        {
            _produtoDomainService.Dispose();
        }
    }
}
