using AutoMapper;
using FarmersRecord.Dtos;
using FarmersRecord.FarmerMapping;
using FarmersRecord.FarmersRepository;
using FarmersRecord.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmersRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmersController : ControllerBase
    {
        private readonly IFarmersRepo _repo;
        private readonly IMapper _mapper;
        public FarmersController(IFarmersRepo repos, IMapper mapping)
        {
            _repo = repos;
            _mapper = mapping;
        }

        [HttpPost("AddFarmer")]
        public IActionResult AddFarmers([FromBody] FarmerDto farmdto)
        {
            try
            {
                if(farmdto == null)
                {
                    return BadRequest();
                }
                if (_repo.FarmExist(farmdto.FirstName))
                {
                    return StatusCode(400, "Name Already Exist In the DataBase");
                }

                var objMapper = _mapper.Map<FarmerModel>(farmdto);
                if (!_repo.CreateFarmer(objMapper))
                {
                    return StatusCode(500, "Internal Server Error");
                }

                return CreatedAtRoute("GetFarmerRec", new { farmId = farmdto.Id }, farmdto);
            }
            catch (Exception)
            {

                return StatusCode(400, "Check your code carefully");
            }
        } 
        
        
        [HttpPost("AddManyFarmers")]
        public async Task<IActionResult> AddManyFarmers([FromBody] List<FarmerModel> farms)
        {
            try
            {
                var res = await _repo.CreateManyFarmer(farms);
                if (res.ResponseCode != "00")
                    return BadRequest(res);
                return Ok(res);  
            }
            catch (Exception)
            {
                return StatusCode(400, "Check your code carefully");
            }
        }


        [HttpGet("GetFarmerRec")]
        public IActionResult GetFarmerRec()
        {
            var rate = _repo.getAllFarmRecord();
            return Ok(rate);
        }


        [HttpGet("GetFarmerRec1")]
        public IActionResult GetFarmerRec1()
        {
            var rate = _repo.getAllFarmRecord();
            var lst = new List<FarmerDto>();

            foreach(var i in rate)
            {
                lst.Add(_mapper.Map<FarmerDto>(i));
            }
            return Ok(lst);
        }

        [HttpGet("GetFarmerRecById")]
        public IActionResult GetFarmRecById(int farmId)
        {
            var getById = _repo.getFarmersById(farmId);
            return Ok(getById);
        }

        [HttpGet("GetFarmRecById0")]

        public IActionResult GetFarmByRecId0(int farmId)
        {
            var objRec = _repo.getFarmersById(farmId);
            if (objRec == null)
            {
                return BadRequest();
            }
             var objMap = _mapper.Map<FarmerDto>(objRec);
            return Ok(objMap);
            
        }

        [HttpPatch("UpdateRequest")]

        public IActionResult UpdateFarmRec([FromBody] FarmerDto farmdto, int farmId)
        {
            if(farmdto is null || farmId != farmdto.Id)
            {
                return BadRequest();
            }
            var objMap = _mapper.Map<FarmerModel>(farmdto);
            if (!_repo.UpdateFarmerRecord(objMap))
            {
                return StatusCode(500, "Oga Smoothly Sort out your issue don't come to the backend");
            }

            return NoContent();
        }

        [HttpDelete("RemoveFarmer")]
        public IActionResult RemoveFarmer(int farmId)
        {
            
            if (!_repo.FarmerExist(farmId))
            {
                return BadRequest();
            }
            _repo.DeleteFarmerRecord(farmId);
            return NoContent();
        }
    }
}
