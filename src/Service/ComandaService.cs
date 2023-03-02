using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.Dtos;

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
}
