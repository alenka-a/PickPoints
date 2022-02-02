using AutoMapper;
using PickPoints.Core.Exceptions;
using PickPoints.Core.Models;
using PickPoints.Core.Repositories.Interfaces;
using PickPoints.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickPoints.Core.Services
{
    public class PostampService : IPostampService
    {
        private readonly IPostampRepository _postampsRepository;
        private readonly IMapper _mapper;

        public PostampService(
            IPostampRepository postampsRepository,
            IMapper mapper)
        {
            _postampsRepository = postampsRepository;
            _mapper = mapper;
        }

        public async Task<PostampResponse> GetPostamp(string number)
        {
            var postamp = await _postampsRepository.FirstOrDefaultdAsync(x => x.Number == number);
            if (postamp == null)
                throw new NotFoundException($"Постамат с номером {number} не найден");
            return _mapper.Map<PostampResponse>(postamp);
        }

        public async Task<IEnumerable<PostampResponse>> GetActivePostamps()
        {
            var postamps = await _postampsRepository.ListAsync(x => x.IsActive);
            postamps = postamps.OrderBy(x => x.Number).ToList();

            return _mapper.Map<IEnumerable<PostampResponse>>(postamps);
        }
    }
}
