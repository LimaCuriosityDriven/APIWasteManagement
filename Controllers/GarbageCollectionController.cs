using AutoMapper;
using Fiap.Api.WasteManagementApplication.Models;
using Fiap.Api.WasteManagementApplication.Services;
using Fiap.Api.WasteManagementApplication.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.WasteManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GarbageCollectionController : ControllerBase
    {
        private readonly IGarbageCollectionService _service;
        private readonly IMapper _mapper;

        public GarbageCollectionController(IGarbageCollectionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles ="admin")]
        public ActionResult Post([FromBody] CreateGarbageCollectionViewModel createGarbageCollectionViewModel)
        {
            var garbageC = _mapper.Map<GarbageCollection>(createGarbageCollectionViewModel);

            try
            {
                _service.AddService(garbageC);
                return CreatedAtAction(nameof(GetGarbageById), new { id = garbageC.Id }, createGarbageCollectionViewModel);
            }
            catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin,user")]
        public ActionResult<IEnumerable<GarbageCollectionPageReferenceViewModel>> GetByReference([FromQuery] int reference = 0, [FromQuery] int size = 5)
        {
            var garbageC = _service.GetAllByReferenceServices(reference, size);
            var viewModelList = _mapper.Map<IEnumerable<GarbageCollectionViewModel>>(garbageC);

            var viewModel = new GarbageCollectionPageReferenceViewModel
            {
                GarbageCollection = viewModelList,
                PageSize = size,
                Ref = reference,
                NextRef = viewModelList.Last().Id
            };

            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin,user")]
        public ActionResult<GarbageCollectionViewModel> GetGarbageById(int id) {
            var garbageC = _service.GetByIdService(id);
            if (garbageC == null)
            {
                return NotFound();
            }

            var garbageCVM = _mapper.Map<GarbageCollectionViewModel>(garbageC);
            return Ok(garbageCVM);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Put(int id, [FromBody] GarbageCollectionViewModel viewModel)
        {
            var garbageC = _service.GetByIdService(id);
            if (garbageC == null)
            {
                return NotFound();
            }

            _mapper.Map(viewModel, garbageC);
            _service.UpdateService(garbageC);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id) {
            var garbageC = _service.GetByIdService(id);
            if(garbageC == null)
            {
                return NotFound();
            }

            _service.RemoveService(id);
            return NoContent();
        }
    }
}
