using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.Dtos.Comanda;

namespace Service;

internal sealed class ComandaService : IComandaService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public ComandaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public ReadComandaDto CreateComanda(CreateComandaDto createComandaDto)
    {
        var comandaEntity = _mapper.Map<Comanda>(createComandaDto);
        
        _repository.Comanda.CreateComanda(comandaEntity);
        _repository.Save();

        var comandaRetorno = _mapper.Map<ReadComandaDto>(comandaEntity);
        return comandaRetorno;
    }

    public void DeleteComanda(int id, bool trackChanges)
    {
        var comanda = _repository.Comanda.GetComanda(id, trackChanges);
        if (comanda is null)
            throw new ComandaNotFoundException(id);

        _repository.Comanda.DeleteComanda(comanda);
        _repository.Save();
    }

    public IEnumerable<ReadComandasDto> GetAllComandas(bool trackChanges)
    {
        try
        {
            var comandas = _repository.Comanda.GetAllComandas(trackChanges);
            var comandasDto = _mapper.Map<IEnumerable<ReadComandasDto>>(comandas);

            return comandasDto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception in the {nameof(GetAllComandas)} service method: {ex}");
            throw;
        }
    }

    public ReadComandaDto GetComanda(int id, bool trackChanges)
    {
        var comanda = _repository.Comanda.GetComanda(id, trackChanges);

        if (comanda is null)
            throw new ComandaNotFoundException(id);

        var comandaDto = _mapper.Map<ReadComandaDto>(comanda);
        
        return comandaDto;
    }

    public ReadComandaDto UpdateComanda(int id, UpdateComandaDto updateComandaDto)
    {
        try
        {
            var comanda = _repository.Comanda.GetComanda(id, trackChanges: true);
            if (comanda is null)
                throw new ComandaNotFoundException(id);

            _mapper.Map(updateComandaDto, comanda);

            //validar para não inserir mais de 1 com mesmo id na lista

            if (updateComandaDto.Produtos != null)
            {
                comanda.Produtos ??= new List<Produto>();

                foreach (var produtoDto in updateComandaDto.Produtos)
                {
                    var produtoExistente = comanda.Produtos.SingleOrDefault(p => p.IdLista == produtoDto.IdLista);
                    if (produtoExistente == null)
                    {
                        comanda.Produtos.Add(_mapper.Map<Produto>(produtoDto));
                        continue;
                    }

                    _mapper.Map(produtoDto, produtoExistente);
                }
            }

            _repository.Save();

            var comandaRetorno = _mapper.Map<ReadComandaDto>(comanda);
            return comandaRetorno;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Exception in the {nameof(UpdateComanda)} service method: {ex}");
            throw;
        }
    }
}
